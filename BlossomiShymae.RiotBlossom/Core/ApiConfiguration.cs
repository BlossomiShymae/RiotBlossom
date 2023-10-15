using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Core.Cache;
using BlossomiShymae.RiotBlossom.Core.Limiting;
using Microsoft.Extensions.Logging;

namespace BlossomiShymae.RiotBlossom.Core
{
    public class ApiConfiguration
    {
        public string? Key { get; set; }
        public HttpClient Http { get; set; } = new();
        public Cache.Cache Cache { get; set; } = CacheFactory
            .Create(CacheProvider.Memory);
        public Limiter Limiter { get; set; } = LimiterFactory
            .Create(LimiterProvider.Burst);
        public ILogger Logger { get; set; } = LoggerFactory
            .Create(c => 
            {
                c.AddConsole();
                c.SetMinimumLevel(LogLevel.Debug);
            })
            .CreateLogger("RiotBlossom");
    }
}