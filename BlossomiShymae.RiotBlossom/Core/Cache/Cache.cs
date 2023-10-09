using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Cache
{
    public enum CacheProvider
    {
        Empty,
        FileSystem,
        Memory
    }

    public abstract class Cache
    {
        protected readonly ConcurrentDictionary<string, CacheMonitor> Monitors = new();
        protected readonly CacheTTLConfiguration CacheTTLConfiguration;

        protected Cache(CacheTTLConfiguration cacheTTLConfiguration)
        {
            CacheTTLConfiguration = cacheTTLConfiguration;
        }

        /// <summary>
        /// Get a JSON string data from cache.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async virtual Task<string?> GetValueAsync(string hint, string key)
        {
            // Lock per key to avoid conflicting read/writes :>
            if (!Monitors.ContainsKey(key))
            {
                Monitors[key] = new()
                {
                    TTL = CacheTTLConfiguration.GetTTL(hint)
                };
            }

            try
            {
                await Monitors[key].Lock.WaitAsync()
                    .ConfigureAwait(false);

                // Hit
                if (!Monitors[key].IsExpired && !Monitors[key].IsDisrupted)
                {
                    var value = await ReadAsync(key)
                        .ConfigureAwait(false);

                    return value;
                }

                if (Monitors[key].IsExpired)
                {
                    Monitors[key].Timestamp = DateTime.Now;
                }

                // Miss
                Monitors[key].IsDisrupted = false;

                return default;
            }
            // JSON model has changed or other exception
            catch (Exception)
            {
                Monitors[key].IsDisrupted = true;

                return default;
            }
            finally
            {
                Monitors[key].Lock.Release();
            }
        }

        public async virtual Task SetValueAsync(string key, object value)
        {
            await WriteAsync(key, value)
                .ConfigureAwait(false);
        }

        public virtual void Clear(string key)
        {
            Monitors[key].TTL = TimeSpan.Zero;
        }

        protected abstract Task<string?> ReadAsync(string key);
        protected abstract Task WriteAsync(string key, object value);
    }
}