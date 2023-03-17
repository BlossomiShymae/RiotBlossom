namespace Gwen.Http
{
    internal class MerakiAnalyticsClient
    {
        private readonly HttpClient _httpClient;

        public MerakiAnalyticsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetStringAsync(string uri)
            => await _httpClient.GetStringAsync($"https://cdn.merakianalytics.com/riot/lol/resources/latest/en-US{uri}");
    }
}
