using System.Collections.Immutable;

namespace Gwen.Core.Wrapper
{
    /// <summary>
    /// A wrapper client used for global platform use.
    /// </summary>
    public interface IBlanketWrapper
    {
        /// <summary>
        /// The immutable dictionary of components used to access Riot Games APIs. Accepts a key index of <see cref="Type.PlatformRoute"/>
        /// to get associated component.
        /// </summary>
        ImmutableDictionary<Type.PlatformRoute, IRiotCore> Riot { get; }
    }

    internal class BlanketWrapper : IBlanketWrapper
    {
        private readonly ImmutableDictionary<Type.PlatformRoute, IRiotCore> _riotCoreByPlatform;
        /// <inheritdoc/>
        public ImmutableDictionary<Type.PlatformRoute, IRiotCore> Riot { get { return _riotCoreByPlatform; } }

        public BlanketWrapper(ImmutableDictionary<Type.PlatformRoute, IRiotCore> riotCoreByPlatform)
        {
            _riotCoreByPlatform = riotCoreByPlatform;
        }
    }
}
