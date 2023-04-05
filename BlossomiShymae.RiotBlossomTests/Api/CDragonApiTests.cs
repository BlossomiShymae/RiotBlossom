using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.CDragon.Champion;
using BlossomiShymae.RiotBlossom.Dto.CDragon.Item;
using BlossomiShymae.RiotBlossom.Dto.CDragon.Perk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossomTests.Api
{
    [TestClass()]
    public class CDragonApiTests
    {
        public static int ChampionId = 887;
        public static int ItemId = 4633;
        public static int PerkRuneId = 8010;
        public static int ProfileIconId = 5367;

        [TestMethod()]
        public async Task Api_WithChampionId_ShouldReturnChampion()
        {
            IRiotBlossomClient client = StubConfig.Client;

            Champion champion = await client.CDragon.GetChampionByIdAsync(ChampionId);

            Assert.IsInstanceOfType(champion, typeof(Champion));
        }

        [TestMethod()]
        public async Task Api_WithItemId_ShouldReturnItem()
        {
            IRiotBlossomClient client = StubConfig.Client;

            Item? item = await client.CDragon.GetItemByIdAsync(ItemId);

            Assert.IsInstanceOfType(item, typeof(Item));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnItemDictionary()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableDictionary<int, Item> itemDictionary = await client.CDragon.GetItemDictionaryAsync();

            Assert.IsInstanceOfType(itemDictionary, typeof(ImmutableDictionary<int, Item>));
        }

        [TestMethod()]
        public async Task Api_WithPerkRuneId_ShouldReturnPerkRune()
        {
            IRiotBlossomClient client = StubConfig.Client;

            PerkRune perkRune = await client.CDragon.GetPerkRuneByIdAsync(PerkRuneId);

            Assert.IsInstanceOfType(perkRune, typeof(PerkRune));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnPerkRuneDictionary()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableDictionary<int, PerkRune> perkRuneDictionary = await client.CDragon.GetPerkRuneDictionaryAsync();

            Assert.IsInstanceOfType(perkRuneDictionary, typeof(ImmutableDictionary<int, PerkRune>));
        }

        [TestMethod()]
        public async Task Api_WithProfileIconId_ShouldReturnProfileIconByteArray()
        {
            IRiotBlossomClient client = StubConfig.Client;

            byte[] profileIcon = await client.CDragon.GetProfileIconByteArrayByIdAsync(ProfileIconId);

            Assert.IsTrue(profileIcon.Length > 0);
        }
    }
}
