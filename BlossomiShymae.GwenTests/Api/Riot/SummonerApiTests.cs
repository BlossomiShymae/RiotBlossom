﻿using BlossomiShymae.Gwen.Core.Wrapper;
using BlossomiShymae.Gwen.Dto.Riot.Summoner;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GwenTests.Api.Riot
{
    [TestClass()]
    public class SummonerApiTests
    {
        public static SummonerDto summoner = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IGwenClient gwen = StubConfig.Gwen;

            summoner = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        public async Task Api_WithAccountId_ShouldReturnSummonerDto()
        {
            IGwenClient gwen = StubConfig.Gwen;

            SummonerDto dto = await gwen.Riot.Summoner.GetByAccountIdAsync(StubConfig.SummonerPlatform, summoner.AccountId);

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }

        [TestMethod()]
        public async Task Api_WithSummonerName_ShouldReturnSummonerDto()
        {
            IGwenClient gwen = StubConfig.Gwen;

            SummonerDto dto = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }

        [TestMethod()]
        public async Task Api_WithSummonerPuuid_ShouldReturnSummonerDto()
        {
            IGwenClient gwen = StubConfig.Gwen;

            SummonerDto dto = await gwen.Riot.Summoner.GetByPuuidAsync(StubConfig.SummonerPlatform, summoner.Puuid);

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }

        [TestMethod()]
        public async Task Api_WithSummonerId_ShouldReturnSummonerDto()
        {
            IGwenClient gwen = StubConfig.Gwen;

            SummonerDto dto = await gwen.Riot.Summoner.GetByIdAsync(StubConfig.SummonerPlatform, summoner.Id);

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }
    }
}