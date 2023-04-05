using BlossomiShymae.RiotBlossom.Api;
using BlossomiShymae.RiotBlossom.Http;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A client use to access Riot Games, DataDragon, and CommunityDragon APIs.
    /// </summary>
    public interface IRiotBlossomClient
    {
        /// <summary>
        /// The official API for Riot Games. 
        /// </summary>
        IRiotApi Riot { get; }
        /// <summary>
        /// The raw API for CommunityDragon game data.
        /// </summary>
        ICDragonApi CDragon { get; }
        /// <summary>
        /// The raw API for DataDragon game data.
        /// </summary>
        IDDragonApi DDragon { get; }
    }

    internal class RiotBlossomClient : IRiotBlossomClient
    {
        private readonly RiotApi _riotApi;
        private readonly CDragonApi _cDragonApi;
        private readonly DDragonApi _dDragonApi;
        public IRiotApi Riot => _riotApi;
        public ICDragonApi CDragon => _cDragonApi;
        public IDDragonApi DDragon => _dDragonApi;

        public RiotBlossomClient(RiotApi riotApi, CDragonHttpClient cDragonHttpClient, DDragonHttpClient dDragonHttpClient)
        {
            _riotApi = riotApi;
            _cDragonApi = new(cDragonHttpClient);
            _dDragonApi = new(dDragonHttpClient);
        }
    }
}
