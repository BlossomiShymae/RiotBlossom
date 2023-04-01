﻿using BlossomiShymae.Gwen.Core.Wrapper;
using BlossomiShymae.Gwen.Dto.Riot.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.GwenTests.Api.Riot
{
    [TestClass()]
    public class AccountApiTests
    {
        public static AccountDto account = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IGwenClient gwen = StubConfig.Gwen;

            account = await gwen.Riot.Account.GetAccountByRiotIdAsync(StubConfig.SummonerRegion, StubConfig.SummonerName, StubConfig.SummonerTagLine);
        }

        [TestMethod()]
        public async Task Api_WithPuuid_ShouldReturnAccountDto()
        {
            IGwenClient gwen = StubConfig.Gwen;

            AccountDto dto = await gwen.Riot.Account.GetAccountByPuuidAsync(StubConfig.SummonerRegion, account.Puuid);

            Assert.IsInstanceOfType(dto, typeof(AccountDto));
        }

        [TestMethod()]
        public async Task Api_WithRiotId_ShouldReturnAccountDto()
        {
            IGwenClient gwen = StubConfig.Gwen;

            AccountDto dto = await gwen.Riot.Account.GetAccountByRiotIdAsync(StubConfig.SummonerRegion, StubConfig.SummonerName, StubConfig.SummonerTagLine);

            Assert.IsInstanceOfType(dto, typeof(AccountDto));
        }
    }
}