using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.LorRanked;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class LorRankedApiTests
    {
        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnLeaderboardDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeaderboardDto dto = await client.Riot.LorRanked.GetMasterLeaderboardAsync(LorRegion.Americas);

            Assert.IsInstanceOfType(dto, typeof(LeaderboardDto));
        }
    }
}
