using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Cache
{
    public class CacheFactory
    {
        public static Cache Create(CacheProvider cacheProvider)
        {
            var configuration = new CacheTTLConfiguration();

            return cacheProvider switch 
            {
                CacheProvider.Null => new NullCache(configuration),
                CacheProvider.Memory => new MemoryCache(configuration),
                CacheProvider.FileSystem => new FileSystemCache(configuration),
                _ => new NullCache(configuration)
            };
        }
    }
}