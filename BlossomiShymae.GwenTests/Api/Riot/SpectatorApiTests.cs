using BlossomiShymae.Gwen.Core.Wrapper;
using BlossomiShymae.Gwen.Dto.Riot.Spectator;
using BlossomiShymae.Gwen.Dto.Riot.Summoner;
using BlossomiShymae.Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.GwenTests.Api.Riot
{
    [TestClass()]
    public class SpectatorApiTests
    {
        public static SummonerDto summoner = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IGwenClient gwen = StubConfig.Gwen;

            summoner = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        public async Task Api_WithSummonerId_ShouldReturnCurrentGameInfo()
        {
            IGwenClient gwen = StubConfig.Gwen;

            try
            {
                CurrentGameInfo info = await gwen.Riot.Spectator.GetCurrentGameInfoBySummonerIdAsync(StubConfig.SummonerPlatform, summoner.Id);

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
            IGwenClient gwen = StubConfig.Gwen;

            FeaturedGames games = await gwen.Riot.Spectator.GetFeaturedGamesAsync(PlatformRoute.NorthAmerica);

            Assert.IsInstanceOfType(games, typeof(FeaturedGames));
        }
    }
}
