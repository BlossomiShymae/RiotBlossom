using System.Collections.Concurrent;
using System.Runtime.Caching;

namespace BlossomiShymae.RiotBlossom.Middleware
{
    /// <summary>
    /// The default middleware implementation for caching associated response data. Data will be 
    /// removed when the cache count limit is reached. Data will also expire after a determined amount
    /// of time passes.
    /// </summary>
    public class InMemoryCache : IRequestMiddleware, IResponseMiddleware
    {
        /// <summary>
        /// The maximum amount of items permitted to the cache.
        /// </summary>
        public long Size { get; init; } = 1000;
        /// <summary>
        /// The expiration of a cache item in hours.
        /// </summary>
        public int Expiration { get; init; } = 2;
        private readonly MemoryCache _cache;
        private readonly ConcurrentDictionary<string, long> _counter = new();

        private InMemoryCache()
        {
            _cache = new("RiotBlossom");
        }

        public InMemoryCache(string name)
        {
            _cache = new(name);
        }

        public Task UseRequestAsync(ExecuteInfo info, HttpRequestMessage req, Action next, Action<byte[]> hit)
        {
            string key = req.RequestUri?.OriginalString ?? string.Empty;
            bool isHit = false;

            if (!string.IsNullOrEmpty(key))
            {
                try
                {
                    var res = (byte[])_cache[key];
                    if (res != null)
                    {
                        isHit = true;
                        bool isValue = _counter.TryGetValue(key, out long count);
                        if (isValue)
                            _counter[key] = count + 1;
                        else
                            _counter[key] = 0;

                        hit(res);
                    }
                    else
                    {
                        _counter.TryRemove(key, out long _);
                    }
                }
                catch (System.Exception) { }
            }
            if (!isHit)
                next();
            return Task.CompletedTask;
        }

        public async Task UseResponseAsync(ExecuteInfo info, HttpResponseMessage res, Action next)
        {

            string key = res.RequestMessage?.RequestUri?.OriginalString ?? string.Empty;
            if (!string.IsNullOrEmpty(key) && res.IsSuccessStatusCode)
            {
                // Remove items from the cache that are the less used
                if (_cache.GetCount() > Size)
                {
                    var items = _counter
                        .ToList()
                        .OrderBy(x => x.Value)
                        .Take((int)(Size / 5));

                    foreach (var item in items)
                    {
                        _cache.Remove(item.Key);
                        _counter.TryRemove(item);
                    }
                }

                if (res.IsSuccessStatusCode)
                {
                    byte[] data = await res.Content.ReadAsByteArrayAsync();
                    _cache.Add(key, data, new CacheItemPolicy
                    {
                        AbsoluteExpiration = DateTimeOffset.Now.AddHours(Expiration)
                    });
                }
            }
            next();
        }
    }
}
