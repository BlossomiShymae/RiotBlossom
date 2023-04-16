using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Dto.Riot.TftMatch;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class TftMatchApiTests
    {
        public static SummonerDto Summoner = default!;
        public static string MatchId = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext context)
        {
            IRiotBlossomClient client = StubConfig.Client;

            Summoner = await client.Riot.TftSummoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
            MatchId = (await client.Riot.TftMatch.ListIdsByPuuidAsync(StubConfig.SummonerPlatform, Summoner.Puuid)).First();
        }

        [TestMethod()]
        public async Task Api_WithPuuid_ShouldReturnMatchIdList()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<string> ids = await client.Riot.TftMatch.ListIdsByPuuidAsync(StubConfig.SummonerPlatform, Summoner.Puuid);

            Assert.IsInstanceOfType(ids, typeof(ImmutableList<string>));
        }

        [TestMethod()]
        public async Task Api_WithId_ShouldReturnMatchDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            MatchDto dto = await client.Riot.TftMatch.GetByIdAsync(StubConfig.SummonerPlatform, MatchId);

            Assert.IsInstanceOfType(dto, typeof(MatchDto));
        }

        [TestMethod()]
        public async Task Api_WithQueryOptions_ShouldReturnMatchIdCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<string> ids = await client.Riot.TftMatch.ListIdsByPuuidAsync(StubConfig.SummonerPlatform, Summoner.Puuid, new()
            {
                Count = 100,
                Start = 0
            });

            Assert.IsTrue(ids.Count <= 100);
        }
    }
}
