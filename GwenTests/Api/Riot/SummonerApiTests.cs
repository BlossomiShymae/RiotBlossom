using Gwen.Dto.Riot.Summoner;
using Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GwenTests.Api.Riot
{
	[TestClass()]
	public class SummonerApiTests
	{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public static SummonerDto summoner;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		[ClassInitialize()]
		public static async Task Initialize(TestContext testContext)
		{
			var gwen = StubClient.SimpleWrapper;

			summoner = await gwen.Riot.Summoner.GetByNameAsync(PlatformRoute.NorthAmerica, "uwuie time");
		}

		[TestMethod()]
		public async Task Api_WithAccountId_ShouldReturnSummonerDto()
		{
			var gwen = StubClient.SimpleWrapper;

			var summonerDto = await gwen.Riot.Summoner.GetByAccountIdAsync(PlatformRoute.NorthAmerica, summoner.AccountId);

			Assert.IsInstanceOfType(summonerDto, typeof(SummonerDto));
		}

		[TestMethod()]
		public async Task Api_WithSummonerName_ShouldReturnSummonerDto()
		{
			var gwen = StubClient.SimpleWrapper;

			var summonerDto = await gwen.Riot.Summoner.GetByNameAsync(PlatformRoute.NorthAmerica, "uwuie time");

			Assert.IsInstanceOfType(summonerDto, typeof(SummonerDto));
		}

		[TestMethod()]
		public async Task Api_WithSummonerPuuid_ShouldReturnSummonerDto()
		{
			var gwen = StubClient.SimpleWrapper;

			var summonerDto = await gwen.Riot.Summoner.GetByPuuidAsync(PlatformRoute.NorthAmerica, summoner.Puuid);

			Assert.IsInstanceOfType(summonerDto, typeof(SummonerDto));
		}

		[TestMethod()]
		public async Task Api_WithSummonerId_ShouldReturnSummonerDto()
		{
			var gwen = StubClient.SimpleWrapper;

			var summonerDto = await gwen.Riot.Summoner.GetByIdAsync(PlatformRoute.NorthAmerica, summoner.Id);

			Assert.IsInstanceOfType(summonerDto, typeof(SummonerDto));
		}
	}
}