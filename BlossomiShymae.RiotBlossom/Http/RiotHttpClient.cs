using AsyncKeyedLock;
using BlossomiShymae.RiotBlossom.Exception;
using System.Collections.Immutable;

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
            => await GetStringAsync(uri, routingValue, ImmutableDictionary<string, string>.Empty);

        internal async Task<string> GetStringAsync(string uri, string routingValue, IDictionary<string, string> headers)
        {
            if (string.IsNullOrEmpty(_riotApiKey))
                throw new MissingApiKeyException("Riot API key is required to access this service");

            Uri requestUri = new($"https://{routingValue}.api.riotgames.com{uri}");
            using HttpRequestMessage requestMessage = new(HttpMethod.Get, requestUri);
            string riotToken = "X-Riot-Token";
            requestMessage.Headers.Add(riotToken, _riotApiKey);
            foreach (KeyValuePair<string, string> kvp in headers)
            {
                if (kvp.Key.ToLower() != riotToken.ToLower())
                {
                    requestMessage.Headers.Add(kvp.Key, kvp.Value);
                }
                // Override the Riot Token header if user has passed it in
                else
                {
                    requestMessage.Headers.Remove(riotToken);
                    requestMessage.Headers.Add(riotToken, kvp.Value);
                }
            }

            using (await _locker.LockAsync(routingValue))
            {
                return await _composableHttpClient.GetStringAsync(requestMessage, routingValue, uri);
            }
        }
    }
}
