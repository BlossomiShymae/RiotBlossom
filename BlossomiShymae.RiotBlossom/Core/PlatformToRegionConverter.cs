using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A converter class for <see cref="Type.Platform"/> and <see cref="Type.Region"/>.
    /// </summary>
    public static class PlatformToRegionConverter
    {
        private static readonly ImmutableDictionary<Platform, Region> s_regionByPlatform =
            new Dictionary<Platform, Region>
            {
                { Platform.NorthAmerica, Region.Americas },
                { Platform.LatinAmericaNorth, Region.Americas },
                { Platform.LatinAmericaSouth, Region.Americas },
                { Platform.Brazil, Region.Americas },
                { Platform.EuropeWest, Region.Europe },
                { Platform.EuropeNordicEast, Region.Europe },
                { Platform.Russia, Region.Europe },
                { Platform.Turkey, Region.Europe },
                { Platform.Korea, Region.Asia },
                { Platform.Japan, Region.Asia },
                { Platform.Singapore, Region.SouthEastAsia },
                { Platform.Thailand, Region.SouthEastAsia },
                { Platform.Taiwan, Region.SouthEastAsia },
                { Platform.Philippines, Region.SouthEastAsia },
                { Platform.Vietnam, Region.SouthEastAsia },
                { Platform.Oceania, Region.SouthEastAsia }
            }.ToImmutableDictionary();

        public static Region ToRegion(Platform platform)
        {
            bool isValue = s_regionByPlatform.TryGetValue(platform, out Region region);
            return isValue ? region : throw new NotImplementedException($"Region for platform {platform} not implemented");
        }
    }
}
