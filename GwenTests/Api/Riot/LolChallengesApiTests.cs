using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.LolChallenges;
using Gwen.Dto.Riot.Summoner;
using Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace GwenTests.Api.Riot
{
	[TestClass()]
	public class LolChallengesApiTests
	{
		public static SummonerDto summoner = default!;

		[ClassInitialize()]
		public static async Task Initialize(TestContext testContext)
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			summoner = await gwen.Riot.Summoner.GetByNameAsync(PlatformRoute.NorthAmerica, "uwuie time");
		}

		[TestMethod()]
		public async Task Api_ByDefault_ShouldReturnPercentiles()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ImmutableDictionary<string, ImmutableDictionary<string, double>> percentiles = await gwen.Riot.LolChallenges.GetPercentilesAsync(PlatformRoute.NorthAmerica);

			Assert.IsInstanceOfType(percentiles, typeof(ImmutableDictionary<string, ImmutableDictionary<string, double>>));
		}

		[TestMethod()]
		public async Task Api_ByDefault_ShouldReturnChallengeConfigInfoDtoCollection()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ImmutableList<ChallengeConfigInfoDto> dtoCollection = await gwen.Riot.LolChallenges.ListConfigInfosAsync(PlatformRoute.NorthAmerica);

			Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<ChallengeConfigInfoDto>));
		}

		[TestMethod()]
		public async Task Api_WithId_ShouldReturnChallengeConfigDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ChallengeConfigInfoDto dto = await gwen.Riot.LolChallenges.GetConfigInfoByIdAsync(PlatformRoute.NorthAmerica, 301200);

			Assert.IsInstanceOfType(dto, typeof(ChallengeConfigInfoDto));
		}

		[TestMethod()]
		public async Task Api_WithId_ShouldReturnPercentiles()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ImmutableDictionary<string, double> percentiles = await gwen.Riot.LolChallenges.GetPercentilesByIdAsync(PlatformRoute.NorthAmerica, 301200);

			Assert.IsInstanceOfType(percentiles, typeof(ImmutableDictionary<string, double>));
		}

		[TestMethod()]
		public async Task Api_WithSummonerPuuid_ShouldReturnPlayerInfoDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			PlayerInfoDto dto = await gwen.Riot.LolChallenges.GetPlayerInfoByPuuidAsync(PlatformRoute.NorthAmerica, summoner.Puuid);

			Assert.IsInstanceOfType(dto, typeof(PlayerInfoDto));
		}

		[TestMethod()]
		public async Task Api_WithId_ShouldReturnApexPlayerInfoDtoCollection()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ImmutableList<ApexPlayerInfoDto> dtoCollection = await gwen.Riot.LolChallenges.ListApexPlayerInfosAsync(PlatformRoute.NorthAmerica, ChallengeLevel.Grandmaster, 2022018);

			Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<ApexPlayerInfoDto>));
		}
	}
}
