namespace Gwen.Http
{
	internal class CDragonHttpClient : IHttpClient
	{
		private readonly HttpClient _httpClient;

		public CDragonHttpClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<string> GetStringAsync(string uri)
		{
			return await _httpClient.GetStringAsync($"https://raw.communitydragon.org{uri}");
		}
	}
}
