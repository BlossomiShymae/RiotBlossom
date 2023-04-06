using AsyncKeyedLock;
using BlossomiShymae.RiotBlossom.Exception;

namespace BlossomiShymae.RiotBlossom.Http
{
    internal class RiotHttpClient : IHttpClient
    {
        private readonly ComposableHttpClient _composableHttpClient;
        private readonly string _riotApiKey;
        private readonly AsyncKeyedLocker<string> _locker = new();

        public RiotHttpClient(ComposableHttpClient composableHttpClient, string riotApiKey)
        {
            _composableHttpClient = composableHttpClient;
            _riotApiKey = riotApiKey;
        }

        public Task<byte[]> GetByteArrayAsync(string uri)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetStringAsync(string uri, string routingValue)
        {
            if (string.IsNullOrEmpty(_riotApiKey))
                throw new MissingApiKeyException("Riot API key is required to access this service");

            Uri requestUri = new($"https://{routingValue}.api.riotgames.com{uri}");
            using HttpRequestMessage requestMessage = new(HttpMethod.Get, requestUri);
            requestMessage.Headers.Add("X-Riot-Token", _riotApiKey);

            using (await _locker.LockAsync(routingValue))
            {
                return await _composableHttpClient.GetStringAsync(requestMessage, routingValue, uri);
            }
        }
    }
}
