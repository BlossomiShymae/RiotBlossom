using AsyncKeyedLock;
using BlossomiShymae.RiotBlossom.Exception;
using BlossomiShymae.RiotBlossom.XMiddleware;

namespace BlossomiShymae.RiotBlossom.Http
{
    internal class RiotHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _riotApiKey;
        private readonly XMiddlewares _xMiddlewares;
        private readonly AsyncKeyedLocker<string> _locker = new();

        public RiotHttpClient(HttpClient httpClient, string riotApiKey, XMiddlewares xMiddlewares)
        {
            _httpClient = httpClient;
            _riotApiKey = riotApiKey;
            _xMiddlewares = xMiddlewares;
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

            var info = new XExecuteInfo
            {
                RoutingValue = routingValue,
                MethodUri = uri,
            };

            using (await _locker.LockAsync(routingValue))
            {
                string data = await ProcessXMiddlewaresAsync(info, requestMessage);
                return data;
            }
        }

        public Task<string> GetStringAsync(string uri)
        {
            throw new NotImplementedException();
        }

        private async Task<string> ProcessXMiddlewaresAsync(XExecuteInfo xExecuteInfo, HttpRequestMessage requestMessage)
        {
            // Use requestUri middlewares, if any
            string? data = null;
            void hit(string value) => data = value;
            bool isNext = false;
            void next() => isNext = true;
            foreach (var requestMiddleware in _xMiddlewares.XRequests)
            {
                isNext = false;
                await requestMiddleware.UseRequest(xExecuteInfo, requestMessage, next, hit);
                if (!isNext)
                    break;
            }
            if (data != null)
                return data;

            // Use retry middleware, if any
            var res = await _xMiddlewares.XRetry.UseRetry(async () => await _httpClient.SendAsync(requestMessage));

            // Use response middlewares, if any
            foreach (var responseMiddleware in _xMiddlewares.XResponses)
            {
                isNext = false;
                await responseMiddleware.UseResponse(xExecuteInfo, res, next);
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
