using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A converter class for <see cref="Type.PlatformRoute"/> and <see cref="Type.RegionalRoute"/>.
    /// </summary>
    public static class PlatformToRegionConverter
    {
        private static readonly ImmutableDictionary<PlatformRoute, RegionalRoute> s_regionByPlatform =
            new Dictionary<PlatformRoute, RegionalRoute>
            {
                { PlatformRoute.NorthAmerica, RegionalRoute.Americas },
                { PlatformRoute.LatinAmericaNorth, RegionalRoute.Americas },
                { PlatformRoute.LatinAmericaSouth, RegionalRoute.Americas },
                { PlatformRoute.Brazil, RegionalRoute.Americas },
                { PlatformRoute.EuropeWest, RegionalRoute.Europe },
                { PlatformRoute.EuropeNordicEast, RegionalRoute.Europe },
                { PlatformRoute.Russia, RegionalRoute.Europe },
                { PlatformRoute.Turkey, RegionalRoute.Europe },
                { PlatformRoute.Korea, RegionalRoute.Asia },
                { PlatformRoute.Japan, RegionalRoute.Asia },
                { PlatformRoute.Singapore, RegionalRoute.SouthEastAsia },
                { PlatformRoute.Thailand, RegionalRoute.SouthEastAsia },
                { PlatformRoute.Taiwan, RegionalRoute.SouthEastAsia },
                { PlatformRoute.Philippines, RegionalRoute.SouthEastAsia },
                { PlatformRoute.Vietnam, RegionalRoute.SouthEastAsia },
                { PlatformRoute.Oceania, RegionalRoute.SouthEastAsia }
            }.ToImmutableDictionary();

        public static RegionalRoute ToRegion(PlatformRoute platform)
        {
            bool isValue = s_regionByPlatform.TryGetValue(platform, out RegionalRoute region);
            return isValue ? region : throw new NotImplementedException($"Region for platform {platform} not implemented");
        }
    }
}
