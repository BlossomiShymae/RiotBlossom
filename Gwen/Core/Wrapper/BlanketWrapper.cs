using Gwen.Api;
using Gwen.Http;
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
        /// <summary>
        /// The raw API for CommunityDragon game data.
        /// </summary>
        ICDragonApi CDragon { get; }
    }

    internal class BlanketWrapper : IBlanketWrapper
    {
        private readonly ImmutableDictionary<Type.PlatformRoute, IRiotCore> _riotCoreByPlatform;
        private readonly CDragonApi _cDragonApi;
        public ImmutableDictionary<Type.PlatformRoute, IRiotCore> Riot => _riotCoreByPlatform;
        public ICDragonApi CDragon => _cDragonApi;

        public BlanketWrapper(ImmutableDictionary<Type.PlatformRoute, IRiotCore> riotCoreByPlatform, CDragonHttpClient cDragonHttpClient)
        {
            _riotCoreByPlatform = riotCoreByPlatform;
            _cDragonApi = new(cDragonHttpClient);
        }
    }
}
