using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Cache
{
    public class CacheMonitor
    {
        public readonly SemaphoreSlim Lock = new(1,1);
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public TimeSpan TTL { get; set; }
        public bool IsExpired => (DateTime.Now - Timestamp).TotalMilliseconds > TTL.TotalMilliseconds;
        public bool IsDisrupted { get; set; }
    }
}