using System.Collections.Immutable;

namespace Soraka.Core
{
	internal static class PlatformRouteMapper
	{
		private static readonly ImmutableDictionary<Type.PlatformRoute, string> _platformIdByRoute =
			new Dictionary<Type.PlatformRoute, string>
			{
				{ Type.PlatformRoute.NorthAmerica, "na1" },
				{ Type.PlatformRoute.Brazil, "br1" },
				{ Type.PlatformRoute.LatinAmericaNorth, "la1" },
				{ Type.PlatformRoute.LatinAmericaSouth, "la2" },
				{ Type.PlatformRoute.EuropeWest, "euw1" },
				{ Type.PlatformRoute.EuropeNordicEast, "eun1" },
				{ Type.PlatformRoute.Turkey, "tr1" },
				{ Type.PlatformRoute.Russia, "ru" },
				{ Type.PlatformRoute.Korea, "kr" },
				{ Type.PlatformRoute.Japan, "jp1" },
				{ Type.PlatformRoute.Oceania, "oc1" },
				{ Type.PlatformRoute.Philippines, "ph2" },
				{ Type.PlatformRoute.Singapore, "sg2" },
				{ Type.PlatformRoute.Thailand, "th2" },
				{ Type.PlatformRoute.Taiwan, "tw2" },
				{ Type.PlatformRoute.Vietnam, "vn2" }

			}.ToImmutableDictionary();

		public static string GetId(Type.PlatformRoute platformRoute)
		{
			var id = _platformIdByRoute.GetValueOrDefault(platformRoute);
			if (string.IsNullOrEmpty(id))
				throw new NotImplementedException($"Id for platform route {platformRoute} not implemented");
			return id;
		}
	}
}
