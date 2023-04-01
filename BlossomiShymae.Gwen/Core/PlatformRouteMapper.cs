﻿using BlossomiShymae.Gwen.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.Gwen.Core
{
    /// <summary>
    /// A mapper class for the <see cref="PlatformRoute"/> enum. Used for obtaining the raw value.
    /// </summary>
    public static class PlatformRouteMapper
    {
        private static readonly ImmutableDictionary<PlatformRoute, string> s_platformIdByRoute =
            new Dictionary<PlatformRoute, string>
            {
                { PlatformRoute.NorthAmerica, "na1" },
                { PlatformRoute.Brazil, "br1" },
                { PlatformRoute.LatinAmericaNorth, "la1" },
                { PlatformRoute.LatinAmericaSouth, "la2" },
                { PlatformRoute.EuropeWest, "euw1" },
                { PlatformRoute.EuropeNordicEast, "eun1" },
                { PlatformRoute.Turkey, "tr1" },
                { PlatformRoute.Russia, "ru" },
                { PlatformRoute.Korea, "kr" },
                { PlatformRoute.Japan, "jp1" },
                { PlatformRoute.Oceania, "oc1" },
                { PlatformRoute.Philippines, "ph2" },
                { PlatformRoute.Singapore, "sg2" },
                { PlatformRoute.Thailand, "th2" },
                { PlatformRoute.Taiwan, "tw2" },
                { PlatformRoute.Vietnam, "vn2" }

            }.ToImmutableDictionary();

        public static string GetId(PlatformRoute platformRoute)
        {
            var id = s_platformIdByRoute.GetValueOrDefault(platformRoute);
            if (string.IsNullOrEmpty(id))
                throw new NotImplementedException($"Id for platform route {platformRoute} not implemented");
            return id;
        }

        public static PlatformRoute FromId(string id)
        {
            var kvs = s_platformIdByRoute.ToList();
            foreach (var kv in kvs)
            {
                if (kv.Value == id)
                    return kv.Key;
            }
            throw new InvalidOperationException($"Could not find platform route for id {id}");
        }
    }
}
