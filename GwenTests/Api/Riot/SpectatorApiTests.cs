using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.Spectator;
using Gwen.Dto.Riot.Summoner;
using Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GwenTests.Api.Riot
{
	[TestClass()]
	public class SpectatorApiTests
	{
		public static SummonerDto summoner = default!;

		[ClassInitialize()]
		public static async Task Initialize(TestContext testContext)
		{
			IGwenClient gwen = StubConfig.SimpleWrapper;

			summoner = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
		}

		[TestMethod()]
		public async Task Api_WithSummonerId_ShouldReturnCurrentGameInfo()
		{
			IGwenClient gwen = StubConfig.SimpleWrapper;

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
			IGwenClient gwen = StubConfig.SimpleWrapper;

			FeaturedGames games = await gwen.Riot.Spectator.GetFeaturedGamesAsync(PlatformRoute.NorthAmerica);

			Assert.IsInstanceOfType(games, typeof(FeaturedGames));
		}
	}
}
