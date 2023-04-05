using BlossomiShymae.RiotBlossom.Core.Wrapper;
using BlossomiShymae.RiotBlossom.Dto.Riot.LolChallenges;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class LolChallengesApiTests
    {
        public static SummonerDto summoner = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IRiotBlossomClient client = StubConfig.Client;

            summoner = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnPercentiles()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableDictionary<string, ImmutableDictionary<string, double>> percentiles = await client.Riot.LolChallenges.GetPercentilesAsync(PlatformRoute.NorthAmerica);

            Assert.IsInstanceOfType(percentiles, typeof(ImmutableDictionary<string, ImmutableDictionary<string, double>>));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnChallengeConfigInfoDtoCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<ChallengeConfigInfoDto> dtoCollection = await client.Riot.LolChallenges.ListConfigInfosAsync(PlatformRoute.NorthAmerica);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<ChallengeConfigInfoDto>));
        }

        [TestMethod()]
        public async Task Api_WithId_ShouldReturnChallengeConfigDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ChallengeConfigInfoDto dto = await client.Riot.LolChallenges.GetConfigInfoByIdAsync(PlatformRoute.NorthAmerica, 301200);

            Assert.IsInstanceOfType(dto, typeof(ChallengeConfigInfoDto));
        }

        [TestMethod()]
        public async Task Api_WithId_ShouldReturnPercentiles()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableDictionary<string, double> percentiles = await client.Riot.LolChallenges.GetPercentilesByIdAsync(PlatformRoute.NorthAmerica, 301200);

            Assert.IsInstanceOfType(percentiles, typeof(ImmutableDictionary<string, double>));
        }

        [TestMethod()]
        public async Task Api_WithSummonerPuuid_ShouldReturnPlayerInfoDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            PlayerInfoDto dto = await client.Riot.LolChallenges.GetPlayerInfoByPuuidAsync(StubConfig.SummonerPlatform, summoner.Puuid);

            Assert.IsInstanceOfType(dto, typeof(PlayerInfoDto));
        }

        [TestMethod()]
        public async Task Api_WithId_ShouldReturnApexPlayerInfoDtoCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<ApexPlayerInfoDto> dtoCollection = await client.Riot.LolChallenges.ListApexPlayerInfosAsync(PlatformRoute.NorthAmerica, ChallengeLevel.Grandmaster, 2022018);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<ApexPlayerInfoDto>));
        }
    }
}
