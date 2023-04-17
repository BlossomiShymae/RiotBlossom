using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.League;
using BlossomiShymae.RiotBlossom.Dto.Riot.TftLeague;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;
using LeagueEntryDto = BlossomiShymae.RiotBlossom.Dto.Riot.TftLeague.LeagueEntryDto;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class TftLeagueApiTests
    {
        public static LeagueListDto LeagueList = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext context)
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeagueList = await client.Riot.TftLeague.GetChallengerLeagueAsync(Platform.NorthAmerica);
        }

        [TestMethod()]
        public async Task Api_Challenger_ShouldReturnLeagueListDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeagueListDto dto = await client.Riot.TftLeague.GetChallengerLeagueAsync(Platform.NorthAmerica);

            Assert.IsInstanceOfType(dto, typeof(LeagueListDto));
        }

        [TestMethod()]
        public async Task Api_Grandmaster_ShouldReturnLeagueListDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeagueListDto dto = await client.Riot.TftLeague.GetGrandmasterLeagueAsync(Platform.NorthAmerica);

            Assert.IsInstanceOfType(dto, typeof(LeagueListDto));
        }

        [TestMethod()]
        public async Task Api_Master_ShouldReturnLeagueListDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeagueListDto dto = await client.Riot.TftLeague.GetMasterLeagueAsync(Platform.NorthAmerica);

            Assert.IsInstanceOfType(dto, typeof(LeagueListDto));
        }

        [TestMethod()]
        public async Task Api_WithLeagueId_ShouldReturnLeagueListDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeagueListDto dto = await client.Riot.TftLeague.GetLeagueByIdAsync(Platform.NorthAmerica, LeagueList.LeagueId);

            Assert.IsInstanceOfType(dto, typeof(LeagueListDto));
        }

        [TestMethod()]
        public async Task Api_WithLeagueTypes_ShouldReturnLeagueEntryDtoCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<LeagueEntryDto> dtoCollection = await client.Riot.TftLeague.ListLeagueEntriesAsync(Platform.NorthAmerica, LeagueTier.Diamond, LeagueDivision.I);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<LeagueEntryDto>));
        }

        [TestMethod()]
        public async Task Api_WithLeagueId_ShouldReturnLeagueEntryDtoCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<LeagueEntryDto> dtoCollection = await client.Riot.TftLeague.ListLeagueEntriesBySummonerIdAsync(Platform.NorthAmerica, LeagueList.Entries.First().SummonerId);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<LeagueEntryDto>));
        }

        [TestMethod()]
        public async Task Api_WithQueue_ShouldReturnTopRatedLadder()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<TopRatedLadderEntryDto> dtoCollection = await client.Riot.TftLeague.ListTopRatedLadderByQueueAsync(Platform.NorthAmerica, TftLeagueQueue.RankedTftTurbo);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<TopRatedLadderEntryDto>));
        }
    }
}
