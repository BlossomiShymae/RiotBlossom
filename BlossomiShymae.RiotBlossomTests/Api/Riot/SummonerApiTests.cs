using BlossomiShymae.RiotBlossom.Core.Wrapper;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class SummonerApiTests
    {
        public static SummonerDto summoner = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IRiotBlossomClient client = StubConfig.Client;

            summoner = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        public async Task Api_WithAccountId_ShouldReturnSummonerDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            SummonerDto dto = await client.Riot.Summoner.GetByAccountIdAsync(StubConfig.SummonerPlatform, summoner.AccountId);

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }

        [TestMethod()]
        public async Task Api_WithSummonerName_ShouldReturnSummonerDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            SummonerDto dto = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }

        [TestMethod()]
        public async Task Api_WithSummonerPuuid_ShouldReturnSummonerDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            SummonerDto dto = await client.Riot.Summoner.GetByPuuidAsync(StubConfig.SummonerPlatform, summoner.Puuid);

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }

        [TestMethod()]
        public async Task Api_WithSummonerId_ShouldReturnSummonerDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            SummonerDto dto = await client.Riot.Summoner.GetByIdAsync(StubConfig.SummonerPlatform, summoner.Id);

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }
    }
}