using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.League;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class LeagueApiTests
    {
        public static LeagueListDto leagueList = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IRiotBlossomClient client = StubConfig.Client;

            leagueList = await client.Riot.League.GetChallengerLeagueByQueueAsync(PlatformRoute.NorthAmerica, LeagueQueue.RankedSolo5x5);
        }

        [TestMethod()]
        public async Task Api_ChallengerWithQueue_ShouldReturnLeagueListDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeagueListDto dto = await client.Riot.League.GetChallengerLeagueByQueueAsync(PlatformRoute.NorthAmerica, LeagueQueue.RankedSolo5x5);

            Assert.IsInstanceOfType(dto, typeof(LeagueListDto));
        }

        [TestMethod()]
        public async Task Api_GrandmasterWithQueue_ShouldReturnLeagueListDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeagueListDto dto = await client.Riot.League.GetGrandmasterLeagueByQueueAsync(PlatformRoute.NorthAmerica, LeagueQueue.RankedSolo5x5);

            Assert.IsInstanceOfType(dto, typeof(LeagueListDto));
        }

        [TestMethod()]
        public async Task Api_MasterWithQueue_ShouldReturnLeagueListDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeagueListDto dto = await client.Riot.League.GetMasterLeagueByQueueAsync(PlatformRoute.NorthAmerica, LeagueQueue.RankedSolo5x5);

            Assert.IsInstanceOfType(dto, typeof(LeagueListDto));
        }

        [TestMethod()]
        public async Task Api_WithLeagueId_ShouldReturnLeagueListDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeagueListDto dto = await client.Riot.League.GetLeagueByIdAsync(PlatformRoute.NorthAmerica, leagueList.LeagueId);

            Assert.IsInstanceOfType(dto, typeof(LeagueListDto));
        }

        [TestMethod()]
        public async Task Api_WithLeagueTypes_ShouldReturnLeagueEntryDtoCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<LeagueEntryDto> dtoCollection = await client.Riot.League.ListLeagueEntriesAsync(PlatformRoute.NorthAmerica, LeagueQueue.RankedSolo5x5, LeagueTier.Diamond, LeagueDivision.II);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<LeagueEntryDto>));
        }

        [TestMethod()]
        public async Task Api_WithLeagueId_ShouldReturnLeagueEntryDtoCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<LeagueEntryDto> dtoCollection = await client.Riot.League.ListLeagueEntriesBySummonerIdAsync(PlatformRoute.NorthAmerica, leagueList.Entries.First().SummonerId);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<LeagueEntryDto>));
        }
    }
}
