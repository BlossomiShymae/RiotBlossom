using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Cache
{
    public class EmptyCache : Cache
    {
        public EmptyCache(CacheTTLConfiguration cacheTTLConfiguration) : base(cacheTTLConfiguration)
        {
        }

        protected async override Task<string?> ReadAsync(string key)
        {
            return await Task.FromResult(string.Empty)
                .ConfigureAwait(false);
        }

        protected override Task WriteAsync(string key, object value)
        {
            return Task.CompletedTask;
        }
    }
}