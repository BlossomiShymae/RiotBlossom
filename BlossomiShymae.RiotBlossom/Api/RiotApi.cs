using BlossomiShymae.RiotBlossom.Api.Riot;
using BlossomiShymae.RiotBlossom.Http;
using System.Text.Json.Nodes;

namespace BlossomiShymae.RiotBlossom.Api
{
    public interface IRiotApi
    {
        /// <summary>
        /// Get the deserialized object, array, or scalar response from endpoint by route and path.
        /// <para>
        /// Object
        /// <code>
        /// SummonerDto summoner = await client.Riot.GetAsync&lt;SummonerDto&gt;("na1", "/lol/summoner/v4/summoners/by-name/uwuie time");
        /// </code>
        /// </para>
        /// <para>
        /// Array
        /// <code>
        /// List&lt;string&gt; matchIds = await client.Riot.GetAsync&lt;List&lt;string&gt;&gt;("na1", $"/lol/match/v5/matches/by-puuid/{puuid}/ids");
        /// </code>
        /// </para>
        /// <para>
        /// Scalar
        /// <code>
        /// int totalMasteryScore = await client.Riot.GetAsync&lt;int&gt;("na1", $"/lol/champion-mastery/v4/scores/by-summoner/{encryptedSummonerId}");
        /// </code>
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="route">The raw routing value for request e.g. "na1", "americas", "esports", "ap", etc.</param>
        /// <param name="path">The path for endpoint e.g. "/lol/status/v4/platform-data".</param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string route, string path);
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
        /// The API for Lor-Match-v1 endpoints.
        /// </summary>
        ILorMatchApi LorMatch { get; }
        /// <summary>
        /// The API for Lor-Ranked-v1 endpoint.
        /// </summary>
        ILorRankedApi LorRanked { get; }
        /// <summary>
        /// The API for Lor-Status-v1 endpoint.
        /// </summary>
        ILorStatusApi LorStatus { get; }
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
        /// <summary>
        /// The API for Val-Content-v1 endpoint.
        /// </summary>
        IValContentApi ValContent { get; }
        /// <summary>
        /// <para>The API for Val-Match-v1 endpoint.</para>
        /// <para>Note: This API requires an authorized production API key for access!</para>
        /// </summary>
        IValMatchApi ValMatch { get; }
        /// <summary>
        /// The API for Val-Ranked-v1 endpoint.
        /// </summary>
        IValRankedApi ValRanked { get; }
        /// <summary>
        /// The API for Val-Status-v1 endpoint.
        /// </summary>
        IValStatusApi ValStatus { get; }
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
        private readonly LorMatchApi _lorMatchApi;
        private readonly LorRankedApi _lorRankedApi;
        private readonly LorStatusApi _lorStatusApi;
        private readonly MatchApi _matchApi;
        private readonly SpectatorApi _spectatorApi;
        private readonly SummonerApi _summonerApi;
        private readonly TftLeagueApi _tftLeagueApi;
        private readonly TftMatchApi _tftMatchApi;
        private readonly TftStatusApi _tftStatusApi;
        private readonly TftSummonerApi _tftSummonerApi;
        private readonly ValContentApi _valContentApi;
        private readonly ValMatchApi _valMatchApi;
        private readonly ValRankedApi _valRankedApi;
        private readonly ValStatusApi _valStatusApi;
        private readonly ComposableApi<JsonNode> _jsonNodeApi;
        public IAccountApi Account => _accountApi;
        public IChampionApi Champion => _championApi;
        public IChampionMasteryApi ChampionMastery => _championMasteryApi;
        public IClashApi Clash => _clashApi;
        public ILeagueApi League => _leagueApi;
        public ILolChallengesApi LolChallenges => _lolChallengesApi;
        public ILolStatusApi LolStatus => _lolStatusApi;
        public ILorMatchApi LorMatch => _lorMatchApi;
        public ILorRankedApi LorRanked => _lorRankedApi;
        public ILorStatusApi LorStatus => _lorStatusApi;
        public IMatchApi Match => _matchApi;
        public ISpectatorApi Spectator => _spectatorApi;
        public ISummonerApi Summoner => _summonerApi;
        public ITftLeagueApi TftLeague => _tftLeagueApi;
        public ITftMatchApi TftMatch => _tftMatchApi;
        public ITftStatusApi TftStatus => _tftStatusApi;
        public ITftSummonerApi TftSummoner => _tftSummonerApi;
        public IValContentApi ValContent => _valContentApi;
        public IValMatchApi ValMatch => _valMatchApi;
        public IValRankedApi ValRanked => _valRankedApi;
        public IValStatusApi ValStatus => _valStatusApi;

        public RiotApi(RiotHttpClient riotHttpClient)
        {
            _accountApi = new(riotHttpClient);
            _championApi = new(riotHttpClient);
            _championMasteryApi = new(riotHttpClient);
            _clashApi = new(riotHttpClient);
            _leagueApi = new(riotHttpClient);
            _lolChallengesApi = new(riotHttpClient);
            _lolStatusApi = new(riotHttpClient);
            _lorMatchApi = new(riotHttpClient);
            _lorRankedApi = new(riotHttpClient);
            _lorStatusApi = new(riotHttpClient);
            _matchApi = new(riotHttpClient);
            _spectatorApi = new(riotHttpClient);
            _summonerApi = new(riotHttpClient);
            _tftLeagueApi = new(riotHttpClient);
            _tftMatchApi = new(riotHttpClient);
            _tftStatusApi = new(riotHttpClient);
            _tftSummonerApi = new(riotHttpClient);
            _valContentApi = new(riotHttpClient);
            _valMatchApi = new(riotHttpClient);
            _valRankedApi = new(riotHttpClient);
            _valStatusApi = new(riotHttpClient);
            _jsonNodeApi = new(riotHttpClient);
        }

        public async Task<T> GetAsync<T>(string route, string path)
        {
            JsonNode node = await _jsonNodeApi.GetValueAsync(route, path);
            T data = _jsonNodeApi.Deserialize<T>(node?.AsObject() ?? throw new NullReferenceException("Failed to get object from JSON response"));
            return data;
        }
    }
}
