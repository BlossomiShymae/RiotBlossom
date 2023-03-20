using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.Match;
using Gwen.Dto.Riot.Summoner;
using Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;

namespace GwenTests.Api.Riot
{
	[TestClass()]
	public class MatchApiTests
	{
		public static SummonerDto summoner = default!;
		public static string matchId = default!;

		[ClassInitialize()]
		public static async Task Initialize(TestContext testContext)
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			summoner = await gwen.Riot.Summoner.GetByNameAsync(PlatformRoute.NorthAmerica, "uwuie time");
			matchId = (await gwen.Riot.Match.ListIdsByPuuidAsync(RegionalRoute.Americas, summoner.Puuid)).First();
		}

		[TestMethod()]
		public async Task Api_WithSummonerPuuid_ShouldReturnMatchIdCollection()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ReadOnlyCollection<string> ids = await gwen.Riot.Match.ListIdsByPuuidAsync(RegionalRoute.Americas, summoner.Puuid);

			Assert.IsInstanceOfType(ids, typeof(ReadOnlyCollection<string>));
		}

		[TestMethod()]
		public async Task Api_WithId_ShouldReturnMatchDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			MatchDto dto = await gwen.Riot.Match.GetByIdAsync(RegionalRoute.Americas, matchId);

			Assert.IsInstanceOfType(dto, typeof(MatchDto));
		}

		[TestMethod()]
		public async Task Api_WithId_ShouldReturnMatchTimelineDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			MatchTimelineDto dto = await gwen.Riot.Match.GetTimelineByIdAsync(RegionalRoute.Americas, matchId);

			Assert.IsInstanceOfType(dto, typeof(MatchTimelineDto));
		}
	}
}
