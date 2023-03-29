using BlossomiShymae.Gwen.Core.Wrapper;
using BlossomiShymae.Gwen.Dto.Riot.LolStatus;
using BlossomiShymae.Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.GwenTests.Api.Riot
{
    [TestClass()]
    public class LolStatusApiTests
    {
        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnPlatformDataDto()
        {
            IGwenClient gwen = StubConfig.Gwen;

            PlatformDataDto dto = await gwen.Riot.LolStatus.GetPlatformStatusAsync(PlatformRoute.NorthAmerica);

            Assert.IsInstanceOfType(dto, typeof(PlatformDataDto));
        }
    }
}
