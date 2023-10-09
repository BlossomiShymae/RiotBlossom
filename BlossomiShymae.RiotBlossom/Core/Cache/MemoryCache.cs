using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Cache
{
    public class MemoryCache : Cache
    {
        private readonly ConcurrentDictionary<string, string> _cache = new();

        public MemoryCache(CacheTTLConfiguration cacheTTLConfiguration) : base(cacheTTLConfiguration)
        {
        }

        protected async override Task<string?> ReadAsync(string key)
        {
            var json = _cache[key];

            return await Task.FromResult(json)
                .ConfigureAwait(false);
        }

        protected override Task WriteAsync(string key, object value)
        {
            _cache[key] = JsonSerializer.Serialize(value);

            return Task.CompletedTask;
        }
    }
}