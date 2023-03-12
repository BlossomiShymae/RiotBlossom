using System.Collections.Immutable;

namespace Gwen.Http
{
    public static class RiotGamesClient
    {
        public static GetAsyncFunc
            GetAsync(HttpClient client, string riotApiKey, string routingValue, MiddlewarePipeline middlewarePipeline) =>
            async (uri, query) =>
            {
                // Create request message
                var requestUri = new Uri($"https://{routingValue}.api.riotgames.com{uri}{query}");
                using var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
                requestMessage.Headers.Add("X-Riot-Token", riotApiKey);

                var data = await ProcessMiddlewaresAsync(client, requestMessage, middlewarePipeline);
                return data;
            };

        public static async Task<string> ProcessMiddlewaresAsync(HttpClient client, HttpRequestMessage requestMessage, MiddlewarePipeline middlewarePipeline)
        {
            // Use request middlewares, if any
            string? data = null;
            void hit(string value) => data = value;
            bool isNext = false;
            void next() => isNext = true;
            foreach (var requestMiddleware in middlewarePipeline.RequestMiddlewares)
            {
                isNext = false;
                if (data == null)
                    await requestMiddleware.Invoke(requestMessage, hit, next);
                if (!isNext)
                    break;
            }
            if (data != null)
                return data;

            // Use retry middleware, if any
            var res = await middlewarePipeline.RetryMiddleware.Invoke(async () => await client.SendAsync(requestMessage));

            // Use response middlewares, if any
            foreach (var responseMiddleware in middlewarePipeline.ResponseMiddlewares)
            {
                isNext = false;
                await responseMiddleware.Invoke(res, next);
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

        public delegate Task<string> GetAsyncFunc(string uri, string query);

        public record MiddlewarePipeline
        {
            public ImmutableArray<RequestMiddleware> RequestMiddlewares { get; init; } = new List<RequestMiddleware>
            {
                XBoundedCache.UseRequest
            }.ToImmutableArray();
            public ImmutableArray<ResponseMiddleware> ResponseMiddlewares { get; init; } = new List<ResponseMiddleware>
            {
                XBoundedCache.UseResponse
            }.ToImmutableArray();
            public RetryMiddleware RetryMiddleware { get; init; } = XRetryer.Use;
        }

        public delegate Task RequestMiddleware(HttpRequestMessage requestMessage, Action<string> hit, Action next);
        public delegate Task ResponseMiddleware(HttpResponseMessage responseMessage, Action next);
        public delegate Task<HttpResponseMessage> RetryMiddleware(Func<Task<HttpResponseMessage>> responseMessageFunc);
    }
}
