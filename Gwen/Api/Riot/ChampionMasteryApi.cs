using Gwen.Core;
using Gwen.Dto.Riot.ChampionMastery;
using Gwen.Http;
using Gwen.Type;

namespace Gwen.Api.Riot
{
	public interface IChampionMasteryApi
	{
		/// <summary>
		/// Get champion mastery entry by player ID and champion ID.
		/// </summary>
		/// <param name="summonerId"></param>
		/// <param name="championId"></param>
		/// <returns></returns>
		Task<ChampionMasteryDto> GetBySummonerIdAndChampionIdAsync(PlatformRoute platformRoute, string summonerId, string championId);

		/// <summary>
		/// Get the total summation of individual champion mastery levels for associated summoner ID.
		/// </summary>
		/// <param name="summonerId"></param>
		/// <returns></returns>
		Task<int> GetTotalScoreBySummonerIdAsync(PlatformRoute platformRoute, string summonerId);

		/// <summary>
		/// Get an enumerable of all champion mastery entries for summoner ID. Sorted by <see cref="ChampionMasteryDto.ChampionPoints"/>
		/// descending.
		/// </summary>
		/// <param name="summonerId"></param>
		/// <returns></returns>
		Task<IEnumerable<ChampionMasteryDto>> ListBySummonerIdAsync(PlatformRoute platformRoute, string summonerId);

		/// <summary>
		/// Get an enumerable of requested champion mastery entries sorted by <see cref="ChampionMasteryDto.ChampionPoints"/>
		/// descending.
		/// </summary>
		/// <param name="summonerId"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		Task<IEnumerable<ChampionMasteryDto>> ListTopBySummonerIdAsync(PlatformRoute platformRoute, string summonerId, int count = 3);
	}

	internal class ChampionMasteryApi : IChampionMasteryApi
	{
		private static readonly string _uri = "/lol/champion-mastery/v4/champion-masteries";
		private static readonly string _masteriesBySummonerId = _uri + "/by-summoner/{0}";
		private static readonly string _masteryBySummonerIdAndChampionId = _masteriesBySummonerId + "/by-champion/{1}";
		private static readonly string _masteriesTopBySummonerId = _masteriesBySummonerId + "/top";
		private static readonly string _scoresBySummonerId = "/lol/champion-mastery/v4/scores/by-summoner/{0}";
		private readonly ComposableApi<IEnumerable<ChampionMasteryDto>> _championMasteriesDtoApi;
		private readonly ComposableApi<ChampionMasteryDto> _championMasteryDtoApi;
		private readonly ComposableApi<int> _intApi;

		public ChampionMasteryApi(RiotHttpClient riotGamesClient)
		{
			_championMasteriesDtoApi = new(riotGamesClient);
			_championMasteryDtoApi = new(riotGamesClient);
			_intApi = new(riotGamesClient);
		}

		public async Task<IEnumerable<ChampionMasteryDto>> ListBySummonerIdAsync(PlatformRoute platformRoute, string summonerId)
			=> await _championMasteriesDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(_masteriesBySummonerId, summonerId));

		public async Task<ChampionMasteryDto> GetBySummonerIdAndChampionIdAsync(PlatformRoute platformRoute, string summonerId, string championId)
			=> await _championMasteryDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(_masteryBySummonerIdAndChampionId, summonerId, championId));

		public async Task<IEnumerable<ChampionMasteryDto>> ListTopBySummonerIdAsync(PlatformRoute platformRoute, string summonerId, int count = 3)
			=> await _championMasteriesDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(_masteriesTopBySummonerId, summonerId) + $"?count=${count}");

		public async Task<int> GetTotalScoreBySummonerIdAsync(PlatformRoute platformRoute, string summonerId)
			=> await _intApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(_scoresBySummonerId, summonerId));
	}
}
