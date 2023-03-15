using Gwen.Dto.ChampionMastery;
using Gwen.Http;

namespace Gwen.Api
{
	internal class ChampionMasteryApi
	{
		private static readonly string _uri = "/lol/champion-mastery/v4/champion-masteries";
		private static readonly string _masteriesBySummonerId = _uri + "/by-summoner/{0}";
		private static readonly string _masteryBySummonerIdAndChampionId = _masteriesBySummonerId + "/by-champion/{1}";
		private static readonly string _masteriesTopBySummonerId = _masteriesBySummonerId + "/top";
		private static readonly string _scoresBySummonerId = "/lol/champion-mastery/v4/scores/by-summoner/{0}";
		private readonly ComposableApi<IEnumerable<ChampionMasteryDto>> _championMasteriesDtoApi;
		private readonly ComposableApi<ChampionMasteryDto> _championMasteryDtoApi;
		private readonly ComposableApi<int> _intApi;

		public ChampionMasteryApi(RiotGamesClient riotGamesClient)
		{
			_championMasteriesDtoApi = new(riotGamesClient);
			_championMasteryDtoApi = new(riotGamesClient);
			_intApi = new(riotGamesClient);
		}

		/// <summary>
		/// Get an enumerable of all champion mastery entries for summoner ID. Sorted by <see cref="ChampionMasteryDto.ChampionPoints"/>
		/// descending.
		/// </summary>
		/// <param name="summonerId"></param>
		/// <returns></returns>
		public async Task<IEnumerable<ChampionMasteryDto>> ListBySummonerIdAsync(string summonerId)
			=> await _championMasteriesDtoApi.GetDtoAsync(string.Format(_masteriesBySummonerId, summonerId));

		/// <summary>
		/// Get champion mastery entry by player ID and champion ID.
		/// </summary>
		/// <param name="summonerId"></param>
		/// <param name="championId"></param>
		/// <returns></returns>
		public async Task<ChampionMasteryDto> GetBySummonerIdAndChampionIdAsync(string summonerId, string championId)
			=> await _championMasteryDtoApi.GetDtoAsync(string.Format(_masteryBySummonerIdAndChampionId, summonerId, championId));

		/// <summary>
		/// Get an enumerable of requested champion mastery entries sorted by <see cref="ChampionMasteryDto.ChampionPoints"/>
		/// descending.
		/// </summary>
		/// <param name="summonerId"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public async Task<IEnumerable<ChampionMasteryDto>> ListTopBySummonerIdAsync(string summonerId, int count = 3)
			=> await _championMasteriesDtoApi.GetDtoAsync(string.Format(_masteriesTopBySummonerId, summonerId), $"?count=${count}");

		/// <summary>
		/// Get the total summation of individual champion mastery levels for associated summoner ID.
		/// </summary>
		/// <param name="summonerId"></param>
		/// <returns></returns>
		public async Task<int> GetTotalScoreBySummonerIdAsync(string summonerId)
			=> await _intApi.GetDtoAsync(string.Format(_scoresBySummonerId, summonerId));
	}
}
