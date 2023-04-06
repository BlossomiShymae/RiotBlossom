using BlossomiShymae.RiotBlossom.Middleware;
using System.Text;

namespace BlossomiShymae.RiotBlossom.Http
{
    internal class ComposableHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly MiddlewareStack _middlewareStack;

        public ComposableHttpClient(HttpClient httpClient, MiddlewareStack middlewareStack)
        {
            _httpClient = httpClient;
            _middlewareStack = middlewareStack;
        }

        public async Task<string> GetStringAsync(HttpRequestMessage requestMessage, string routingValue, string methodUri)
        {
            ExecuteInfo info = new()
            {
                MethodUri = methodUri,
                RoutingValue = routingValue
            };
            byte[] data = await ProcessMiddlewareStackAsync(info, requestMessage);
            string stringData = Encoding.UTF8.GetString(data);
            return stringData;
        }

        public async Task<byte[]> GetByteArrayAsync(HttpRequestMessage requestMessage, string routingValue, string methodUri)
        {
            ExecuteInfo info = new()
            {
                MethodUri = methodUri,
                RoutingValue = routingValue
            };
            byte[] data = await ProcessMiddlewareStackAsync(info, requestMessage);
            return data;
        }

        private async Task<byte[]> ProcessMiddlewareStackAsync(ExecuteInfo executeInfo, HttpRequestMessage httpRequestMessage)
        {
            // Use requestUri middlewares, if any
            byte[]? data = null;
            void hit(byte[] value) => data = value;
            bool isNext = false;
            void next() => isNext = true;
            foreach (var requestMiddleware in _middlewareStack.RequestSeries)
            {
                isNext = false;
                await requestMiddleware.UseRequestAsync(executeInfo, httpRequestMessage, next, hit);
                if (!isNext)
                    break;
            }
            if (data != null)
                return data;

            // Use retry middleware, if any
            IRetryMiddleware? retryMiddleware = _middlewareStack.Retry;
            HttpResponseMessage? res;
            if (retryMiddleware != null)
                res = await retryMiddleware.UseRetryAsync(async () => await _httpClient.SendAsync(httpRequestMessage));
            else
                res = await _httpClient.SendAsync(httpRequestMessage);

            // Use response middlewares, if any
            foreach (var responseMiddleware in _middlewareStack.ResponseSeries)
            {
                isNext = false;
                await responseMiddleware.UseResponseAsync(executeInfo, res, next);
                if (!isNext)
                    break;
            }

            if (!res.IsSuccessStatusCode)
            {
                int statusCode = (int)res.StatusCode;
                res.Dispose();
                throw new InvalidOperationException($"Response is not successful: {statusCode}");
            }

            data = await res.Content.ReadAsByteArrayAsync();
            res.Dispose();
            return data;
        }
    }
}
