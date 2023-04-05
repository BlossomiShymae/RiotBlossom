using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.LolStatus;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class LolStatusApiTests
    {
        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnPlatformDataDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            PlatformDataDto dto = await client.Riot.LolStatus.GetPlatformStatusAsync(PlatformRoute.NorthAmerica);

            Assert.IsInstanceOfType(dto, typeof(PlatformDataDto));
        }
    }
}
