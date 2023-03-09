namespace Soraka.Http
{
	public static class RiotGamesClient
	{
		public static GetByRoutingValueAsyncFunc
			GetAsync(HttpClient client) =>
			(routingValue) =>
			(uri) =>
			async (query) => await client.GetAsync($"https://{routingValue}.api.riotgames.com{uri}/{query}");

		public delegate GetByUriAsyncFunc GetByRoutingValueAsyncFunc(string routingValue);
		public delegate GetAsyncFunc GetByUriAsyncFunc(string uri);
		public delegate Task<HttpResponseMessage> GetAsyncFunc(string query);
	}
}
