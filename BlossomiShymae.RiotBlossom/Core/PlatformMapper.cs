using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A mapper class for the <see cref="Platform"/> enum. Used for obtaining the raw value.
    /// </summary>
    public static class PlatformMapper
    {
        private static readonly ImmutableDictionary<Platform, string> s_platformIdByRoute =
            new Dictionary<Platform, string>
            {
                { Platform.NorthAmerica, "na1" },
                { Platform.Brazil, "br1" },
                { Platform.LatinAmericaNorth, "la1" },
                { Platform.LatinAmericaSouth, "la2" },
                { Platform.EuropeWest, "euw1" },
                { Platform.EuropeNordicEast, "eun1" },
                { Platform.Turkey, "tr1" },
                { Platform.Russia, "ru" },
                { Platform.Korea, "kr" },
                { Platform.Japan, "jp1" },
                { Platform.Oceania, "oc1" },
                { Platform.Philippines, "ph2" },
                { Platform.Singapore, "sg2" },
                { Platform.Thailand, "th2" },
                { Platform.Taiwan, "tw2" },
                { Platform.Vietnam, "vn2" }

            }.ToImmutableDictionary();

        public static string GetId(Platform platformRoute)
        {
            string? id = s_platformIdByRoute.GetValueOrDefault(platformRoute);
            return id ?? throw new NotImplementedException($"Id for platform route {platformRoute} not implemented");
        }

        public static Platform FromId(string id)
        {
            var kvpList = s_platformIdByRoute.ToList();
            foreach (var kv in kvpList)
            {
                if (kv.Value == id)
                    return kv.Key;
            }
            throw new InvalidOperationException($"Could not find platform route for id {id}");
        }
    }
}
