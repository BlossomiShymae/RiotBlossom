namespace BlossomiShymae.RiotBlossom.Http
{
    internal class CDragonHttpClient : IHttpClient
    {
        private static readonly string s_url = "https://raw.communitydragon.org";
        private readonly HttpClient _httpClient;

        public CDragonHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> GetByteArrayAsync(string uri)
        {
            return await _httpClient.GetByteArrayAsync($"{s_url}{uri}");
        }

        public async Task<string> GetStringAsync(string uri)
        {
            return await _httpClient.GetStringAsync($"{s_url}{uri}");
        }
    }
}
