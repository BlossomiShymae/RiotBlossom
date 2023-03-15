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
		private readonly SummonerApi _summonerApi;
		private readonly PlatformRoute _platformRoute;
		/// <inheritdoc/>
		public IAccountApi Account => _accountApi;
		/// <inheritdoc/>
		public IChampionApi Champion => _championApi;
		/// <inheritdoc/>
		public IChampionMasteryApi ChampionMastery => _championMasteryApi;
		/// <inheritdoc/>
		public IClashApi Clash => _clashApi;
		/// <inheritdoc/>
		public ISummonerApi Summoner => _summonerApi;
		/// <inheritdoc/>
		public PlatformRoute PlatformRoute => _platformRoute;

		public RiotCore(RiotGamesClient riotGamesClient, PlatformRoute platformRoute)
		{
			_accountApi = new(riotGamesClient);
			_championApi = new(riotGamesClient);
			_championMasteryApi = new(riotGamesClient);
			_clashApi = new(riotGamesClient);
			_summonerApi = new(riotGamesClient);
			_platformRoute = platformRoute;
		}
	}
}
