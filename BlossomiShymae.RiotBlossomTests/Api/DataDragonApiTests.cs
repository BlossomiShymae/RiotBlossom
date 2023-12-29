using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.DataDragon.Champion;
using BlossomiShymae.RiotBlossom.Dto.DataDragon.Item;
using BlossomiShymae.RiotBlossom.Dto.DataDragon.Perk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossomTests.Api
{
    [TestClass()]
    public class DataDragonApiTests
    {
        public static int ChampionId = 887;
        public static int ItemId = 4633;
        public static int PerkStyleId = 8000;
        public static int ProfileIconId = 5367;
        public static string Version = "13.23.1";

        [TestMethod()]
        public async Task Api_WithChampionId_ShouldReturnChampion()
        {
            IRiotBlossomClient client = StubConfig.Client;

            Champion champion = await client.DataDragon.GetChampionByIdAsync(Version, ChampionId);

            Assert.IsInstanceOfType(champion, typeof(Champion));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnChampionDictionary()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableDictionary<int, Champion> championDictionary = await client.DataDragon.GetChampionDictionaryAsync(Version);

            Assert.IsInstanceOfType(championDictionary, typeof(ImmutableDictionary<int, Champion>));
        }

        [TestMethod()]
        public async Task Api_WithItemId_ShouldReturnItem()
        {
            IRiotBlossomClient client = StubConfig.Client;

            Item item = await client.DataDragon.GetItemByIdAsync(Version, ItemId);

            Assert.IsInstanceOfType(item, typeof(Item));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnItemDictionary()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableDictionary<int, Item> itemDictionary = await client.DataDragon.GetItemDictionaryAsync(Version);

            Assert.IsInstanceOfType(itemDictionary, typeof(ImmutableDictionary<int, Item>));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnLatestVersion()
        {
            IRiotBlossomClient client = StubConfig.Client;

            string latestVersion = await client.DataDragon.GetLatestVersionAsync();

            Assert.IsTrue(latestVersion.Length > 0);
        }

        [TestMethod()]
        public async Task Api_WithPerkId_ShouldReturnPerkStyle()
        {
            IRiotBlossomClient client = StubConfig.Client;

            PerkStyle perkStyle = await client.DataDragon.GetPerkStyleByIdAsync(Version, PerkStyleId);

            Assert.IsInstanceOfType(perkStyle, typeof(PerkStyle));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnPerkStyleDictionary()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableDictionary<int, PerkStyle> perkStyleDictionary = await client.DataDragon.GetPerkStyleDictionaryAsync(Version);

            Assert.IsInstanceOfType(perkStyleDictionary, typeof(ImmutableDictionary<int, PerkStyle>));
        }

        [TestMethod()]
        public async Task Api_WithProfileIconId_ShouldReturnProfileIconByteArray()
        {
            IRiotBlossomClient client = StubConfig.Client;

            byte[] profileIcon = await client.DataDragon.GetProfileIconByteArrayByIdAsync(Version, ProfileIconId);

            Assert.IsTrue(profileIcon.Length > 0);
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnVersionCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<string> versionCollection = await client.DataDragon.ListVersionsAsync();

            Assert.IsTrue(versionCollection.Count > 0);
        }
    }
}
