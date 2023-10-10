using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Constants.Types;
using BlossomiShymae.RiotBlossom.Data.Constants.Types.Lol;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;

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

        [TestMethod()]
        public async Task ChampionV3_ByDefault_GetsRotation()
        {
            var info = await Shared.Client.ChampionV3.GetChampionRotations(Shared.LeagueShard);

            Assert.IsTrue(info.FreeChampionIds.Count > 0);
        }

        [TestMethod()]
        public async Task LeagueV4_WithSummoner_FetchLeagues()
        {
            var client = Shared.Client;

            var challenger = await client.LeagueV4.GetChallengerLeagueByQueueAsync(Shared.LeagueShard, LeagueQueue.RankedSolo5x5);
            var grandmaster = await client.LeagueV4.GetGrandmasterLeagueByQueueAsync(Shared.LeagueShard, LeagueQueue.RankedSolo5x5);
            var master = await client.LeagueV4.GetMasterLeagueByQueueAsync(Shared.LeagueShard, LeagueQueue.RankedSolo5x5);

            var entries = await client.LeagueV4.GetLeagueEntriesAsync(Shared.LeagueShard, LeagueQueue.RankedSolo5x5, LeagueTier.Diamond, LeagueDivision.I);
            var entriesBySummonerId = await client.LeagueV4.GetLeagueEntriesBySummonerIdAsync(Shared.LeagueShard, Shared.Summoner.Id);

            Assert.IsTrue(challenger.Entries.Count > 0);
            Assert.IsTrue(grandmaster.Entries.Count > 0);
            Assert.IsTrue(master.Entries.Count > 0);
            Assert.IsTrue(entries.Count > 0);
            Assert.IsTrue(entriesBySummonerId.Count > 0);
        }

        [TestMethod()]
        public async Task LolChallengesV1_WithSummoner_FetchChallenges()
        {
            var client = Shared.Client;

            var percentiles = await client.LolChallengesV1.GetPercentilesAsync(Shared.LeagueShard);
            var info = await client.LolChallengesV1.GetPlayerInfoByPuuidAsync(Shared.LeagueShard, Shared.Summoner.Puuid);
            var config = await client.LolChallengesV1.GetConfigInfosAsync(Shared.LeagueShard);

            Assert.IsTrue(percentiles.Count > 0);
            Assert.IsTrue(info.Challenges.Count > 0);
            Assert.IsTrue(config.Count > 0);
        }
        
        [TestMethod()]
        public async Task LolStatusV4_ByDefault_GetStatus()
        {
            var status = await Shared.Client.LolStatusV4.GetPlatformStatusAsync(Shared.LeagueShard);

            Assert.IsTrue(status != null);
        }

        [TestMethod()]
        public async Task MatchV5_WithSummoner_GetMatches()
        {
            var client = Shared.Client;

            var matchlist = await client.MatchV5.GetMatchlistByPuuidAsync(new()
            {
                Puuid = Shared.Summoner.Puuid,
                Shard = Shared.LeagueShard.GetRegionShard()
            });
            var match = await client.MatchV5.GetByIdAsync(Shared.LeagueShard.GetRegionShard(), matchlist.First());
            var timeline = await client.MatchV5.GetTimelineByIdAsync(Shared.LeagueShard.GetRegionShard(), matchlist.First());

            Assert.IsTrue(matchlist.Count > 0);
            Assert.IsTrue(match.Metadata.MatchId == timeline.Metadata.MatchId);
        }

        [TestMethod()]
        public async Task SummonerV4_WithSummoner_GetSummoners()
        {
            var client = Shared.Client;

            var summonerByPuuid = await client.SummonerV4.GetByPuuidAsync(Shared.LeagueShard, Shared.Summoner.Puuid);
            var summonerByAccountId = await client.SummonerV4.GetByAccountIdAsync(Shared.LeagueShard, Shared.Summoner.AccountId);
            var summonerById = await client.SummonerV4.GetByIdAsync(Shared.LeagueShard, Shared.Summoner.Id);
            var summonerByName = await client.SummonerV4.GetByNameAsync(Shared.LeagueShard, Shared.Summoner.Name);

            Assert.IsTrue(summonerByPuuid == summonerByAccountId);
            Assert.IsTrue(summonerByAccountId == summonerById);
            Assert.IsTrue(summonerById == summonerByName);
        }

        [TestMethod()]
        public async Task LorMatchV1_WithSummoner_GetSummoners()
        {
            var client = Shared.Client;

            var matchlist = await client.LorMatchV1.GetMatchlistByPuuidAsync(Shared.RuneterraShard, Shared.Account.Puuid);
            var match = await client.LorMatchV1.GetByIdAsync(Shared.RuneterraShard, matchlist.First());

            Assert.IsTrue(matchlist.Count > 0);
            Assert.IsTrue(match.Metadata.MatchId == matchlist.First());
        }
    }
}