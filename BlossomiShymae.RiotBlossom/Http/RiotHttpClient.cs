using AsyncKeyedLock;
using BlossomiShymae.RiotBlossom.Exception;
using BlossomiShymae.RiotBlossom.Middleware;

namespace BlossomiShymae.RiotBlossom.Http
{
    internal class RiotHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _riotApiKey;
        private readonly MiddlewareStack _middlewareStack;
        private readonly AsyncKeyedLocker<string> _locker = new();

        public RiotHttpClient(HttpClient httpClient, string riotApiKey, MiddlewareStack middlewareStack)
        {
            _httpClient = httpClient;
            _riotApiKey = riotApiKey;
            _middlewareStack = middlewareStack;
        }

        public Task<byte[]> GetByteArrayAsync(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetStringAsync(string routingValue, string uri)
        {
            if (string.IsNullOrEmpty(_riotApiKey))
                throw new MissingApiKeyException("Riot API key is required to access this service");

            Uri requestUri = new($"https://{routingValue}.api.riotgames.com{uri}");
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            requestMessage.Headers.Add("X-Riot-Token", _riotApiKey);

            var info = new ExecuteInfo
            {
                RoutingValue = routingValue,
                MethodUri = uri,
            };

            using (await _locker.LockAsync(routingValue))
            {
                string data = await ProcessMiddlewareStackAsync(info, requestMessage);
                return data;
            }
        }

        public Task<string> GetStringAsync(string uri)
        {
            throw new NotImplementedException();
        }

        private async Task<string> ProcessMiddlewareStackAsync(ExecuteInfo xExecuteInfo, HttpRequestMessage requestMessage)
        {
            // Use requestUri middlewares, if any
            string? data = null;
            void hit(string value) => data = value;
            bool isNext = false;
            void next() => isNext = true;
            foreach (var requestMiddleware in _middlewareStack.RequestSeries)
            {
                isNext = false;
                await requestMiddleware.UseRequestAsync(xExecuteInfo, requestMessage, next, hit);
                if (!isNext)
                    break;
            }
            if (data != null)
                return data;

            // Use retry middleware, if any
            var res = await _middlewareStack.Retry.UseRetryAsync(async () => await _httpClient.SendAsync(requestMessage));

            // Use response middlewares, if any
            foreach (var responseMiddleware in _middlewareStack.ResponseSeries)
            {
                isNext = false;
                await responseMiddleware.UseResponseAsync(xExecuteInfo, res, next);
                if (!isNext)
                    break;
            }

            if (!res.IsSuccessStatusCode)
            {
                int statusCode = (int)res.StatusCode;
                res.Dispose();
                throw new InvalidOperationException($"Response is not successful: {statusCode}");
            }

            data = await res.Content.ReadAsStringAsync();
            res.Dispose();
            return data;
        }
    }
}
