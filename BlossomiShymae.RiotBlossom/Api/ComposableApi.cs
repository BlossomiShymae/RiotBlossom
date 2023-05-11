using BlossomiShymae.RiotBlossom.Http;
using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BlossomiShymae.RiotBlossom.Api
{
    /// <summary>
    /// <para>Represents a composable API to fetch data from injected <see cref="IHttpClient"/>.</para>
    /// <para>I really think this internal class is a fugly mess so it will probably be refactored soon at some point. - BlossomiShymae</para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

        internal U? DeserializeNode<U>(JsonNode node)
        {
            if (node is JsonObject obj)
                return JsonSerializer.Deserialize<U>(obj.AsObject(), s_options);
            if (node is JsonArray array)
                return JsonSerializer.Deserialize<U>(array.AsArray(), s_options);
            if (node is JsonValue value)
                return JsonSerializer.Deserialize<U>(value.AsValue(), s_options);
            throw new InvalidOperationException("JsonNode is not a JsonObject, JsonArray, nor JsonValue");
        }

        internal async Task<byte[]> GetByteArrayAsync(string uri)
        {
            return await _httpClient.GetByteArrayAsync(uri);
        }

        internal async Task<T> GetValueAsync(string uri)
        {
            string data = await _httpClient.GetStringAsync(uri, string.Empty);
            var dto = JsonSerializer.Deserialize<T>(data, s_options);
            return dto == null ? throw new NullReferenceException($"Failed to deserialize response data {data}") : dto;
        }

        internal async Task<T> GetValueAsync(string routingValue, string uri)
            => await GetValueAsync(routingValue, uri, ImmutableDictionary<string, string>.Empty);

        internal async Task<T> GetValueAsync(string routingValue, string uri, IDictionary<string, string> headers)
        {
            if (_httpClient is RiotHttpClient client)
            {
                string data = await client.GetStringAsync(uri, routingValue, headers);
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
