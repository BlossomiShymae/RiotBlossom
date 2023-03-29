using BlossomiShymae.Gwen.PException;
using BlossomiShymae.Gwen.XMiddleware;

namespace BlossomiShymae.Gwen.Http
{
    internal class RiotHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _riotApiKey;
        private readonly string _routingValue;
        private readonly XMiddlewares _xMiddlewares;

        public RiotHttpClient(HttpClient httpClient, string riotApiKey, string routingValue, XMiddlewares xMiddlewares)
        {
            _httpClient = httpClient;
            _riotApiKey = riotApiKey;
            _routingValue = routingValue;
            _xMiddlewares = xMiddlewares;
        }

        public Task<byte[]> GetByteArrayAsync(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetStringAsync(string uri)
        {
            // Create request message
            var requestUri = new Uri($"https://{_routingValue}.api.riotgames.com{uri}");
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            requestMessage.Headers.Add("X-Riot-Token", _riotApiKey);

            // Create execute info
            var executeInfo = new XExecuteInfo
            {
                RoutingValue = _routingValue,
                MethodUri = uri
            };

            var data = await ProcessXMiddlewaresAsync(executeInfo, requestMessage);
            return data;
        }

        public async Task<string> GetStringAsync(string routingValue, string uri)
        {
            if (string.IsNullOrEmpty(_riotApiKey))
                throw new InvalidRiotKeyException("Riot API key is required to access this service");

            Uri requestUri = new($"https://{routingValue}.api.riotgames.com{uri}");
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
            requestMessage.Headers.Add("X-Riot-Token", _riotApiKey);

            var info = new XExecuteInfo
            {
                RoutingValue = _routingValue,
                MethodUri = uri,
            };

            string data = await ProcessXMiddlewaresAsync(info, requestMessage);
            return data;
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
