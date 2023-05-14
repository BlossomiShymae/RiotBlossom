namespace BlossomiShymae.RiotBlossom.Http
{
    internal class MerakiAnalyticsHttpClient : IHttpClient
    {
        private static readonly string s_url = "https://cdn.merakianalytics.com/riot/lol/resources/latest/en-US";
        private readonly ComposableHttpClient _composableHttpClient;

        public MerakiAnalyticsHttpClient(ComposableHttpClient composableHttpClient)
        {
            _composableHttpClient = composableHttpClient;
        }

        public async Task<byte[]> GetByteArrayAsync(string uri)
        {
            Uri requestUri = new($"{s_url}{uri}");
            using HttpRequestMessage requestMessage = new(HttpMethod.Get, requestUri);
            return await _composableHttpClient.GetByteArrayAsync(requestMessage, string.Empty, uri);
        }

        public async Task<string> GetStringAsync(string uri, string routingValue)
        {
            Uri requestUri = new($"{s_url}{uri}");
            using HttpRequestMessage requestMessage = new(HttpMethod.Get, requestUri);
            return await _composableHttpClient.GetStringAsync(requestMessage, string.Empty, uri);
        }
    }
}
