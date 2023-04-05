﻿using BlossomiShymae.RiotBlossom.Core.Wrapper;
using BlossomiShymae.RiotBlossom.Dto.Riot.Spectator;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class SpectatorApiTests
    {
        public static SummonerDto summoner = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IRiotBlossomClient client = StubConfig.Client;

            summoner = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        public async Task Api_WithSummonerId_ShouldReturnCurrentGameInfo()
        {
            IRiotBlossomClient client = StubConfig.Client;

            try
            {
                CurrentGameInfo info = await client.Riot.Spectator.GetCurrentGameInfoBySummonerIdAsync(StubConfig.SummonerPlatform, summoner.Id);

                Assert.IsInstanceOfType(info, typeof(CurrentGameInfo));
            }
            catch (InvalidOperationException ex)
            {
                if (!ex.Message.Contains("404"))
                    Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnFeaturedGames()
        {
            IRiotBlossomClient client = StubConfig.Client;

            FeaturedGames games = await client.Riot.Spectator.GetFeaturedGamesAsync(PlatformRoute.NorthAmerica);

            Assert.IsInstanceOfType(games, typeof(FeaturedGames));
        }
    }
}