using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.Summoner;
using Gwen.Type;
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
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			summoner = await gwen.Riot.Summoner.GetByNameAsync(PlatformRoute.NorthAmerica, "uwuie time");
		}

		[TestMethod()]
		public async Task Api_WithAccountId_ShouldReturnSummonerDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			SummonerDto dto = await gwen.Riot.Summoner.GetByAccountIdAsync(PlatformRoute.NorthAmerica, summoner.AccountId);

			Assert.IsInstanceOfType(dto, typeof(SummonerDto));
		}

		[TestMethod()]
		public async Task Api_WithSummonerName_ShouldReturnSummonerDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			SummonerDto dto = await gwen.Riot.Summoner.GetByNameAsync(PlatformRoute.NorthAmerica, "uwuie time");

			Assert.IsInstanceOfType(dto, typeof(SummonerDto));
		}

		[TestMethod()]
		public async Task Api_WithSummonerPuuid_ShouldReturnSummonerDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			SummonerDto dto = await gwen.Riot.Summoner.GetByPuuidAsync(PlatformRoute.NorthAmerica, summoner.Puuid);

			Assert.IsInstanceOfType(dto, typeof(SummonerDto));
		}

		[TestMethod()]
		public async Task Api_WithSummonerId_ShouldReturnSummonerDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			SummonerDto dto = await gwen.Riot.Summoner.GetByIdAsync(PlatformRoute.NorthAmerica, summoner.Id);

			Assert.IsInstanceOfType(dto, typeof(SummonerDto));
		}
	}
}