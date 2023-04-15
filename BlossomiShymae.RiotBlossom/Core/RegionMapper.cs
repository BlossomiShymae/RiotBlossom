using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A mapper class for the <see cref="Region"/> enum. Used for obtaining the raw value.
    /// </summary>
    public static class RegionMapper
    {
        private static readonly ImmutableDictionary<Region, string> s_regionByRoute =
            new Dictionary<Region, string>
            {
                { Region.Americas, "americas" },
                { Region.Europe, "europe" },
                { Region.Asia, "asia" },
                { Region.SouthEastAsia, "sea" }
            }.ToImmutableDictionary();

        public static string GetId(Region regionalRoute)
        {
            string? region = s_regionByRoute.GetValueOrDefault(regionalRoute);
            return region ?? throw new NotImplementedException($"Region for regional route {regionalRoute} not implemented");
        }

        public static Region FromId(string region)
        {
            var kvpList = s_regionByRoute.ToList();
            foreach (var kv in kvpList)
            {
                if (kv.Value == region)
                    return kv.Key;
            }
            throw new InvalidOperationException($"Could not find region route for region {region}");
        }
    }
}
