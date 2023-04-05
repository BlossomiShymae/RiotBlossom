using BlossomiShymae.RiotBlossom.Api.Riot;
using BlossomiShymae.RiotBlossom.Http;

namespace BlossomiShymae.RiotBlossom.Core.Wrapper
{
    public interface IRiotCore
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
        /// The platform routing value used for accessing data from.
        /// </summary>
        ISummonerApi Summoner { get; }
    }

    internal class RiotCore : IRiotCore
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

        public RiotCore(RiotHttpClient riotHttpClient)
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
        }
    }
}
