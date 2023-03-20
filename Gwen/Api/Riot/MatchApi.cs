using Gwen.Core;
using Gwen.Dto.Riot.Match;
using Gwen.Http;
using Gwen.Type;
using System.Collections.ObjectModel;

namespace Gwen.Api.Riot
{
	public interface IMatchApi
	{
		/// <summary>
		/// Get a match by ID/
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<MatchDto> GetByIdAsync(RegionalRoute regionalRoute, string id);
		/// <summary>
		/// Get a match timeline by ID.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<MatchTimelineDto> GetTimelineByIdAsync(RegionalRoute regionalRoute, string id);
		/// <summary>
		/// List the last 20 most recent match IDs for encrypted PUUID.
		/// </summary>
		/// <param name="puuid"></param>
		/// <returns></returns>
		Task<ReadOnlyCollection<string>> ListIdsByPuuidAsync(RegionalRoute regionalRoute, string puuid);
		/// <summary>
		/// List the match IDs for encrypted PUUID with given option constraints.
		/// </summary>
		/// <param name="puuid"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		Task<ReadOnlyCollection<string>> ListIdsByPuuidAsync(RegionalRoute regionalRoute, string puuid, ListIdsByPuuidAsyncOptions parameters);
	}

	internal class MatchApi : IMatchApi
	{
		private static readonly string _uri = "/lol/match/v5/matches";
		private static readonly string _matchIdsByPuuidUri = _uri + "/by-puuid/{0}/ids";
		private static readonly string _matchByMatchIdUri = _uri + "/{0}";
		private static readonly string _matchTimelineByMatchIdUri = _matchByMatchIdUri + "/timeline";
		private readonly ComposableApi<List<string>> _stringsApi;
		private readonly ComposableApi<MatchDto> _matchApi;
		private readonly ComposableApi<MatchTimelineDto> _matchTimelineApi;

		public MatchApi(RiotHttpClient riotGamesClient)
		{
			_stringsApi = new(riotGamesClient);
			_matchApi = new(riotGamesClient);
			_matchTimelineApi = new(riotGamesClient);
		}

		public async Task<ReadOnlyCollection<string>> ListIdsByPuuidAsync(RegionalRoute regionalRoute, string puuid)
		{
			List<string> ids = await _stringsApi.GetValueAsync(RegionRouteMapper.GetRegion(regionalRoute), string.Format(_matchIdsByPuuidUri, puuid));
			return ids.AsReadOnly();
		}

		public async Task<ReadOnlyCollection<string>> ListIdsByPuuidAsync(RegionalRoute regionalRoute, string puuid, ListIdsByPuuidAsyncOptions parameters)
		{
			List<string> ids = await _stringsApi.GetValueAsync(RegionRouteMapper.GetRegion(regionalRoute), string.Format(_matchIdsByPuuidUri, puuid) + PropertiesToQueryConverter.ToQuery(parameters));
			return ids.AsReadOnly();
		}

		public async Task<MatchDto> GetByIdAsync(RegionalRoute regionalRoute, string id)
			=> await _matchApi.GetValueAsync(RegionRouteMapper.GetRegion(regionalRoute), string.Format(_matchByMatchIdUri, id));

		public async Task<MatchTimelineDto> GetTimelineByIdAsync(RegionalRoute regionalRoute, string id)
			=> await _matchTimelineApi.GetValueAsync(RegionRouteMapper.GetRegion(regionalRoute), string.Format(_matchTimelineByMatchIdUri, id));
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
