using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Limiting
{
    public class LimiterFactory
    {
        public static Limiter Create(LimiterProvider limiterProvider)
        {
            return limiterProvider switch
            {
                LimiterProvider.Empty => new EmptyLimiter(),
                LimiterProvider.Burst => new BurstLimiter(),
                LimiterProvider.Spread => new SpreadLimiter(),
                _ => new EmptyLimiter()
            };
        }
    }
}