using Gwen.Dto.ChampionMastery;
using Gwen.Http;

namespace Gwen.Api
{
	public static class ChampionMasteryApi
	{
		private static readonly string _uri = "/lol/champion-mastery/v4/champion-masteries";
		private static readonly string _masteriesBySummonerId = _uri + "/by-summoner/{0}";
		private static readonly string _masteryBySummonerIdAndChampionId = _masteriesBySummonerId + "/by-champion/{1}";
		private static readonly string _masteriesTopBySummonerId = _masteriesBySummonerId + "/top";
		private static readonly string _scoresBySummonerId = "/lol/champion-mastery/v4/scores/by-summoner/{0}";

		public static Api.UseByRoutingValue<Container>
			Use(HttpClient client, string riotApiKey, XMiddlewares middlewares) =>
			(routingValue) =>
			{
				RiotGamesClient.GetAsyncFunc func = RiotGamesClient.GetAsync(client, riotApiKey, routingValue, middlewares);
				return new Container
				{
					GetChampionMasteriesBySummonerIdAsync = (string summonerId) =>
						Api.GetDtoAsync<IEnumerable<ChampionMasteryDto>>(func)(string.Format(_masteriesBySummonerId, summonerId), string.Empty),
					GetChampionMasteryByPlayerIdAndChampionIdAsync = (string summonerId, string championId) =>
						Api.GetDtoAsync<ChampionMasteryDto>(func)(string.Format(_masteryBySummonerIdAndChampionId, summonerId, championId), string.Empty),
					GetTopChampionMasteriesBySummonerIdAsync = (string summonerId, int count) =>
						Api.GetDtoAsync<IEnumerable<ChampionMasteryDto>>(func)(string.Format(_masteriesTopBySummonerId, summonerId), $"?count={count}"),
					GetTotalChampionMasteryScoreBySummonerIdAsync = (string summonerId) =>
						Api.GetDtoAsync<int>(func)(string.Format(_scoresBySummonerId, summonerId), string.Empty)
				};
			};

		public record Container
		{
			/// <summary>
			/// Get a <see cref="IEnumerable{T}"/> of all <see cref="ChampionMasteryDto"/> for summoner ID. Sorted by <see cref="ChampionMasteryDto.ChampionPoints"/> descending.
			/// </summary>
			public GetChampionMasteriesBySummonerIdAsyncFunc GetChampionMasteriesBySummonerIdAsync { get; init; } = default!;
			/// <summary>
			/// Get a <see cref="ChampionMasteryDto"/> by player ID and champion ID.
			/// </summary>
			public GetChampionMasteryByPlayerIdAndChampionIdAsyncFunc GetChampionMasteryByPlayerIdAndChampionIdAsync { get; init; } = default!;
			/// <summary>
			/// Get a <see cref="IEnumerable{T}"/> of requested <see cref="ChampionMasteryDto"/> sorted by <see cref="ChampionMasteryDto.ChampionPoints"/> descending.
			/// </summary>
			public GetTopChampionMasteriesBySummonerIdAsyncFunc GetTopChampionMasteriesBySummonerIdAsync { get; init; } = default!;
			/// <summary>
			/// Get the total summation of individual champion mastery levels for associated summoner ID.
			/// </summary>
			public GetTotalChampionMasteryScoreBySummonerIdAsyncFunc GetTotalChampionMasteryScoreBySummonerIdAsync { get; init; } = default!;
		}

		public delegate Task<IEnumerable<ChampionMasteryDto>> GetChampionMasteriesBySummonerIdAsyncFunc(string summonerId);
		public delegate Task<ChampionMasteryDto> GetChampionMasteryByPlayerIdAndChampionIdAsyncFunc(string summonerId, string championId);
		public delegate Task<IEnumerable<ChampionMasteryDto>> GetTopChampionMasteriesBySummonerIdAsyncFunc(string summonerId, int count);
		public delegate Task<int> GetTotalChampionMasteryScoreBySummonerIdAsyncFunc(string summonerId);
	}
}
