using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Champion;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class ChampionApiTests
    {
        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnChampionInfo()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ChampionInfo info = await client.Riot.Champion.ListAsync(PlatformRoute.NorthAmerica);

            Assert.IsInstanceOfType(info, typeof(ChampionInfo));
        }
    }
}
