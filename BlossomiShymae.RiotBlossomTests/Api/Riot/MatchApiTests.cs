using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Match;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Exception;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class MatchApiTests
    {
        public static SummonerDto summoner = default!;
        public static string matchId = default!;
        public static RegionalRoute corruptedMatchRegion = RegionalRoute.Americas;
        public static string corruptedMatchId = "LA1_1364255918";

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IRiotBlossomClient client = StubConfig.Client;

            summoner = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
            matchId = (await client.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerRegion, summoner.Puuid)).First();
        }

        [TestMethod()]
        public async Task Api_WithQueryOptions_ShouldReturnMatchIdCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<string> ids = await client.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerRegion, summoner.Puuid, new BlossomiShymae.RiotBlossom.Api.Riot.ListIdsByPuuidAsyncOptions
            {
                Count = 100,
                Start = 0,
            });

            Assert.AreEqual(ids.Count, 100);
        }

        [TestMethod()]
        [ExpectedException(typeof(CorruptedMatchException))]
        public async Task Api_WithCorruptedMatchId_ShouldThrowExceptionForMatchDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            MatchDto dto = await client.Riot.Match.GetByIdAsync(corruptedMatchRegion, corruptedMatchId);
        }

        [TestMethod()]
        [ExpectedException(typeof(CorruptedMatchException))]
        public async Task Api_WithCorruptedMatchId_ShouldThrowExceptionForMatchTimelineDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            MatchTimelineDto dto = await client.Riot.Match.GetTimelineByIdAsync(corruptedMatchRegion, corruptedMatchId);
        }

        [TestMethod()]
        public async Task Api_WithSummonerPuuid_ShouldReturnMatchIdCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<string> ids = await client.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerRegion, summoner.Puuid);

            Assert.IsInstanceOfType(ids, typeof(ImmutableList<string>));
        }

        [TestMethod()]
        public async Task Api_WithId_ShouldReturnMatchDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            MatchDto dto = await client.Riot.Match.GetByIdAsync(StubConfig.SummonerRegion, matchId);

            Assert.IsInstanceOfType(dto, typeof(MatchDto));
        }

        [TestMethod()]
        public async Task Api_WithId_ShouldReturnMatchTimelineDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            MatchTimelineDto dto = await client.Riot.Match.GetTimelineByIdAsync(StubConfig.SummonerRegion, matchId);

            Assert.IsInstanceOfType(dto, typeof(MatchTimelineDto));
        }
    }
}
