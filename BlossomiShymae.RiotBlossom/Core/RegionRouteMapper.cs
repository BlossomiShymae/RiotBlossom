using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A mapper class for the <see cref="RegionalRoute"/> enum. Used for obtaining the raw value.
    /// </summary>
    public static class RegionRouteMapper
    {
        private static readonly ImmutableDictionary<RegionalRoute, string> s_regionByRoute =
            new Dictionary<RegionalRoute, string>
            {
                { RegionalRoute.Americas, "americas" },
                { RegionalRoute.Europe, "europe" },
                { RegionalRoute.Asia, "asia" },
                { RegionalRoute.SouthEastAsia, "sea" }
            }.ToImmutableDictionary();

        public static string GetRegion(RegionalRoute regionalRoute)
        {
            string? region = s_regionByRoute.GetValueOrDefault(regionalRoute);
            return region ?? throw new NotImplementedException($"Region for regional route {regionalRoute} not implemented");
        }

        public static RegionalRoute FromRegion(string region)
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
