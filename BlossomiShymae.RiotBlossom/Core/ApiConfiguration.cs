using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Core.Cache;
using BlossomiShymae.RiotBlossom.Core.Limiting;

namespace BlossomiShymae.RiotBlossom.Core
{
    public class ApiConfiguration
    {
        public required ApiCredentials Credentials { get; set; }
        public HttpClient Http { get; set; } = new();
        public CacheProvider CacheProvider { get; set; } = CacheProvider.FileSystem;
        public CacheTTLConfiguration CacheTTLConfiguration { get; set; } = new();
        public LimiterProvider LimiterProvider { get; set; } = LimiterProvider.Burst;
    }
}