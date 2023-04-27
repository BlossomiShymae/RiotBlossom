using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A mapper class for the <see cref="ValRegion"/> enum. Used for obtaining the raw value.
    /// </summary>
    public static class ValRegionMapper
    {
        private static readonly ImmutableDictionary<ValRegion, string> s_regionByRoute =
            new Dictionary<ValRegion, string>
            {
                { ValRegion.NorthAmerica, "na" },
                { ValRegion.Brazil, "br" },
                { ValRegion.Korea, "kr" },
                { ValRegion.AsiaPacific, "ap" },
                { ValRegion.LatinAmerica, "latam" },
                { ValRegion.Europe, "eu" }
            }.ToImmutableDictionary();

        public static string GetId(ValRegion valRegion)
        {
            string? region = s_regionByRoute.GetValueOrDefault(valRegion);
            return region ?? throw new NotImplementedException($"VALORANT region for regional route {valRegion} not implemented");
        }

        public static ValRegion FromId(string id)
        {
            var kvpList = s_regionByRoute.ToList();
            foreach (var kv in kvpList)
            {
                if (kv.Value == id)
                    return kv.Key;
            }
            throw new InvalidOperationException($"Could not find VALORANT region for id {id}");
        }
    }
}
