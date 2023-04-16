using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.LolStatus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class TftStatusApiTests
    {
        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnPlatformDataDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            PlatformDataDto dto = await client.Riot.TftStatus.GetPlatformStatusAsync(RiotBlossom.Type.Platform.NorthAmerica);

            Assert.IsInstanceOfType(dto, typeof(PlatformDataDto));
        }
    }
}
