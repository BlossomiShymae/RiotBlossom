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

                var res = await ProcessMiddlewaresAsync(client, requestMessage, middlewarePipeline);
                return res;
            };

        public static async Task<HttpResponseMessage> ProcessMiddlewaresAsync(HttpClient client, HttpRequestMessage requestMessage, MiddlewarePipeline middlewarePipeline)
        {
            // Use request middlewares, if any
            HttpRequestMessage req = requestMessage;
            HttpResponseMessage? res = null;
            void hit(HttpResponseMessage responseMessage) => res = responseMessage;
            foreach (var requestMiddleware in middlewarePipeline.RequestMiddlewares)
                if (res == null) req = requestMiddleware.Invoke(req, hit);
            if (res != null) return res;

            // Use response middlewares, if any
            res = await middlewarePipeline.RetryMiddleware.Invoke(async () => await client.SendAsync(requestMessage));
            foreach (var responseMiddleware in middlewarePipeline.ResponseMiddlewares)
                res = responseMiddleware.Invoke(res);

            return res;
        }

        public delegate Task<HttpResponseMessage> GetAsyncFunc(string uri, string query);

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

        public delegate HttpRequestMessage RequestMiddleware(HttpRequestMessage requestMessage, Action<HttpResponseMessage> hit);
        public delegate HttpResponseMessage ResponseMiddleware(HttpResponseMessage responseMessage);
        public delegate Task<HttpResponseMessage> RetryMiddleware(Func<Task<HttpResponseMessage>> responseMessageFunc);
    }
}
