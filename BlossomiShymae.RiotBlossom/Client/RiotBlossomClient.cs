using System.Reflection.PortableExecutable;
using System.Security;
using BlossomiShymae.RiotBlossom.Api.Client.Apis.Tft;
using BlossomiShymae.RiotBlossom.Apis.Lol;
using BlossomiShymae.RiotBlossom.Client.Apis.Lol;
using BlossomiShymae.RiotBlossom.Client.Apis.Lor;
using BlossomiShymae.RiotBlossom.Client.Apis.Riot;
using BlossomiShymae.RiotBlossom.Client.Apis.Static;
using BlossomiShymae.RiotBlossom.Client.Apis.Tft;
using BlossomiShymae.RiotBlossom.Client.Apis.Val;
using BlossomiShymae.RiotBlossom.Core;
using Microsoft.Extensions.Logging;

namespace BlossomiShymae.RiotBlossom.Client
{
    /// <summary>
    /// A client use to access Riot Games, DataDragon, CommunityDragon, and Meraki Analytics APIs.
    /// </summary>
    public interface IRiotBlossomClient
    {
        IChampionMasteryV4Api ChampionMasteryV4 { get; }
        IChampionV3Api ChampionV3 { get; }
        IClashV1Api ClashV1 { get; }
        ILeagueV4Api LeagueV4 { get; }
        ILolChallengesV1Api LolChallengesV1 { get; }
        ILolStatusV4Api LolStatusV4 { get; }
        IMatchV5Api MatchV5 { get; }
        ISpectatorV4Api SpectatorV4 { get; }
        ISummonerV4Api SummonerV4 { get; }

        ILorMatchV1Api LorMatchV1 { get; }
        ILorRankedV1Api LorRankedV1 { get; }
        ILorStatusV1Api LorStatusV1 { get; }

        IAccountV1Api AccountV1 { get; }

        ITftLeagueV1Api TftLeagueV1 { get; }
        ITftMatchV1Api TftMatchV1 { get; }
        ITftStatusV1Api TftStatusV1 { get; }
        ITftSummonerV1Api TftSummonerV1 { get; }

        IValContentV1Api ValContentV1 { get; }
        IValMatchV1Api ValMatchV1 { get; }
        IValRankedV1Api ValRankedV1 { get; }
        IValStatusV1Api ValStatusV1 { get; }

        IDataDragonApi DataDragon { get; }
        ICommunityDragonApi CommunityDragon { get; }
        IMerakiAnalyticsApi MerakiAnalytics { get; }

        ApiConfiguration ApiConfiguration { get; }
    }

    public class RiotBlossomClient : IRiotBlossomClient
    {
        private readonly IChampionMasteryV4Api _championMasteryV4Api;
        private readonly IChampionV3Api _championV3Api;
        private readonly IClashV1Api _clashV1Api;
        private readonly ILeagueV4Api _leagueV4Api;
        private readonly ILolChallengesV1Api _lolChallengesV1Api;
        private readonly ILolStatusV4Api _lolStatusV4Api;
        private readonly IMatchV5Api _matchV5Api;
        private readonly ISpectatorV4Api _spectatorV4Api;
        private readonly ISummonerV4Api _summonerV4Api;

        private readonly ILorMatchV1Api _lorMatchV1Api;
        private readonly ILorRankedV1Api _lorRankedV1Api;
        private readonly ILorStatusV1Api _lorStatusV1Api;

        private readonly IAccountV1Api _accountV1Api;

        private readonly ITftLeagueV1Api _tftLeagueV1Api;
        private readonly ITftMatchV1Api _tftMatchV1Api;
        private readonly ITftStatusV1Api _tftStatusV1Api;
        private readonly ITftSummonerV1Api _tftSummonerV1Api;

        private readonly IValContentV1Api _valContentV1Api;
        private readonly IValMatchV1Api _valMatchV1Api;
        private readonly IValRankedV1Api _valRankedV1Api;
        private readonly IValStatusV1Api _valStatusV1Api;

        private readonly IDataDragonApi _dataDragonApi;
        private readonly ICommunityDragonApi _communityDragonApi;
        private readonly IMerakiAnalyticsApi _merakiAnalyticsApi;

        private readonly ApiConfiguration _apiConfiguration;

        public IChampionMasteryV4Api ChampionMasteryV4 => _championMasteryV4Api;
        public IChampionV3Api ChampionV3 => _championV3Api;
        public IClashV1Api ClashV1 => _clashV1Api;
        public ILeagueV4Api LeagueV4 => _leagueV4Api;
        public ILolChallengesV1Api LolChallengesV1 => _lolChallengesV1Api;
        public ILolStatusV4Api LolStatusV4 => _lolStatusV4Api;
        public IMatchV5Api MatchV5 => _matchV5Api;
        public ISpectatorV4Api SpectatorV4 => _spectatorV4Api;
        public ISummonerV4Api SummonerV4 => _summonerV4Api;

        public ILorMatchV1Api LorMatchV1 => _lorMatchV1Api;
        public ILorRankedV1Api LorRankedV1 => _lorRankedV1Api;
        public ILorStatusV1Api LorStatusV1 => _lorStatusV1Api;

        public IAccountV1Api AccountV1 => _accountV1Api;

        public ITftLeagueV1Api TftLeagueV1 => _tftLeagueV1Api;
        public ITftMatchV1Api TftMatchV1 => _tftMatchV1Api;
        public ITftStatusV1Api TftStatusV1 => _tftStatusV1Api;
        public ITftSummonerV1Api TftSummonerV1 => _tftSummonerV1Api;

        public IValContentV1Api ValContentV1 => _valContentV1Api;
        public IValMatchV1Api ValMatchV1 => _valMatchV1Api;
        public IValRankedV1Api ValRankedV1 => _valRankedV1Api;
        public IValStatusV1Api ValStatusV1 => _valStatusV1Api;

        public IDataDragonApi DataDragon => _dataDragonApi;
        public ICommunityDragonApi CommunityDragon => _communityDragonApi;
        public IMerakiAnalyticsApi MerakiAnalytics => _merakiAnalyticsApi;

        public ApiConfiguration ApiConfiguration => _apiConfiguration;

        public static IRiotBlossomClient Create()
        {
            string? key = null;
            
            try
            {
                key = Environment.GetEnvironmentVariable("RIOT_API_KEY");
            }
            catch (ArgumentNullException)
            {

            }
            catch (SecurityException)
            {

            }

            return new RiotBlossomClient(new() { Key = key });
        }

        public static IRiotBlossomClient Create(string key)
        {
            return new RiotBlossomClient(new() { Key = key });
        }

        public static IRiotBlossomClient Create(ApiConfiguration configuration)
        {
            return new RiotBlossomClient(configuration);
        }
       
        private RiotBlossomClient(ApiConfiguration configuration)
        {
            _championMasteryV4Api = new ChampionMasteryV4Api(configuration);
            _championV3Api = new ChampionV3Api(configuration);
            _clashV1Api = new ClashV1Api(configuration);
            _leagueV4Api = new LeagueV4Api(configuration);
            _lolChallengesV1Api = new LolChallengesV1Api(configuration);
            _lolStatusV4Api = new LolStatusV4Api(configuration);
            _matchV5Api = new MatchV5Api(configuration);
            _spectatorV4Api = new SpectatorV4Api(configuration);
            _summonerV4Api = new SummonerV4Api(configuration);

            _lorMatchV1Api = new LorMatchV1Api(configuration);
            _lorRankedV1Api = new LorRankedV1Api(configuration);
            _lorStatusV1Api = new LorStatusV1Api(configuration);

            _accountV1Api = new AccountV1Api(configuration);

            _tftLeagueV1Api = new TftLeagueV1Api(configuration);
            _tftMatchV1Api = new TftMatchV1Api(configuration);
            _tftStatusV1Api = new TftStatusV1Api(configuration);
            _tftSummonerV1Api = new TftSummonerV1Api(configuration);

            _valContentV1Api = new ValContentV1Api(configuration);
            _valMatchV1Api = new ValMatchV1Api(configuration);
            _valRankedV1Api = new ValRankedV1Api(configuration);
            _valStatusV1Api = new ValStatusV1Api(configuration);

            _dataDragonApi = new DataDragonApi(configuration);
            _communityDragonApi = new CommunityDragonApi(configuration);
            _merakiAnalyticsApi = new MerakiAnalyticsApi(configuration);

            _apiConfiguration = configuration;

            configuration.Logger.LogDebug("Initialized RiotBlossomClient");
        }
    }
}
