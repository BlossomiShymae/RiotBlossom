namespace Gwen.Http
{
    internal class DDragonHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public DDragonHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetStringAsync(string uri)
        {
            return await _httpClient.GetStringAsync($"https://ddragon.leagueoflegends.com{uri}");
        }
    }
}
