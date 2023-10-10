using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests
{
    [TestClass()]
    public class MethodTests
    {
        [TestMethod()]
        public async Task ChampionMasteryV4_WithSummoner_GetsMasteries()
        {
            var client = Shared.Client;
            var id = 141; // Kayn

            var masteryByPuuid = await client.ChampionMasteryV4.GetByPuuidAsync(Shared.LeagueShard, Shared.Summoner.Puuid, id);
            var masteryBySummonerId = await client.ChampionMasteryV4.GetBySummonerIdAsync(Shared.LeagueShard, Shared.Summoner.Id, id);

            var scoreByPuuid = await client.ChampionMasteryV4.GetTotalScoreByPuuidAsync(Shared.LeagueShard, Shared.Summoner.Puuid);
            var scoreBySummonerId = await client.ChampionMasteryV4.GetTotalScoreBySummonerIdAsync(Shared.LeagueShard, Shared.Summoner.Id);

            var entriesByPuuid = await client.ChampionMasteryV4.GetEntriesByPuuidAsync(Shared.LeagueShard, Shared.Summoner.Puuid);
            var entriesBySummonerId = await client.ChampionMasteryV4.GetEntriesBySummonerIdAsync(Shared.LeagueShard, Shared.Summoner.Id);

            var topByPuuid = await client.ChampionMasteryV4.GetEntriesTopByPuuidAsync(Shared.LeagueShard, Shared.Summoner.Puuid);
            var topBySummonerId = await client.ChampionMasteryV4.GetEntriesTopBySummonerIdAsync(Shared.LeagueShard, Shared.Summoner.Id);

            Assert.IsTrue(masteryByPuuid.ChampionPoints > 0 && masteryByPuuid.ChampionPoints == masteryBySummonerId.ChampionPoints);
            Assert.IsTrue(scoreByPuuid == scoreBySummonerId);
            Assert.IsTrue(entriesByPuuid.Count > 0 && entriesByPuuid.Count == entriesBySummonerId.Count);
            Assert.IsTrue(topByPuuid.Count > 0 && topByPuuid.Count == topBySummonerId.Count);
        }
    }
}