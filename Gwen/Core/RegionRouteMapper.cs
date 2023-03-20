using System.Collections.Immutable;

namespace Gwen.Core
{
    public static class RegionRouteMapper
    {
        private static readonly ImmutableDictionary<Type.RegionalRoute, string> _regionByRoute =
            new Dictionary<Type.RegionalRoute, string>
            {
                { Type.RegionalRoute.Americas, "americas" },
                { Type.RegionalRoute.Europe, "europe" },
                { Type.RegionalRoute.Asia, "asia" },
                { Type.RegionalRoute.SouthEastAsia, "sea" }
            }.ToImmutableDictionary();

        public static string GetRegion(Type.RegionalRoute regionalRoute)
        {
            var region = _regionByRoute.GetValueOrDefault(regionalRoute);
            if (string.IsNullOrEmpty(region))
                throw new NotImplementedException($"Region for regional route {regionalRoute} not implemented");
            return region;
        }
    }
}
