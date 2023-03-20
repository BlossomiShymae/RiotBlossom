using Gwen.Api;
using Gwen.Http;

namespace Gwen.Core.Wrapper
{
    /// <summary>
    /// A client use to access Riot Games, DataDragon, and CommunityDragon APIs.
    /// </summary>
    public interface IGwenClient
    {
        /// <summary>
        /// The component used to access Riot Games APIs. 
        /// </summary>
        IRiotCore Riot { get; }
        /// <summary>
        /// The raw API for CommunityDragon game data.
        /// </summary>
        ICDragonApi CDragon { get; }
        /// <summary>
        /// The raw API for DataDragon game data.
        /// </summary>
        IDDragonApi DDragon { get; }
    }

    internal class GwenClient : IGwenClient
    {
        private readonly RiotCore _riotCore;
        private readonly CDragonApi _cDragonApi;
        private readonly DDragonApi _dDragonApi;
        public IRiotCore Riot => _riotCore;
        public ICDragonApi CDragon => _cDragonApi;
        public IDDragonApi DDragon => _dDragonApi;

        public GwenClient(RiotCore riotCore, CDragonHttpClient cDragonHttpClient, DDragonHttpClient dDragonHttpClient)
        {
            _riotCore = riotCore;
            _cDragonApi = new(cDragonHttpClient);
            _dDragonApi = new(dDragonHttpClient);
        }
    }
}
