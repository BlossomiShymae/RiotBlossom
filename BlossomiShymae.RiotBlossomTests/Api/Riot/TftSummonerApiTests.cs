using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class TftSummonerApiTests
    {
        public static SummonerDto Summoner = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext context)
        {
            IRiotBlossomClient client = StubConfig.Client;

            Summoner = await client.Riot.TftSummoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        public async Task Api_WithAccountId_ShouldReturnSummonerDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            SummonerDto dto = await client.Riot.TftSummoner.GetByAccountIdAsync(StubConfig.SummonerPlatform, Summoner.AccountId);

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }

        [TestMethod()]
        public async Task Api_WithSummonerId_ShouldReturnSummonerDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            SummonerDto dto = await client.Riot.TftSummoner.GetByIdAsync(StubConfig.SummonerPlatform, Summoner.Id);

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }

        [TestMethod()]
        public async Task Api_WithPuuid_ShouldReturnSummonerDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            SummonerDto dto = await client.Riot.TftSummoner.GetByPuuidAsync(StubConfig.SummonerPlatform, Summoner.Puuid);

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }

        [TestMethod()]
        public async Task Api_WithSummonerName_ShouldReturnSummonerDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            SummonerDto dto = await client.Riot.TftSummoner.GetByNameAsync(StubConfig.SummonerPlatform, Summoner.Name);

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }
    }
}
