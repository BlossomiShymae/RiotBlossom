using Gwen.Api;
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
		/// The API for Champion-Mastery-v4 endpoints.
		/// </summary>
		IChampionMasteryApi ChampionMastery { get; }
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
		private readonly ChampionMasteryApi _championMasteryApi;
		private readonly SummonerApi _summonerApi;
		private readonly PlatformRoute _platformRoute;
		/// <inheritdoc/>
		public IAccountApi Account { get { return _accountApi; } }
		/// <inheritdoc/>
		public IChampionMasteryApi ChampionMastery { get { return _championMasteryApi; } }
		/// <inheritdoc/>
		public ISummonerApi Summoner { get { return _summonerApi; } }
		/// <inheritdoc/>
		public PlatformRoute PlatformRoute { get { return _platformRoute; } }

		public RiotCore(RiotGamesClient riotGamesClient, PlatformRoute platformRoute)
		{
			_accountApi = new(riotGamesClient);
			_championMasteryApi = new(riotGamesClient);
			_summonerApi = new(riotGamesClient);
			_platformRoute = platformRoute;
		}
	}
}
