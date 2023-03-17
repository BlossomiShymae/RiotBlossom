using Gwen.Core;
using Gwen.Dto.Riot.Match;
using Gwen.Http;

namespace Gwen.Api.Riot
{
    public interface IMatchApi
	{
		/// <summary>
		/// Get a match by ID/
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<MatchDto> GetByIdAsync(string id);
		/// <summary>
		/// Get a match timeline by ID.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<MatchTimelineDto> GetTimelineByIdAsync(string id);
		/// <summary>
		/// List the last 20 most recent match IDs for encrypted PUUID.
		/// </summary>
		/// <param name="puuid"></param>
		/// <returns></returns>
		Task<IEnumerable<string>> ListIdsByPuuidAsync(string puuid);
		/// <summary>
		/// List the match IDs for encrypted PUUID with given option constraints.
		/// </summary>
		/// <param name="puuid"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		Task<IEnumerable<string>> ListIdsByPuuidAsync(string puuid, ListIdsByPuuidAsyncOptions parameters);
	}

	internal class MatchApi : IMatchApi
	{
		private static readonly string _uri = "/lol/match/v5/matches";
		private static readonly string _matchIdsByPuuidUri = _uri + "/by-puuid/{0}/ids";
		private static readonly string _matchByMatchIdUri = _uri + "/{0}";
		private static readonly string _matchTimelineByMatchIdUri = _matchByMatchIdUri + "/timeline";
		private readonly ComposableApi<IEnumerable<string>> _stringsApi;
		private readonly ComposableApi<MatchDto> _matchApi;
		private readonly ComposableApi<MatchTimelineDto> _matchTimelineApi;

		public MatchApi(RiotHttpClient riotGamesClient)
		{
			_stringsApi = new(riotGamesClient);
			_matchApi = new(riotGamesClient);
			_matchTimelineApi = new(riotGamesClient);
		}

		public async Task<IEnumerable<string>> ListIdsByPuuidAsync(string puuid)
			=> await _stringsApi.GetValueAsync(string.Format(_matchIdsByPuuidUri, puuid));

		public async Task<IEnumerable<string>> ListIdsByPuuidAsync(string puuid, ListIdsByPuuidAsyncOptions parameters)
			=> await _stringsApi.GetValueAsync(string.Format(_matchIdsByPuuidUri, puuid) + PropertiesToQueryConverter.ToQuery(parameters));

		public async Task<MatchDto> GetByIdAsync(string id)
			=> await _matchApi.GetValueAsync(string.Format(_matchByMatchIdUri, id));

		public async Task<MatchTimelineDto> GetTimelineByIdAsync(string id)
			=> await _matchTimelineApi.GetValueAsync(string.Format(_matchTimelineByMatchIdUri, id));
	}

	public record ListIdsByPuuidAsyncOptions
	{
		public long? StartTime { get; init; }
		public long? EndTime { get; init; }
		public int? Queue { get; init; }
		public string? Type { get; init; }
		public int? Start { get; init; }
		public int? Count { get; init; }
	}
}
