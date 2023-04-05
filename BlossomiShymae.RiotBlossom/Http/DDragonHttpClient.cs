namespace BlossomiShymae.RiotBlossom.Http
{
    internal class DDragonHttpClient : IHttpClient
    {
        private static readonly string s_url = "https://ddragon.leagueoflegends.com";
        private readonly HttpClient _httpClient;

        public DDragonHttpClient(HttpClient httpClient)
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
