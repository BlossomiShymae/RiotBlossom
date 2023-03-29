using System.Collections.Immutable;
using BlossomiShymae.Gwen.Core.Wrapper;
using BlossomiShymae.Gwen.Dto.Riot.Clash;
using BlossomiShymae.Gwen.Dto.Riot.Summoner;
using BlossomiShymae.Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GwenTests.Api.Riot
{
    [TestClass()]
    public class ClashApiTests
    {
        public static SummonerDto summoner = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IGwenClient gwen = StubConfig.Gwen;

            summoner = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnTournamentDtoCollection()
        {
            IGwenClient gwen = StubConfig.Gwen;

            ImmutableList<TournamentDto> dtoCollection = await gwen.Riot.Clash.ListActiveTournamentsAsync(PlatformRoute.NorthAmerica);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<TournamentDto>));
        }

        [TestMethod()]
        public async Task Api_WithSummonerId_ShouldReturnPlayerDtoCollection()
        {
            IGwenClient gwen = StubConfig.Gwen;

            ImmutableList<PlayerDto> dtoCollection = await gwen.Riot.Clash.ListPlayersBySummonerIdAsync(StubConfig.SummonerPlatform, summoner.Id);

            Assert.IsInstanceOfType(dtoCollection, typeof(ImmutableList<PlayerDto>));
        }


    }
}
