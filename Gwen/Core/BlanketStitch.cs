using System.Collections.Immutable;

namespace Gwen.Core
{
	internal class BlanketStitch
	{
		private readonly ImmutableDictionary<Type.PlatformRoute, RiotCore> _riotCoreByPlatform;
		/// <summary>
		/// The immutable dictionary of components used to access Riot Games APIs. Accepts a key index of <see cref="Type.PlatformRoute"/>
		/// to get associated component.
		/// </summary>
		public ImmutableDictionary<Type.PlatformRoute, RiotCore> Riot { get { return _riotCoreByPlatform; } }

		public BlanketStitch(ImmutableDictionary<Type.PlatformRoute, RiotCore> riotCoreByPlatform)
		{
			_riotCoreByPlatform = riotCoreByPlatform;
		}
	}
}
