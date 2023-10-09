using System;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Web;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Core.Cache;
using BlossomiShymae.RiotBlossom.Core.Calling;
using BlossomiShymae.RiotBlossom.Core.Exceptions;
using BlossomiShymae.RiotBlossom.Core.Limiting;
using BlossomiShymae.RiotBlossom.Core.Utils;
using BlossomiShymae.RiotBlossom.Data.Constants;

namespace BlossomiShymae.RiotBlossom.Client.Apis
{
    internal abstract class DataApi
    {
        protected readonly ApiConfiguration ApiConfiguration;
        protected readonly ConcurrentDictionary<string, SemaphoreSlim> Locks = new();
        protected readonly Cache Cache;
        protected readonly Limiter Limiter;

        protected DataApi(ApiConfiguration configuration)
        {
            ApiConfiguration = configuration;

            // Setup cache provider
            Cache = configuration.CacheProvider switch
            {
                CacheProvider.Empty => new EmptyCache(configuration.CacheTTLConfiguration),
                CacheProvider.FileSystem => new FileSystemCache(configuration.CacheTTLConfiguration),
                CacheProvider.Memory => new MemoryCache(configuration.CacheTTLConfiguration),
                _ => new EmptyCache(configuration.CacheTTLConfiguration),
            };

            // Setup limiter provider
            Limiter = configuration.LimiterProvider switch
            {
                LimiterProvider.Empty => new EmptyLimiter(),
                LimiterProvider.Burst => new BurstLimiter(),
                _ => new EmptyLimiter(),
            };
        }

        protected async Task<T> CallAsync<T>(DataCall call)
        {
            if (call.Shard == null)
                throw new InvalidOperationException("Shard must be set!");

            // Format endpoint placeholder with data and query parameters
            var method = new NamedFormatter(call.Method);
            var methodUri = method.Format(call.Params);
            var uri = new Uri($"https://{call.Shard.Value}.api.riotgames.com{methodUri}");

            // Read from cache
            string? json = await Cache.GetValueAsync(call.Method, HttpUtility.UrlEncode(methodUri))
                .ConfigureAwait(false);

            if (json != null)
            {
                var data = JsonSerializer.Deserialize<T>(json) ?? throw new DataDeserializeException();

                return data;
            }

            // Setup HTTP request message with headers
            var message = new HttpRequestMessage(HttpMethod.Get, uri);
            var key = ApiConfiguration.Credentials.Key;

            message.Headers.Add("X-Riot-Token", key);
            foreach (KeyValuePair<string, string> kvp in call.Headers)
                message.Headers.Add(kvp.Key, kvp.Value);

            // Initialize lock per shard
            if (!Locks.TryGetValue(call.Shard.Value, out _))
            {
                Locks[call.Shard.Value] = new SemaphoreSlim(1, 1);
            }

            return await SendRequestAsync<T>(call, methodUri, message)
                .ConfigureAwait(false);
        }

        protected async Task<T> CallStaticAsync<T>(DataCall call)
        {
            if (call.Url == null)
                throw new InvalidOperationException("Url must be set!");

            var method = new NamedFormatter(call.Method);
            var methodUri = method.Format(call.Params);
            var uri = new Uri($"{call.Url}{methodUri}");

            string? json = await Cache.GetValueAsync(call.Method, HttpUtility.UrlEncode(methodUri))
                .ConfigureAwait(false);

            if (json != null)
            {
                var data = JsonSerializer.Deserialize<T>(json) ?? throw new DataDeserializeException();

                return data;
            }

            var message = new HttpRequestMessage(HttpMethod.Get, uri);

            return await SendRequestAsync<T>(call, methodUri, message, true)
                .ConfigureAwait(false);
        }

        private async Task<T> SendRequestAsync<T>(DataCall call, string methodUri, HttpRequestMessage message, bool isStatic = false)
        {
            var _lock = Locks[call.Shard!.Value];

            // Send HTTP request
            try
            {
                await _lock.WaitAsync()
                    .ConfigureAwait(false);

                // Process request limit
                if (!isStatic)
                {
                    await Limiter.ProcessRequestAsync(call, message)
                        .ConfigureAwait(false);
                }

                // Retry request if status code is 5XX
                int attempts = 3;
                for (int i = 0; i < attempts; i++)
                {
                    var res = await ApiConfiguration.Http.SendAsync(message)
                        .ConfigureAwait(false);

                    if ((int)res.StatusCode >= 500)
                    {
                        continue;
                    }
                    else if (!res.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException(null, null, res.StatusCode);
                    }

                    var content = await res.Content.ReadAsStringAsync()
                        .ConfigureAwait(false);

                    var data = JsonSerializer.Deserialize<T>(content, Serializer.Options) ?? throw new DataDeserializeException();

                    // Write to cache
                    await Cache.SetValueAsync(HttpUtility.UrlEncode(methodUri), data)
                        .ConfigureAwait(false);

                    // Process response limit
                    if (!isStatic)
                    {
                        Limiter.ProcessResponse(call, res);
                    }

                    return data;
                }

                throw new RetryingException();
            }
            finally
            {
                _lock.Release();
            }
        }

        private U Deserialize<U>(JsonObject obj)
        {
            var value = JsonSerializer.Deserialize<U>(obj, Serializer.Options) ?? throw new DataDeserializeException();

            return value;
        }

        private U? DeserializeNode<U>(JsonNode node)
        {
            if (node is JsonObject obj)
                return JsonSerializer.Deserialize<U>(obj.AsObject(), Serializer.Options);
            if (node is JsonArray array)
                return JsonSerializer.Deserialize<U>(array.AsArray(), Serializer.Options);
            if (node is JsonValue value)
                return JsonSerializer.Deserialize<U>(value.AsValue(), Serializer.Options);

            throw new DataDeserializeException();
        }
    }
}