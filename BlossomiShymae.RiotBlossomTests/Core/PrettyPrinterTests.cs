using BlossomiShymae.RiotBlossom.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Text.Json.Serialization;

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

        [TestMethod()]
        public void Printer_WithJsonPropertyNameAttribute_ShouldReturnPrettyString()
        {
            JsonPropertyNameAttributeDto dto = new() { MatchId = "NA_20" };

            string pretty = PrettyPrinter.GetString(dto);
            Trace.WriteLine(pretty);

            Assert.IsTrue(pretty.Contains("match_id"));
        }

        [TestMethod()]
        public void Printer_WithJsonConverterAttribute_ShouldReturnPrettyString()
        {
            JsonConverterAttributeDto dto = new() { Lp = 10 };

            string pretty = PrettyPrinter.GetString(dto);
            Trace.WriteLine(pretty);

            Assert.IsTrue(pretty.Contains("10") && !pretty.Contains("10.0"));
        }

        internal record JsonPropertyNameAttributeDto
        {
            [JsonPropertyName("match_id")]
            public string MatchId { get; init; } = default!;
        }

        internal record JsonConverterAttributeDto
        {
            [JsonConverter(typeof(IntJsonConverter))]
            public int Lp { get; init; }
        }
    }
}
