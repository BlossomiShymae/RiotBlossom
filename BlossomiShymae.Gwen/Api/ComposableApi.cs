using BlossomiShymae.Gwen.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BlossomiShymae.Gwen.Api
{
    internal class ComposableApi<T>
    {
        private static readonly JsonSerializerOptions s_options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        private readonly IHttpClient _httpClient;

        public ComposableApi(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal U Deserialize<U>(JsonObject obj)
        {
            var value = JsonSerializer.Deserialize<U>(obj, s_options);
            return value == null ? throw new NullReferenceException($"Failed to deserialize object {obj}") : value;
        }

        internal async Task<byte[]> GetByteArrayAsync(string uri)
        {
            return await _httpClient.GetByteArrayAsync(uri);
        }

        internal async Task<T> GetValueAsync(string uri)
        {
            string data = await _httpClient.GetStringAsync(uri);
            var dto = JsonSerializer.Deserialize<T>(data, s_options);
            return dto == null ? throw new NullReferenceException($"Failed to deserialize response data {data}") : dto;
        }

        internal async Task<T> GetValueAsync(string routingValue, string uri)
        {
            if (_httpClient is RiotHttpClient client)
            {
                string data = await client.GetStringAsync(routingValue, uri);
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };
                var dto = JsonSerializer.Deserialize<T>(data, options);
                return dto == null ? throw new NullReferenceException($"Failed to deserialize response data {data}") : dto;
            }
            else
            {
                throw new InvalidOperationException("Method can only operate if http client is a Riot http client");
            }
        }
    }
}
