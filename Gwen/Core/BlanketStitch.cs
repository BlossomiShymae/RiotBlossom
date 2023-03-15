using System.Collections.Immutable;

namespace Gwen.Core
{
	/// <summary>
	/// A stitch client used for global platform use.
	/// </summary>
	public interface IBlanketStitch
	{
		/// <summary>
		/// The immutable dictionary of components used to access Riot Games APIs. Accepts a key index of <see cref="Type.PlatformRoute"/>
		/// to get associated component.
		/// </summary>
		ImmutableDictionary<Type.PlatformRoute, IRiotCore> Riot { get; }
	}

	internal class BlanketStitch : IBlanketStitch
	{
		private readonly ImmutableDictionary<Type.PlatformRoute, IRiotCore> _riotCoreByPlatform;
		/// <inheritdoc/>
		public ImmutableDictionary<Type.PlatformRoute, IRiotCore> Riot { get { return _riotCoreByPlatform; } }

		public BlanketStitch(ImmutableDictionary<Type.PlatformRoute, IRiotCore> riotCoreByPlatform)
		{
			_riotCoreByPlatform = riotCoreByPlatform;
		}
	}
}
