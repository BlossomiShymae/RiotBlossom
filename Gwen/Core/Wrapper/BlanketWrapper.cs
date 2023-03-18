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
        /// <summary>
        /// The raw API for DataDragon game data.
        /// </summary>
        IDDragonApi DDragon { get; }
    }

    internal class BlanketWrapper : IBlanketWrapper
    {
        private readonly ImmutableDictionary<Type.PlatformRoute, IRiotCore> _riotCoreByPlatform;
        private readonly CDragonApi _cDragonApi;
        private readonly DDragonApi _dDragonApi;
        public ImmutableDictionary<Type.PlatformRoute, IRiotCore> Riot => _riotCoreByPlatform;
        public ICDragonApi CDragon => _cDragonApi;
        public IDDragonApi DDragon => _dDragonApi;

        public BlanketWrapper(ImmutableDictionary<Type.PlatformRoute, IRiotCore> riotCoreByPlatform, CDragonHttpClient cDragonHttpClient, DDragonHttpClient dDragonHttpClient)
        {
            _riotCoreByPlatform = riotCoreByPlatform;
            _cDragonApi = new(cDragonHttpClient);
            _dDragonApi = new(dDragonHttpClient);
        }
    }
}
