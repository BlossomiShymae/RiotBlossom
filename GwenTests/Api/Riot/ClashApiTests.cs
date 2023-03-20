using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.Clash;
using Gwen.Dto.Riot.Summoner;
using Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace GwenTests.Api.Riot
{
	[TestClass()]
	public class ClashApiTests
	{
		public static SummonerDto summoner = default!;

		[ClassInitialize()]
		public static async Task Initialize(TestContext testContext)
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			summoner = await gwen.Riot.Summoner.GetByNameAsync(PlatformRoute.NorthAmerica, "uwuie time");
		}

		[TestMethod()]
		public async Task Api_ByDefault_ShouldReturnTournamentDtoCollection()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ReadOnlyCollection<TournamentDto> dtoCollection = await gwen.Riot.Clash.ListActiveTournamentsAsync(PlatformRoute.NorthAmerica);

			Assert.IsInstanceOfType(dtoCollection, typeof(ReadOnlyCollection<TournamentDto>));
		}

		[TestMethod()]
		public async Task Api_WithSummonerId_ShouldReturnPlayerDtoCollection()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ReadOnlyCollection<PlayerDto> dtoCollection = await gwen.Riot.Clash.ListPlayersBySummonerIdAsync(PlatformRoute.NorthAmerica, summoner.Id);

			Assert.IsInstanceOfType(dtoCollection, typeof(ReadOnlyCollection<PlayerDto>));
		}


	}
}
