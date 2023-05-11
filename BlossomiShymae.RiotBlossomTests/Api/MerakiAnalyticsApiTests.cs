using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion;
using BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;
using System.Diagnostics;

namespace BlossomiShymae.RiotBlossomTests.Api
{
    [TestClass()]
    public class MerakiAnalyticsApiTests
    {
        [TestMethod()]
        public async Task Api_WithChampionId_ShouldReturnChampion()
        {
            IRiotBlossomClient client = StubConfig.Client;

            string id = "MonkeyKing";
            Champion champion = await client.MerakiAnalytics.GetChampionByIdAsync(id);
            Trace.WriteLine(champion);

            Assert.IsTrue(champion.Key == id);
        }

        [TestMethod()]
        public async Task Api_WithChampionId_ShouldReturnChampionDictionary()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableDictionary<string, Champion> champions = await client.MerakiAnalytics.GetChampionDictionaryAsync();
            string id = "Lux";
            Champion champion = champions[id];
            Trace.WriteLine(champion);

            Assert.IsTrue(champion.Key == id);
        }

        [TestMethod()]
        public async Task Api_WithItemId_ShouldReturnItem()
        {
            IRiotBlossomClient client = StubConfig.Client;

            int id = 1001;
            Item item = await client.MerakiAnalytics.GetItemByIdAsync(id);
            Trace.WriteLine(item);

            Assert.IsTrue(item.Id == id);
        }

        [TestMethod()]
        public async Task Api_WithItemId_ShouldReturnItemDictionary()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableDictionary<int, Item> items = await client.MerakiAnalytics.GetItemDictionaryAsync();
            int id = 1001;
            Item item = items[id];
            Trace.WriteLine(item);

            Assert.IsTrue(item.Id == id);
        }
    }
}
