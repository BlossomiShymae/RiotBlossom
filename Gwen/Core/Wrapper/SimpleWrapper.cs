using Gwen.Api;
using Gwen.Http;

namespace Gwen.Core.Wrapper
{
    /// <summary>
    /// A wrapper client used for single platform use.
    /// </summary>
    public interface ISimpleWrapper
    {
        /// <summary>
        /// The component used to access Riot Games APIs. Locked to given <see cref="Type.PlatformRoute"/>.
        /// </summary>
        IRiotCore Riot { get; }
        /// <summary>
        /// The raw API for CommunityDragon game data.
        /// </summary>
        ICDragonApi CDragon { get; }
    }

    internal class SimpleWrapper : ISimpleWrapper
    {
        private readonly RiotCore _riotCore;
        private readonly CDragonApi _cDragonApi;
        public IRiotCore Riot => _riotCore;
        public ICDragonApi CDragon => _cDragonApi;

        public SimpleWrapper(RiotCore riotCore, CDragonHttpClient cDragonHttpClient)
        {
            _riotCore = riotCore;
            _cDragonApi = new(cDragonHttpClient);
        }
    }
}
