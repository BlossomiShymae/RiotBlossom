using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.ChampionMastery;
using Gwen.Dto.Riot.Summoner;
using Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace GwenTests.Api.Riot
{
	[TestClass()]
	public class ChampionMasteryApiTests
	{
		public static SummonerDto summoner = default!;

		[ClassInitialize()]
		public static async Task Initialize(TestContext testContext)
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			summoner = await gwen.Riot.Summoner.GetByNameAsync(PlatformRoute.NorthAmerica, "uwuie time");
		}

		[TestMethod()]
		public async Task Api_WithSummonerId_ShouldReturnChampionMasteryDtoCollection()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ReadOnlyCollection<ChampionMasteryDto> dtoCollection = await gwen.Riot.ChampionMastery.ListBySummonerIdAsync(PlatformRoute.NorthAmerica, summoner.Id);

			Assert.IsInstanceOfType(dtoCollection, typeof(ReadOnlyCollection<ChampionMasteryDto>));
		}

		[TestMethod()]
		public async Task Api_WithSummonerId_ShouldReturnTopChampionMasteryDtoCollection()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ReadOnlyCollection<ChampionMasteryDto> dtoCollection = await gwen.Riot.ChampionMastery.ListTopBySummonerIdAsync(PlatformRoute.NorthAmerica, summoner.Id);

			Assert.IsInstanceOfType(dtoCollection, typeof(ReadOnlyCollection<ChampionMasteryDto>));
		}

		[TestMethod()]
		public async Task Api_WithSummonerId_ShouldReturnTotalScore()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			int totalScore = await gwen.Riot.ChampionMastery.GetTotalScoreBySummonerIdAsync(PlatformRoute.NorthAmerica, summoner.Id);

			Assert.IsInstanceOfType(totalScore, typeof(int));
		}

		[TestMethod()]
		public async Task Api_WithSummonerIdAndChampionId_ShouldChampionMasteryDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			// Get mastery using Gwen's champion ID.
			ChampionMasteryDto dto = await gwen.Riot.ChampionMastery.GetBySummonerIdAndChampionIdAsync(PlatformRoute.NorthAmerica, summoner.Id, 887);

			Assert.IsInstanceOfType(dto, typeof(ChampionMasteryDto));
		}
	}
}
