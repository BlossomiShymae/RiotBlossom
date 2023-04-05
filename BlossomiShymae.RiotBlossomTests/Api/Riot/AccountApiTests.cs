using BlossomiShymae.RiotBlossom.Core.Wrapper;
using BlossomiShymae.RiotBlossom.Dto.Riot.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class AccountApiTests
    {
        public static AccountDto account = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IRiotBlossomClient client = StubConfig.Client;

            account = await client.Riot.Account.GetAccountByRiotIdAsync(StubConfig.SummonerRegion, StubConfig.SummonerName, StubConfig.SummonerTagLine);
        }

        [TestMethod()]
        public async Task Api_WithPuuid_ShouldReturnAccountDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            AccountDto dto = await client.Riot.Account.GetAccountByPuuidAsync(StubConfig.SummonerRegion, account.Puuid);

            Assert.IsInstanceOfType(dto, typeof(AccountDto));
        }

        [TestMethod()]
        public async Task Api_WithRiotId_ShouldReturnAccountDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            AccountDto dto = await client.Riot.Account.GetAccountByRiotIdAsync(StubConfig.SummonerRegion, StubConfig.SummonerName, StubConfig.SummonerTagLine);

            Assert.IsInstanceOfType(dto, typeof(AccountDto));
        }
    }
}
