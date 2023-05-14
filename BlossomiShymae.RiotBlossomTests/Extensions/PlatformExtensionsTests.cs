using BlossomiShymae.RiotBlossom.Extensions;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Extensions
{
    [TestClass()]
    public class PlatformExtensionsTests
    {
        [TestMethod()]
        public void Platform_ByDefault_ShouldReturnAbbreviation()
        {
            Platform platform = Platform.LatinAmericaNorth;

            string abbreviation = platform.GetAbbreviation();

            Assert.IsTrue(abbreviation.Equals("LAN"));
        }

        [TestMethod()]
        public void Platform_ByDefault_ShouldReturnRegionId()
        {
            Platform platform = Platform.NorthAmerica;

            string regionId = platform.GetRegionId();

            Assert.IsTrue(regionId.Equals("americas"));
        }
    }
}
