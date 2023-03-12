using System.Collections.Immutable;

namespace Soraka.Http
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
			};

		public delegate Task<HttpResponseMessage> GetAsyncFunc(string uri, string query);

		public record MiddlewarePipeline
		{
			public ImmutableArray<RequestMiddleware> RequestMiddlewares { get; init; } = ImmutableArray<RequestMiddleware>.Empty;
			public ImmutableArray<ResponseMiddleware> ResponseMiddlewares { get; init; } = ImmutableArray<ResponseMiddleware>.Empty;
			public RetryMiddleware RetryMiddleware { get; init; } = XRetryer.Use;
		}

		public delegate HttpRequestMessage RequestMiddleware(HttpRequestMessage requestMessage, Action<HttpResponseMessage> hit);
		public delegate HttpResponseMessage ResponseMiddleware(HttpResponseMessage responseMessage);
		public delegate Task<HttpResponseMessage> RetryMiddleware(Func<Task<HttpResponseMessage>> responseMessageFunc);
	}
}
