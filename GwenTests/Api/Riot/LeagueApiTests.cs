using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.League;
using Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace GwenTests.Api.Riot
{
	[TestClass()]
	public class LeagueApiTests
	{
		public static LeagueListDto leagueList = default!;

		[ClassInitialize()]
		public static async Task Initialize(TestContext testContext)
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			leagueList = await gwen.Riot.League.GetChallengerLeagueByQueueAsync(PlatformRoute.NorthAmerica, LeagueQueue.RankedSolo5x5);
		}

		[TestMethod()]
		public async Task Api_ChallengerWithQueue_ShouldReturnLeagueListDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			LeagueListDto dto = await gwen.Riot.League.GetChallengerLeagueByQueueAsync(PlatformRoute.NorthAmerica, LeagueQueue.RankedSolo5x5);

			Assert.IsInstanceOfType(dto, typeof(LeagueListDto));
		}

		[TestMethod()]
		public async Task Api_GrandmasterWithQueue_ShouldReturnLeagueListDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			LeagueListDto dto = await gwen.Riot.League.GetGrandmasterLeagueByQueueAsync(PlatformRoute.NorthAmerica, LeagueQueue.RankedSolo5x5);

			Assert.IsInstanceOfType(dto, typeof(LeagueListDto));
		}

		[TestMethod()]
		public async Task Api_MasterWithQueue_ShouldReturnLeagueListDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			LeagueListDto dto = await gwen.Riot.League.GetMasterLeagueByQueueAsync(PlatformRoute.NorthAmerica, LeagueQueue.RankedSolo5x5);

			Assert.IsInstanceOfType(dto, typeof(LeagueListDto));
		}

		[TestMethod()]
		public async Task Api_WithLeagueId_ShouldReturnLeagueListDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			LeagueListDto dto = await gwen.Riot.League.GetLeagueByIdAsync(PlatformRoute.NorthAmerica, leagueList.LeagueId);

			Assert.IsInstanceOfType(dto, typeof(LeagueListDto));
		}

		[TestMethod()]
		public async Task Api_WithLeagueTypes_ShouldReturnLeagueEntryDtoCollection()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ReadOnlyCollection<LeagueEntryDto> dtoCollection = await gwen.Riot.League.ListLeagueEntriesAsync(PlatformRoute.NorthAmerica, LeagueQueue.RankedSolo5x5, LeagueTier.Diamond, LeagueDivision.II);

			Assert.IsInstanceOfType(dtoCollection, typeof(ReadOnlyCollection<LeagueEntryDto>));
		}

		[TestMethod()]
		public async Task Api_WithLeagueId_ShouldReturnLeagueEntryDtoCollection()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ReadOnlyCollection<LeagueEntryDto> dtoCollection = await gwen.Riot.League.ListLeagueEntriesBySummonerIdAsync(PlatformRoute.NorthAmerica, leagueList.Entries.First().SummonerId);

			Assert.IsInstanceOfType(dtoCollection, typeof(ReadOnlyCollection<LeagueEntryDto>));
		}
	}
}
