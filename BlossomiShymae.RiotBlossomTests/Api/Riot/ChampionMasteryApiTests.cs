using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.ChampionMastery;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class ChampionMasteryApiTests
    {
        public static SummonerDto summoner = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IRiotBlossomClient client = StubConfig.Client;

            summoner = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        public async Task Api_WithSummonerId_ShouldReturnChampionMasteryDtoCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<ChampionMasteryDto> dtoCollection = await client.Riot.ChampionMastery.ListBySummonerIdAsync(StubConfig.SummonerPlatform, summoner.Id);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<ChampionMasteryDto>));
        }

        [TestMethod()]
        public async Task Api_WithSummonerId_ShouldReturnTopChampionMasteryDtoCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<ChampionMasteryDto> dtoCollection = await client.Riot.ChampionMastery.ListTopBySummonerIdAsync(StubConfig.SummonerPlatform, summoner.Id);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<ChampionMasteryDto>));
        }

        [TestMethod()]
        public async Task Api_WithSummonerId_ShouldReturnTotalScore()
        {
            IRiotBlossomClient client = StubConfig.Client;

            int totalScore = await client.Riot.ChampionMastery.GetTotalScoreBySummonerIdAsync(StubConfig.SummonerPlatform, summoner.Id);

            Assert.IsInstanceOfType(totalScore, typeof(int));
        }

        [TestMethod()]
        public async Task Api_WithSummonerIdAndChampionId_ShouldChampionMasteryDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            // Get mastery using RiotBlossom's champion ID.
            ChampionMasteryDto dto = await client.Riot.ChampionMastery.GetBySummonerIdAndChampionIdAsync(StubConfig.SummonerPlatform, summoner.Id, 887);

            Assert.IsInstanceOfType(dto, typeof(ChampionMasteryDto));
        }
    }
}
