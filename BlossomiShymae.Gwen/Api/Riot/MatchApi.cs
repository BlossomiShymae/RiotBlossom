using BlossomiShymae.Gwen.Core;
using BlossomiShymae.Gwen.Dto.Riot.Match;
using BlossomiShymae.Gwen.Exception;
using BlossomiShymae.Gwen.Http;
using BlossomiShymae.Gwen.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.Gwen.Api.Riot
{
    public interface IMatchApi
    {
        /// <summary>
        /// Get a match by ID.
        /// </summary>
        /// <exception cref="CorruptedMatchException"></exception>
        /// <param name="regionalRoute"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchDto> GetByIdAsync(RegionalRoute regionalRoute, string id);
        /// <summary>
        /// Get a match timeline by ID.
        /// </summary>
        /// <exception cref="CorruptedMatchException"></exception>
        /// <param name="regionalRoute"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchTimelineDto> GetTimelineByIdAsync(RegionalRoute regionalRoute, string id);
        /// <summary>
        /// List the last 20 most recent match IDs for encrypted PUUID.
        /// </summary>
        /// <param name="regionalRoute"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<ImmutableList<string>> ListIdsByPuuidAsync(RegionalRoute regionalRoute, string puuid);
        /// <summary>
        /// List the match IDs for encrypted PUUID with given option constraints.
        /// </summary>
        /// <param name="regionalRoute"></param>
        /// <param name="puuid"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<ImmutableList<string>> ListIdsByPuuidAsync(RegionalRoute regionalRoute, string puuid, ListIdsByPuuidAsyncOptions parameters);
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

        public async Task<ImmutableList<string>> ListIdsByPuuidAsync(RegionalRoute regionalRoute, string puuid)
        {
            List<string> ids = await _stringsApi.GetValueAsync(RegionRouteMapper.GetRegion(regionalRoute), string.Format(_matchIdsByPuuidUri, puuid));
            return ids.ToImmutableList();
        }

        public async Task<ImmutableList<string>> ListIdsByPuuidAsync(RegionalRoute regionalRoute, string puuid, ListIdsByPuuidAsyncOptions parameters)
        {
            List<string> ids = await _stringsApi.GetValueAsync(RegionRouteMapper.GetRegion(regionalRoute), string.Format(_matchIdsByPuuidUri, puuid) + PropertiesToQueryConverter.ToQuery(parameters));
            return ids.ToImmutableList();
        }

        public async Task<MatchDto> GetByIdAsync(RegionalRoute regionalRoute, string id)
        {
            MatchDto match = await _matchApi.GetValueAsync(RegionRouteMapper.GetRegion(regionalRoute), string.Format(_matchByMatchIdUri, id));
            if (IsCorrupted(match))
                throw new CorruptedMatchException(match.Metadata.MatchId);
            return match;
        }

        public async Task<MatchTimelineDto> GetTimelineByIdAsync(RegionalRoute regionalRoute, string id)
        {
            MatchTimelineDto matchTimelineDto = await _matchTimelineApi.GetValueAsync(RegionRouteMapper.GetRegion(regionalRoute), string.Format(_matchTimelineByMatchIdUri, id));
            if (IsCorrupted(matchTimelineDto))
                throw new CorruptedMatchException(matchTimelineDto.Metadata.MatchId);
            return matchTimelineDto;
        }

        private static bool IsCorrupted(object dto)
        {
            if (dto is MatchDto match)
                return match.Info.GameCreation == 0;
            if (dto is MatchTimelineDto timeline)
                return timeline.Info.FrameInterval == 0;
            throw new NotImplementedException();
        }
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
