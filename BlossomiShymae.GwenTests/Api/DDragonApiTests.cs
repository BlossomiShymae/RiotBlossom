using System.Collections.Immutable;
using BlossomiShymae.Gwen.Core.Wrapper;
using BlossomiShymae.Gwen.Dto.DDragon.Champion;
using BlossomiShymae.Gwen.Dto.DDragon.Item;
using BlossomiShymae.Gwen.Dto.DDragon.Perk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GwenTests.Api
{
    [TestClass()]
    public class DDragonApiTests
    {
        public static int ChampionId = 887;
        public static int ItemId = 4633;
        public static int PerkStyleId = 8000;
        public static int ProfileIconId = 5367;
        public static string Version = "13.5.1";

        [TestMethod()]
        public async Task Api_WithChampionId_ShouldReturnChampion()
        {
            IGwenClient gwen = StubConfig.Gwen;

            Champion champion = await gwen.DDragon.GetChampionByIdAsync(Version, ChampionId);

            Assert.IsInstanceOfType(champion, typeof(Champion));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnChampionDictionary()
        {
            IGwenClient gwen = StubConfig.Gwen;

            ImmutableDictionary<int, Champion> championDictionary = await gwen.DDragon.GetChampionDictionaryAsync(Version);

            Assert.IsInstanceOfType(championDictionary, typeof(ImmutableDictionary<int, Champion>));
        }

        [TestMethod()]
        public async Task Api_WithItemId_ShouldReturnItem()
        {
            IGwenClient gwen = StubConfig.Gwen;

            Item item = await gwen.DDragon.GetItemByIdAsync(Version, ItemId);

            Assert.IsInstanceOfType(item, typeof(Item));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnItemDictionary()
        {
            IGwenClient gwen = StubConfig.Gwen;

            ImmutableDictionary<int, Item> itemDictionary = await gwen.DDragon.GetItemDictionaryAsync(Version);

            Assert.IsInstanceOfType(itemDictionary, typeof(ImmutableDictionary<int, Item>));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnLatestVersion()
        {
            IGwenClient gwen = StubConfig.Gwen;

            string latestVersion = await gwen.DDragon.GetLatestVersionAsync();

            Assert.IsTrue(latestVersion.Length > 0);
        }

        [TestMethod()]
        public async Task Api_WithPerkId_ShouldReturnPerkStyle()
        {
            IGwenClient gwen = StubConfig.Gwen;

            PerkStyle perkStyle = await gwen.DDragon.GetPerkStyleByIdAsync(Version, PerkStyleId);

            Assert.IsInstanceOfType(perkStyle, typeof(PerkStyle));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnPerkStyleDictionary()
        {
            IGwenClient gwen = StubConfig.Gwen;

            ImmutableDictionary<int, PerkStyle> perkStyleDictionary = await gwen.DDragon.GetPerkStyleDictionaryAsync(Version);

            Assert.IsInstanceOfType(perkStyleDictionary, typeof(ImmutableDictionary<int, PerkStyle>));
        }

        [TestMethod()]
        public async Task Api_WithProfileIconId_ShouldReturnProfileIconByteArray()
        {
            IGwenClient gwen = StubConfig.Gwen;

            byte[] profileIcon = await gwen.DDragon.GetProfileIconByteArrayByIdAsync(Version, ProfileIconId);

            Assert.IsTrue(profileIcon.Length > 0);
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnVersionCollection()
        {
            IGwenClient gwen = StubConfig.Gwen;

            ImmutableList<string> versionCollection = await gwen.DDragon.ListVersionsAsync();

            Assert.IsTrue(versionCollection.Count > 0);
        }
    }
}
