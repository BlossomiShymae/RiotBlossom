using BlossomiShymae.RiotBlossom.Api;
using BlossomiShymae.RiotBlossom.Http;

namespace BlossomiShymae.RiotBlossom.Core
{
    /// <summary>
    /// A client use to access Riot Games, DataDragon, CommunityDragon, and Meraki Analytics APIs.
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
        ICommunityDragonApi CommunityDragon { get; }
        /// <summary>
        /// The raw API for DataDragon game data.
        /// </summary>
        IDataDragonApi DataDragon { get; }
        /// <summary>
        /// The API for Meraki Analytics static data.
        /// </summary>
        IMerakiAnalyticsApi MerakiAnalytics { get; }
    }

    internal class RiotBlossomClient : IRiotBlossomClient
    {
        private readonly RiotApi _riotApi;
        private readonly CommunityDragonApi _cDragonApi;
        private readonly DataDragonApi _dDragonApi;
        private readonly MerakiAnalyticsApi _merakiAnalyticsApi;
        public IRiotApi Riot => _riotApi;
        public ICommunityDragonApi CommunityDragon => _cDragonApi;
        public IDataDragonApi DataDragon => _dDragonApi;
        public IMerakiAnalyticsApi MerakiAnalytics => _merakiAnalyticsApi;

        public RiotBlossomClient(RiotHttpClient riotHttpClient, CommunityDragonHttpClient cDragonHttpClient, DataDragonHttpClient dDragonHttpClient, MerakiAnalyticsHttpClient merakiAnalyticsHttpClient)
        {
            _riotApi = new(riotHttpClient);
            _cDragonApi = new(cDragonHttpClient);
            _dDragonApi = new(dDragonHttpClient);
            _merakiAnalyticsApi = new(merakiAnalyticsHttpClient);
        }
    }
}
