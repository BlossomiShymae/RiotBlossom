using BlossomiShymae.RiotBlossom.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Core
{
    [TestClass()]
    public class PropertiesToQueryConverterTests
    {
        [TestMethod()]
        public void Converter_WithProperties_ShouldReturnQuery()
        {
            var properties = new
            {
                Count = 100,
                Status = "Online",
                Type = "GREEN",
            };

            string query = PropertiesToQueryConverter.ToQuery(properties);

            Assert.IsTrue(query.Equals("?count=100&status=Online&type=GREEN"));
        }

        [TestMethod()]
        public void Converter_WithManyProperties_ShouldReturnQueryCollection()
        {
            var propertyA = new ParametersA { Count = 100 };
            var propertyB = new ParametersB { Status = "Online", Type = "GREEN" };
            var propertyC = new ParametersA { Count = 7 };
            var propertyD = new ParametersB { Status = "Offline" };

            List<string> queries = new()
            {
                PropertiesToQueryConverter.ToQuery(propertyA),
                PropertiesToQueryConverter.ToQuery(propertyB),
                PropertiesToQueryConverter.ToQuery(propertyC),
                PropertiesToQueryConverter.ToQuery(propertyD)
            };
            List<string> expectedQueries = new() { "?count=100", "?status=Online&type=GREEN", "?count=7", "?status=Offline" };

            Assert.IsTrue(queries.SequenceEqual(expectedQueries));
        }

        internal record ParametersA
        {
            public int? Count { get; init; }
        }

        internal record ParametersB
        {
            public string? Status { get; init; }
            public string? Type { get; init; }
        }
    }
}
