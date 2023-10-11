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
        public CacheTTLConfiguration TTLConfiguration { get; }

        protected Cache(CacheTTLConfiguration cacheTTLConfiguration)
        {
            TTLConfiguration = cacheTTLConfiguration;
        }

        /// <summary>
        /// Get a JSON string data from cache.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async virtual Task<string?> GetValueAsync(string key)
        {
            if (!Monitors.TryGetValue(key, out CacheMonitor? value))
            {
                return default;
            }

            try
            {
                await value.Lock.WaitAsync()
                    .ConfigureAwait(false);

                // Hit
                if (!value.IsExpired && !value.IsDisrupted)
                {
                    var data = await ReadAsync(key)
                        .ConfigureAwait(false);

                    return data;
                }

                if (value.IsExpired)
                {
                    value.Timestamp = DateTime.Now;
                }

                value.IsDisrupted = false;

                return default;
            }
            catch (Exception)
            {
                value.IsDisrupted = true;

                return default;
            }
            finally
            {
                value.Lock.Release();
            }
        }

        public async virtual Task SetValueAsync(string hint, string key, object value)
        {
            if (!Monitors.ContainsKey(key))
            {
                Monitors[key] = new()
                {
                    TTL = TTLConfiguration.GetTTL(hint)
                };
            }

            try
            {
                await Monitors[key].Lock.WaitAsync()
                    .ConfigureAwait(false);

                await WriteAsync(key, value)
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {
                Monitors[key].IsDisrupted = true;
            }
            finally
            {
                Monitors[key].Lock.Release();
            }
            
        }

        public virtual async Task ClearAsync(string key)
        {
            if (Monitors.TryGetValue(key, out CacheMonitor? monitor))
            {
                try
                {
                    await monitor.Lock.WaitAsync()
                        .ConfigureAwait(false);

                    monitor.Timestamp = DateTime.MinValue;
                }
                catch (Exception)
                {

                }
                finally
                {
                    monitor.Lock.Release();
                }
            }
        }

        public virtual async Task ClearAsync()
        {
            foreach (var kv in Monitors)
            {
                if (kv.Value is CacheMonitor monitor)
                {
                    try
                    {
                        await monitor.Lock.WaitAsync()
                            .ConfigureAwait(false);

                        monitor.Timestamp = DateTime.MinValue;
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        monitor.Lock.Release();
                    }
                }
            }
        }

        protected abstract Task<string?> ReadAsync(string key);
        protected abstract Task WriteAsync(string key, object value);
    }
}