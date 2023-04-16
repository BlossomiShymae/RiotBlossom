using BlossomiShymae.RiotBlossom.Api.Riot;
using BlossomiShymae.RiotBlossom.Http;

namespace BlossomiShymae.RiotBlossom.Api
{
    public interface IRiotApi
    {
        /// <summary>
        /// The API for Account-v1 endpoints.
        /// </summary>
        IAccountApi Account { get; }
        /// <summary>
        /// The API for Champion-v3 endpoints.
        /// </summary>
        IChampionApi Champion { get; }
        /// <summary>
        /// The API for Champion-Mastery-v4 endpoints.
        /// </summary>
        IChampionMasteryApi ChampionMastery { get; }
        /// <summary>
        /// The API for Clash-v1 endpoints.
        /// </summary>
        IClashApi Clash { get; }
        /// <summary>
        /// The API for League-v4 endpoints.
        /// </summary>
        ILeagueApi League { get; }
        /// <summary>
        /// The API for Lol-Challenges-v1 endpoints.
        /// </summary>
        ILolChallengesApi LolChallenges { get; }
        /// <summary>
        /// The API for Lol-Status-v4 endpoint.
        /// </summary>
        ILolStatusApi LolStatus { get; }
        /// <summary>
        /// The API for Match-v5 endpoints.
        /// </summary>
        IMatchApi Match { get; }
        /// <summary>
        /// The Api for Spectator-v4 endpoints.
        /// </summary>
        ISpectatorApi Spectator { get; }
        /// <summary>
        /// The API for Summoner-v4 endpoints.
        /// </summary>
        ISummonerApi Summoner { get; }
        /// <summary>
        /// The API for Tft-League-v1 endpoints.
        /// </summary>
        ITftLeagueApi TftLeague { get; }
        /// <summary>
        /// The API for Tft-Match-v1 endpoints.
        /// </summary>
        ITftMatchApi TftMatch { get; }
        /// <summary>
        /// The API for Tft-Status-v1 endpoints.
        /// </summary>
        ITftStatusApi TftStatus { get; }
        /// <summary>
        /// The API for Tft-Summoner-v1 endpoints.
        /// </summary>
        ITftSummonerApi TftSummoner { get; }
    }

    internal class RiotApi : IRiotApi
    {
        private readonly AccountApi _accountApi;
        private readonly ChampionApi _championApi;
        private readonly ChampionMasteryApi _championMasteryApi;
        private readonly ClashApi _clashApi;
        private readonly LeagueApi _leagueApi;
        private readonly LolChallengesApi _lolChallengesApi;
        private readonly LolStatusApi _lolStatusApi;
        private readonly MatchApi _matchApi;
        private readonly SpectatorApi _spectatorApi;
        private readonly SummonerApi _summonerApi;
        private readonly TftLeagueApi _tftLeagueApi;
        private readonly TftMatchApi _tftMatchApi;
        private readonly TftStatusApi _tftStatusApi;
        private readonly TftSummonerApi _tftSummonerApi;
        public IAccountApi Account => _accountApi;
        public IChampionApi Champion => _championApi;
        public IChampionMasteryApi ChampionMastery => _championMasteryApi;
        public IClashApi Clash => _clashApi;
        public ILeagueApi League => _leagueApi;
        public ILolChallengesApi LolChallenges => _lolChallengesApi;
        public ILolStatusApi LolStatus => _lolStatusApi;
        public IMatchApi Match => _matchApi;
        public ISpectatorApi Spectator => _spectatorApi;
        public ISummonerApi Summoner => _summonerApi;
        public ITftLeagueApi TftLeague => _tftLeagueApi;
        public ITftMatchApi TftMatch => _tftMatchApi;
        public ITftStatusApi TftStatus => _tftStatusApi;
        public ITftSummonerApi TftSummoner => _tftSummonerApi;

        public RiotApi(RiotHttpClient riotHttpClient)
        {
            _accountApi = new(riotHttpClient);
            _championApi = new(riotHttpClient);
            _championMasteryApi = new(riotHttpClient);
            _clashApi = new(riotHttpClient);
            _leagueApi = new(riotHttpClient);
            _lolChallengesApi = new(riotHttpClient);
            _lolStatusApi = new(riotHttpClient);
            _matchApi = new(riotHttpClient);
            _spectatorApi = new(riotHttpClient);
            _summonerApi = new(riotHttpClient);
            _tftLeagueApi = new(riotHttpClient);
            _tftMatchApi = new(riotHttpClient);
            _tftStatusApi = new(riotHttpClient);
            _tftSummonerApi = new(riotHttpClient);
        }
    }
}
