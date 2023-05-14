using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion;
using BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Item;
using BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Perk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossomTests.Api
{
    [TestClass()]
    public class CommunityDragonApiTests
    {
        public static int ChampionId = 887;
        public static int ItemId = 4633;
        public static int PerkRuneId = 8010;
        public static int ProfileIconId = 5367;

        [TestMethod()]
        public async Task Api_WithChampionId_ShouldReturnChampion()
        {
            IRiotBlossomClient client = StubConfig.Client;

            Champion champion = await client.CommunityDragon.GetChampionByIdAsync(ChampionId);

            Assert.IsInstanceOfType(champion, typeof(Champion));
        }

        [TestMethod()]
        public async Task Api_WithItemId_ShouldReturnItem()
        {
            IRiotBlossomClient client = StubConfig.Client;

            Item? item = await client.CommunityDragon.GetItemByIdAsync(ItemId);

            Assert.IsInstanceOfType(item, typeof(Item));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnItemDictionary()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableDictionary<int, Item> itemDictionary = await client.CommunityDragon.GetItemDictionaryAsync();

            Assert.IsInstanceOfType(itemDictionary, typeof(ImmutableDictionary<int, Item>));
        }

        [TestMethod()]
        public async Task Api_WithPerkRuneId_ShouldReturnPerkRune()
        {
            IRiotBlossomClient client = StubConfig.Client;

            PerkRune perkRune = await client.CommunityDragon.GetPerkRuneByIdAsync(PerkRuneId);

            Assert.IsInstanceOfType(perkRune, typeof(PerkRune));
        }

        [TestMethod()]
        public async Task Api_ByDefault_ShouldReturnPerkRuneDictionary()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableDictionary<int, PerkRune> perkRuneDictionary = await client.CommunityDragon.GetPerkRuneDictionaryAsync();

            Assert.IsInstanceOfType(perkRuneDictionary, typeof(ImmutableDictionary<int, PerkRune>));
        }

        [TestMethod()]
        public async Task Api_WithProfileIconId_ShouldReturnProfileIconByteArray()
        {
            IRiotBlossomClient client = StubConfig.Client;

            byte[] profileIcon = await client.CommunityDragon.GetProfileIconByteArrayByIdAsync(ProfileIconId);

            Assert.IsTrue(profileIcon.Length > 0);
        }

        [TestMethod()]
        public async Task Api_WithObjectType_ShouldReturnTypeObject()
        {
            IRiotBlossomClient client = StubConfig.Client;

            Champion champion = await client.CommunityDragon.GetAsync<Champion>("/latest/plugins/rcp-be-lol-game-data/global/default/v1/champions/887.json");

            Assert.IsInstanceOfType(champion, typeof(Champion));
        }

        [TestMethod()]
        public async Task Api_WithArrayType_ShouldReturnArrayObject()
        {
            IRiotBlossomClient client = StubConfig.Client;

            List<Item> items = await client.CommunityDragon.GetAsync<List<Item>>("/latest/plugins/rcp-be-lol-game-data/global/default/v1/items.json");

            Assert.IsTrue(items.Count > 0);
        }
    }
}
