using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.ChampionMastery;
using Gwen.Dto.Riot.Summoner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace GwenTests.Api.Riot
{
	[TestClass()]
	public class ChampionMasteryApiTests
	{
		public static SummonerDto summoner = default!;

		[ClassInitialize()]
		public static async Task Initialize(TestContext testContext)
		{
			ISimpleWrapper gwen = StubConfig.SimpleWrapper;

			summoner = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
		}

		[TestMethod()]
		public async Task Api_WithSummonerId_ShouldReturnChampionMasteryDtoCollection()
		{
			ISimpleWrapper gwen = StubConfig.SimpleWrapper;

			ImmutableList<ChampionMasteryDto> dtoCollection = await gwen.Riot.ChampionMastery.ListBySummonerIdAsync(StubConfig.SummonerPlatform, summoner.Id);

			Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<ChampionMasteryDto>));
		}

		[TestMethod()]
		public async Task Api_WithSummonerId_ShouldReturnTopChampionMasteryDtoCollection()
		{
			ISimpleWrapper gwen = StubConfig.SimpleWrapper;

			ImmutableList<ChampionMasteryDto> dtoCollection = await gwen.Riot.ChampionMastery.ListTopBySummonerIdAsync(StubConfig.SummonerPlatform, summoner.Id);

			Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<ChampionMasteryDto>));
		}

		[TestMethod()]
		public async Task Api_WithSummonerId_ShouldReturnTotalScore()
		{
			ISimpleWrapper gwen = StubConfig.SimpleWrapper;

			int totalScore = await gwen.Riot.ChampionMastery.GetTotalScoreBySummonerIdAsync(StubConfig.SummonerPlatform, summoner.Id);

			Assert.IsInstanceOfType(totalScore, typeof(int));
		}

		[TestMethod()]
		public async Task Api_WithSummonerIdAndChampionId_ShouldChampionMasteryDto()
		{
			ISimpleWrapper gwen = StubConfig.SimpleWrapper;

			// Get mastery using Gwen's champion ID.
			ChampionMasteryDto dto = await gwen.Riot.ChampionMastery.GetBySummonerIdAndChampionIdAsync(StubConfig.SummonerPlatform, summoner.Id, 887);

			Assert.IsInstanceOfType(dto, typeof(ChampionMasteryDto));
		}
	}
}
