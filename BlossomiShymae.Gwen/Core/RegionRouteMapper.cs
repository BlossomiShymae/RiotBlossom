using System.Collections.Immutable;
using BlossomiShymae.Gwen.Type;

namespace BlossomiShymae.Gwen.Core
{
    /// <summary>
    /// A mapper class for the <see cref="RegionalRoute"/> enum. Used for obtaining the raw value.
    /// </summary>
    public static class RegionRouteMapper
    {
        private static readonly ImmutableDictionary<RegionalRoute, string> _regionByRoute =
            new Dictionary<RegionalRoute, string>
            {
                { RegionalRoute.Americas, "americas" },
                { RegionalRoute.Europe, "europe" },
                { RegionalRoute.Asia, "asia" },
                { RegionalRoute.SouthEastAsia, "sea" }
            }.ToImmutableDictionary();

        public static string GetRegion(RegionalRoute regionalRoute)
        {
            var region = _regionByRoute.GetValueOrDefault(regionalRoute);
            if (string.IsNullOrEmpty(region))
                throw new NotImplementedException($"Region for regional route {regionalRoute} not implemented");
            return region;
        }
    }
}
