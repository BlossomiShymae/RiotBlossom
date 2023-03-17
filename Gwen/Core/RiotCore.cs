using Gwen.Api.Riot;
using Gwen.Http;
using Gwen.Type;

namespace Gwen.Core
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
		PlatformRoute PlatformRoute { get; }
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
		private readonly PlatformRoute _platformRoute;
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
		public PlatformRoute PlatformRoute => _platformRoute;

		public RiotCore(RiotHttpClient riotGamesClient, PlatformRoute platformRoute)
		{
			_accountApi = new(riotGamesClient);
			_championApi = new(riotGamesClient);
			_championMasteryApi = new(riotGamesClient);
			_clashApi = new(riotGamesClient);
			_leagueApi = new(riotGamesClient);
			_lolChallengesApi = new(riotGamesClient);
			_lolStatusApi = new(riotGamesClient);
			_matchApi = new(riotGamesClient);
			_spectatorApi = new(riotGamesClient);
			_summonerApi = new(riotGamesClient);
			_platformRoute = platformRoute;
		}
	}
}
