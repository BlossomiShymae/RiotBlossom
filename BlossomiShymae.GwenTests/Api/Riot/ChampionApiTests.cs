using BlossomiShymae.Gwen.Core.Wrapper;
using BlossomiShymae.Gwen.Dto.Riot.Champion;
using BlossomiShymae.Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.GwenTests.Api.Riot
{
    [TestClass()]
    public class ChampionApiTests
    {
        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnChampionInfo()
        {
            IGwenClient gwen = StubConfig.Gwen;

            ChampionInfo info = await gwen.Riot.Champion.ListAsync(PlatformRoute.NorthAmerica);

            Assert.IsInstanceOfType(info, typeof(ChampionInfo));
        }
    }
}
