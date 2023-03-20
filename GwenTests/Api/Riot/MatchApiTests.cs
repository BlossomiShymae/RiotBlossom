using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.Match;
using Gwen.Dto.Riot.Summoner;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

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
			IGwenClient gwen = StubConfig.Gwen;

			summoner = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
			matchId = (await gwen.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerRegion, summoner.Puuid)).First();
		}

		[TestMethod()]
		public async Task Api_WithSummonerPuuid_ShouldReturnMatchIdCollection()
		{
			IGwenClient gwen = StubConfig.Gwen;

			ImmutableList<string> ids = await gwen.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerRegion, summoner.Puuid);

			Assert.IsInstanceOfType(ids, typeof(ImmutableList<string>));
		}

		[TestMethod()]
		public async Task Api_WithId_ShouldReturnMatchDto()
		{
			IGwenClient gwen = StubConfig.Gwen;

			MatchDto dto = await gwen.Riot.Match.GetByIdAsync(StubConfig.SummonerRegion, matchId);

			Assert.IsInstanceOfType(dto, typeof(MatchDto));
		}

		[TestMethod()]
		public async Task Api_WithId_ShouldReturnMatchTimelineDto()
		{
			IGwenClient gwen = StubConfig.Gwen;

			MatchTimelineDto dto = await gwen.Riot.Match.GetTimelineByIdAsync(StubConfig.SummonerRegion, matchId);

			Assert.IsInstanceOfType(dto, typeof(MatchTimelineDto));
		}
	}
}
