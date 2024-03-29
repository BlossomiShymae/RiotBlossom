﻿using BlossomiShymae.RiotBlossom.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BlossomiShymae.RiotBlossomTests.Dto
{
    [TestClass()]
    public class DataObjectTests
    {
        [TestMethod()]
        public void DataObject_WithInheritance_ShouldReturnPrettyString()
        {
            ExampleDto child = new();

            string prettyString = child.ToString();
            Trace.WriteLine(prettyString);

            Assert.IsTrue(prettyString.Length > 0);
        }

        public record ExampleDto : DataObject
        {
            public string? Id { get; init; }
            public string? Name { get; init; }
        }
    }
}
