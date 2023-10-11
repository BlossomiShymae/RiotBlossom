using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Client;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Core.Cache;
using BlossomiShymae.RiotBlossom.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests
{
    [TestClass()]
    public class CacheTests
    {
        [TestMethod()]
        public async Task EmptyCache_WithData_ReturnsNull()
        {
            var cache = CacheFactory.Create(CacheProvider.Empty);
            var value = 0;
            var hint = "test";
            var key = "value";

            cache.TTLConfiguration.SetTTL(hint, TimeSpan.FromMinutes(5));
            await cache.SetValueAsync(hint, key, value);

            var data = await cache.GetValueAsync(key);

            Assert.IsTrue(data == null);
        }

        [TestMethod()]
        public async Task MemoryCache_WithData_ReturnsData()
        {
            var cache = CacheFactory.Create(CacheProvider.Memory);
            var value = 10;
            var hint = "test";
            var key = "value";

            cache.TTLConfiguration.SetTTL(hint, TimeSpan.FromSeconds(10));
            await cache.SetValueAsync(hint, key, value);

            var data = await cache.GetValueAsync(key);

            Assert.IsTrue(data != null);
            Assert.IsTrue(value == JsonSerializer.Deserialize<int>(data));
        }

        [TestMethod()]
        public async Task MemoryCache_WithData_Expires()
        {
            var cache = CacheFactory.Create(CacheProvider.Memory);
            var value = 20;
            var hint = "test";
            var key = "value";

            cache.TTLConfiguration.SetTTL(hint, TimeSpan.FromSeconds(1));
            await cache.SetValueAsync(hint, key, value);
            await Task.Delay(TimeSpan.FromSeconds(2));

            var data = await cache.GetValueAsync(key);

            Assert.IsTrue(data == null);
        }

        [TestMethod()]
        public async Task FileSystemCache_WithData_ReturnsData()
        {
            var cache = CacheFactory.Create(CacheProvider.FileSystem);
            var value = 30;
            var hint = "test";
            var key = "value";

            cache.TTLConfiguration.SetTTL(hint, TimeSpan.FromMinutes(10));
            await cache.SetValueAsync(hint, key, value);

            var data = await cache.GetValueAsync(key);

            Assert.IsTrue(data != null);
            Assert.IsTrue(value == JsonSerializer.Deserialize<int>(data));
        }

        [TestMethod()]
        public async Task FileSystemCache_WithData_Expires()
        {
            var cache = CacheFactory.Create(CacheProvider.FileSystem);
            var value = 40;
            var hint = "test";
            var key = "value";

            cache.TTLConfiguration.SetTTL(hint, TimeSpan.FromSeconds(1));
            await cache.SetValueAsync(hint, key, value);
            await Task.Delay(TimeSpan.FromSeconds(2));

            var data = await cache.GetValueAsync(key);

            Assert.IsTrue(data == null);
        }
    }
}