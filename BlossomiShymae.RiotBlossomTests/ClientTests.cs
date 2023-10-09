using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Client;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests
{
    [TestClass()]
    public class ClientTests
    {
        public static readonly IRiotBlossomClient Client = new RiotBlossomClient(new()
        {
            Lol = Environment.GetEnvironmentVariable("RIOT_API_KEY")
                ?? throw new InvalidOperationException("API key must be set for testing!")
        });

        [TestMethod()]
        public async Task Client_WithName_WillRespectLimiter()
        {
            var summoner = await Client.SummonerV4.GetByNameAsync(LeagueShard.NA1, "TheDrone7");

            var index = 0;
            var count = 100;
            var matches = new List<MatchDto>();
            var regionShard = LeagueShard.NA1.GetRegionShard();

            for (int i = 0; i < 2; i++)
            {
                var list = await Client.MatchV5.GetMatchlistByPuuidAsync(regionShard, summoner.Puuid, index, count);
                
                foreach (var id in list)
                {
                    var match = await Client.MatchV5.GetByIdAsync(regionShard, id);

                    matches.Add(match);
                }

                index += count;
            }

            Assert.IsTrue(matches.Count > 0);
        }
    }
}