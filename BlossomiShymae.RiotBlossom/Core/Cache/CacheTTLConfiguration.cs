using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Data;

namespace BlossomiShymae.RiotBlossom.Core.Cache
{
    public class CacheTTLConfiguration
    {
        private readonly Dictionary<string, TimeSpan> _ttl = new();

        public CacheTTLConfiguration()
        {
            _ttl[UrlMethod.LolSummonerV4ByName] = TimeSpan.FromDays(7);

            _ttl[UrlMethod.LolMatchV5ByPuuid] = TimeSpan.MaxValue;
            _ttl[UrlMethod.LolMatchV5ByMatchId] = TimeSpan.FromMinutes(10);
        }

        public void SetTTL(string key, TimeSpan timeSpan)
        {
            _ttl[key] = timeSpan;
        }

        public TimeSpan GetTTL(string key)
        {
            return _ttl[key];
        }
    }
}