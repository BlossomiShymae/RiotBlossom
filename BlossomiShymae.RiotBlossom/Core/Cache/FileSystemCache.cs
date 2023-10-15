using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Core.Cache
{
    public class FileSystemCache : Cache
    {
        private static readonly string s_path = Directory.GetCurrentDirectory();

        public FileSystemCache(CacheTTLConfiguration cacheTTLConfiguration) : base(cacheTTLConfiguration)
        {
            Directory.CreateDirectory(Path.Join(s_path, "Cache"));
        }

        protected async override Task<string?> ReadAsync(string key)
        {
            var json = await File.ReadAllTextAsync(GetPath(key))
                .ConfigureAwait(false);

            return json;
        }

        protected async override Task WriteAsync(string key, object value)
        {
            var dir = Path.GetDirectoryName(GetPath(key)) ?? throw new InvalidOperationException();;

            Directory.CreateDirectory(dir);

            await File.WriteAllTextAsync(GetPath(key), JsonSerializer.Serialize(value))
                .ConfigureAwait(false);
        }
        
        private static string GetPath(string key)
        {
            return Path.Join(s_path, "Cache", $"{key}.json");
        }

    }
}