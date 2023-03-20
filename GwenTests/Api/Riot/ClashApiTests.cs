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
			ISimpleWrapper gwen = StubConfig.SimpleWrapper;

			summoner = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
		}

		[TestMethod()]
		public async Task Api_ByDefault_ShouldReturnTournamentDtoCollection()
		{
			ISimpleWrapper gwen = StubConfig.SimpleWrapper;

			ReadOnlyCollection<TournamentDto> dtoCollection = await gwen.Riot.Clash.ListActiveTournamentsAsync(PlatformRoute.NorthAmerica);

			Assert.IsInstanceOfType(dtoCollection, typeof(ReadOnlyCollection<TournamentDto>));
		}

		[TestMethod()]
		public async Task Api_WithSummonerId_ShouldReturnPlayerDtoCollection()
		{
			ISimpleWrapper gwen = StubConfig.SimpleWrapper;

			ReadOnlyCollection<PlayerDto> dtoCollection = await gwen.Riot.Clash.ListPlayersBySummonerIdAsync(StubConfig.SummonerPlatform, summoner.Id);

			Assert.IsInstanceOfType(dtoCollection, typeof(ReadOnlyCollection<PlayerDto>));
		}


	}
}
