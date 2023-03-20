namespace Gwen.Http
{
	internal class CDragonHttpClient : IHttpClient
	{
		private readonly HttpClient _httpClient;

		public CDragonHttpClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public Task<byte[]> GetByteArrayAsync(string uri)
		{
			throw new NotImplementedException();
		}

		public async Task<string> GetStringAsync(string uri)
		{
			return await _httpClient.GetStringAsync($"https://raw.communitydragon.org{uri}");
		}
	}
}
