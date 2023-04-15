using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Clash;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class ClashApiTests
    {
        public static SummonerDto summoner = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IRiotBlossomClient client = StubConfig.Client;

            summoner = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnTournamentDtoCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<TournamentDto> dtoCollection = await client.Riot.Clash.ListActiveTournamentsAsync(Platform.NorthAmerica);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<TournamentDto>));
        }

        [TestMethod()]
        public async Task Api_WithSummonerId_ShouldReturnPlayerDtoCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<PlayerDto> dtoCollection = await client.Riot.Clash.ListPlayersBySummonerIdAsync(StubConfig.SummonerPlatform, summoner.Id);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<PlayerDto>));
        }


    }
}
