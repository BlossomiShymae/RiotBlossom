namespace Soraka.Http
{
	public static class MerakiAnalyticsClient
	{
		public static GetAsyncFunc
			GetAsync(HttpClient client) =>
			async (uri) => await client.GetAsync($"https://cdn.merakianalytics.com/riot/lol/resources/latest/en-US{uri}");

		public delegate Task<HttpResponseMessage> GetAsyncFunc(string uri);
	}
}
