using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A mapper class for the <see cref="LorRegion"/> enum. Used for obtaining the raw value.
    /// </summary>
    public static class LorRegionMapper
    {
        private static readonly ImmutableDictionary<LorRegion, string> s_regionByRoute =
            new Dictionary<LorRegion, string>
            {
                { LorRegion.Americas, "americas" },
                { LorRegion.Europe, "europe" },
                { LorRegion.SouthEastAsia, "sea" }
            }.ToImmutableDictionary();

        public static string GetId(LorRegion lorRegion)
        {
            string? region = s_regionByRoute.GetValueOrDefault(lorRegion);
            return region ?? throw new NotImplementedException($"LoR region for regional route {lorRegion} not implemented");
        }

        public static LorRegion FromId(string id)
        {
            var kvpList = s_regionByRoute.ToList();
            foreach (var kv in kvpList)
            {
                if (kv.Value == id)
                    return kv.Key;
            }
            throw new NotImplementedException($"Could not find LoR region for id {id}");
        }
    }
}
