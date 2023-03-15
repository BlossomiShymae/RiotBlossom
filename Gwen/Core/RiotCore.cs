using Gwen.Api;
using Gwen.Http;

namespace Gwen.Core
{
	internal class RiotCore
	{
		private readonly AccountApi _accountApi;
		private readonly ChampionMasteryApi _championMasteryApi;
		private readonly SummonerApi _summonerApi;
		private readonly Type.PlatformRoute _platformRoute;
		/// <summary>
		/// The API for Account-v1 endpoints.
		/// </summary>
		public AccountApi Account { get { return _accountApi; } }
		/// <summary>
		/// The API for Champion-Mastery-v4 endpoints.
		/// </summary>
		public ChampionMasteryApi ChampionMastery { get { return _championMasteryApi; } }
		/// <summary>
		/// The API for Summoner-v4 endpoints.
		/// </summary>
		public SummonerApi Summoner { get { return _summonerApi; } }
		/// <summary>
		/// The platform routing value used for accessing data from.
		/// </summary>
		public Type.PlatformRoute PlatformRoute { get { return _platformRoute; } }

		public RiotCore(RiotGamesClient riotGamesClient, Type.PlatformRoute platformRoute)
		{
			_accountApi = new(riotGamesClient);
			_championMasteryApi = new(riotGamesClient);
			_summonerApi = new(riotGamesClient);
			_platformRoute = platformRoute;
		}
	}
}
