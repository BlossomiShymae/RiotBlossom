using BlossomiShymae.RiotBlossom.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BlossomiShymae.RiotBlossomTests.Core
{
    [TestClass()]
    public class PrettyPrinterTests
    {
        [TestMethod()]
        public async Task Printer_WithNestedObject_ShouldReturnPrettyString()
        {
            IRiotBlossomClient client = StubConfig.Client;

            var itemDictionary = await client.CommunityDragon.GetItemDictionaryAsync();
            string prettyItems = PrettyPrinter.GetString(itemDictionary);
            Trace.WriteLine(prettyItems);

            Assert.IsTrue(prettyItems.Length > 0);
        }
    }
}
