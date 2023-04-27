using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.ValContent;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class ValContentApiTests
    {
        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnContentDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ContentDto dto = await client.Riot.ValContent.GetContentAsync(ValRegion.NorthAmerica);

            Assert.IsInstanceOfType(dto, typeof(ContentDto));
        }

        [TestMethod()]
        public async Task Api_WithLocale_ShouldReturnContentDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ContentDto dto = await client.Riot.ValContent.GetContentByLocaleAsync(ValRegion.NorthAmerica, "en-US");

            Assert.IsTrue(dto.Characters.First().LocalizedNames == null);
        }
    }
}
