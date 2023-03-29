using System.Collections.Immutable;
using BlossomiShymae.Gwen.Core.Wrapper;
using BlossomiShymae.Gwen.Dto.Riot.Match;
using BlossomiShymae.Gwen.Dto.Riot.Summoner;
using BlossomiShymae.Gwen.PException;
using BlossomiShymae.Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GwenTests.Api.Riot
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
            IGwenClient gwen = StubConfig.Gwen;

            summoner = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
            matchId = (await gwen.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerRegion, summoner.Puuid)).First();
        }

        [TestMethod()]
        public async Task Api_WithQueryOptions_ShouldReturnMatchIdCollection()
        {
            IGwenClient gwen = StubConfig.Gwen;

            ImmutableList<string> ids = await gwen.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerRegion, summoner.Puuid, new BlossomiShymae.Gwen.Api.Riot.ListIdsByPuuidAsyncOptions
            {
                Count = 100,
                Start = 0,
            });

            Assert.AreEqual(ids.Count, 100);
        }

        [TestMethod()]
        [ExpectedException(typeof(GwenCorruptedMatchException))]
        public async Task Api_WithCorruptedMatchId_ShouldThrowExceptionForMatchDto()
        {
            IGwenClient gwen = StubConfig.Gwen;

            MatchDto dto = await gwen.Riot.Match.GetByIdAsync(corruptedMatchRegion, corruptedMatchId);
        }

        [TestMethod()]
        [ExpectedException(typeof(GwenCorruptedMatchException))]
        public async Task Api_WithCorruptedMatchId_ShouldThrowExceptionForMatchTimelineDto()
        {
            IGwenClient gwen = StubConfig.Gwen;

            MatchTimelineDto dto = await gwen.Riot.Match.GetTimelineByIdAsync(corruptedMatchRegion, corruptedMatchId);
        }

        [TestMethod()]
        public async Task Api_WithSummonerPuuid_ShouldReturnMatchIdCollection()
        {
            IGwenClient gwen = StubConfig.Gwen;

            ImmutableList<string> ids = await gwen.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerRegion, summoner.Puuid);

            Assert.IsInstanceOfType(ids, typeof(ImmutableList<string>));
        }

        [TestMethod()]
        public async Task Api_WithId_ShouldReturnMatchDto()
        {
            IGwenClient gwen = StubConfig.Gwen;

            MatchDto dto = await gwen.Riot.Match.GetByIdAsync(StubConfig.SummonerRegion, matchId);

            Assert.IsInstanceOfType(dto, typeof(MatchDto));
        }

        [TestMethod()]
        public async Task Api_WithId_ShouldReturnMatchTimelineDto()
        {
            IGwenClient gwen = StubConfig.Gwen;

            MatchTimelineDto dto = await gwen.Riot.Match.GetTimelineByIdAsync(StubConfig.SummonerRegion, matchId);

            Assert.IsInstanceOfType(dto, typeof(MatchTimelineDto));
        }
    }
}
