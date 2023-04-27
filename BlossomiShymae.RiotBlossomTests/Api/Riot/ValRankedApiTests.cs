using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.ValRanked;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class ValRankedApiTests
    {
        public static readonly string ActId = "2de5423b-4aad-02ad-8d9b-c0a931958861";

        [TestMethod()]
        public async Task Api_WithActId_ShouldReturnLeaderboardDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeaderboardDto dto = await client.Riot.ValRanked.GetLeaderboardByActIdAsync(ValRegion.NorthAmerica, ActId);

            Assert.IsInstanceOfType(dto, typeof(LeaderboardDto));
        }

        [TestMethod()]
        public async Task Api_WithActIdAndOptions_ShouldReturnLeaderboardDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeaderboardDto dto = await client.Riot.ValRanked.GetLeaderboardByActIdAsync(ValRegion.NorthAmerica, ActId, new() { Size = 100, StartIndex = 0 });

            Assert.IsTrue(dto.Players.Count <= 100);
        }
    }
}
