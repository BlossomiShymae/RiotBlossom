using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Match;
using BlossomiShymae.RiotBlossom.Exception;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Api.Riot
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
        Task<MatchDto> GetByIdAsync(Region regionalRoute, string id);
        /// <summary>
        /// Get a match by ID.
        /// </summary>
        /// <exception cref="CorruptedMatchException"></exception>
        /// <param name="platformRoute"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchDto> GetByIdAsync(Platform platformRoute, string id);
        /// <summary>
        /// Get a match timeline by ID.
        /// </summary>
        /// <exception cref="CorruptedMatchException"></exception>
        /// <param name="regionalRoute"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchTimelineDto> GetTimelineByIdAsync(Region regionalRoute, string id);
        /// <summary>
        /// Get a match timeline by ID.
        /// </summary>
        /// <exception cref="CorruptedMatchException"></exception>
        /// <param name="platformRoute"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchTimelineDto> GetTimelineByIdAsync(Platform platformRoute, string id);
        /// <summary>
        /// List the last 20 most recent match IDs for encrypted PUUID.
        /// </summary>
        /// <param name="regionalRoute"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<ImmutableList<string>> ListIdsByPuuidAsync(Region regionalRoute, string puuid);
        /// <summary>
        /// List the last 20 most recent match IDs for encrypted PUUID.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<ImmutableList<string>> ListIdsByPuuidAsync(Platform platformRoute, string puuid);
        /// <summary>
        /// List the match IDs for encrypted PUUID with given option constraints.
        /// </summary>
        /// <param name="regionalRoute"></param>
        /// <param name="puuid"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<ImmutableList<string>> ListIdsByPuuidAsync(Region regionalRoute, string puuid, ListIdsByPuuidAsyncOptions parameters);
        /// <summary>
        /// List the match IDs for encrypted PUUID with given option constraints.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="puuid"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<ImmutableList<string>> ListIdsByPuuidAsync(Platform platformRoute, string puuid, ListIdsByPuuidAsyncOptions parameters);
    }

    internal class MatchApi : IMatchApi
    {
        private static readonly string s_uri = "/lol/match/v5/matches";
        private static readonly string s_matchIdsByPuuidUri = s_uri + "/by-puuid/{0}/ids";
        private static readonly string s_matchByMatchIdUri = s_uri + "/{0}";
        private static readonly string s_matchTimelineByMatchIdUri = s_matchByMatchIdUri + "/timeline";
        private readonly ComposableApi<List<string>> _stringsApi;
        private readonly ComposableApi<MatchDto> _matchApi;
        private readonly ComposableApi<MatchTimelineDto> _matchTimelineApi;

        public MatchApi(RiotHttpClient riotGamesClient)
        {
            _stringsApi = new(riotGamesClient);
            _matchApi = new(riotGamesClient);
            _matchTimelineApi = new(riotGamesClient);
        }

        public async Task<ImmutableList<string>> ListIdsByPuuidAsync(Region regionalRoute, string puuid)
        {
            List<string> ids = await _stringsApi.GetValueAsync(RegionMapper.GetId(regionalRoute), string.Format(s_matchIdsByPuuidUri, puuid));
            return ids.ToImmutableList();
        }

        public async Task<ImmutableList<string>> ListIdsByPuuidAsync(Region regionalRoute, string puuid, ListIdsByPuuidAsyncOptions parameters)
        {
            List<string> ids = await _stringsApi.GetValueAsync(RegionMapper.GetId(regionalRoute), string.Format(s_matchIdsByPuuidUri, puuid) + PropertiesToQueryConverter.ToQuery(parameters));
            return ids.ToImmutableList();
        }

        public async Task<MatchDto> GetByIdAsync(Region regionalRoute, string id)
        {
            MatchDto match = await _matchApi.GetValueAsync(RegionMapper.GetId(regionalRoute), string.Format(s_matchByMatchIdUri, id));
            if (IsCorrupted(match))
                throw new CorruptedMatchException(match.Metadata.MatchId);
            return match;
        }

        public async Task<MatchTimelineDto> GetTimelineByIdAsync(Region regionalRoute, string id)
        {
            MatchTimelineDto matchTimelineDto = await _matchTimelineApi.GetValueAsync(RegionMapper.GetId(regionalRoute), string.Format(s_matchTimelineByMatchIdUri, id));
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

        public async Task<MatchDto> GetByIdAsync(Platform platformRoute, string id)
            => await GetByIdAsync(PlatformToRegionConverter.ToRegion(platformRoute), id);

        public async Task<MatchTimelineDto> GetTimelineByIdAsync(Platform platformRoute, string id)
            => await GetTimelineByIdAsync(PlatformToRegionConverter.ToRegion(platformRoute), id);

        public async Task<ImmutableList<string>> ListIdsByPuuidAsync(Platform platformRoute, string puuid)
            => await ListIdsByPuuidAsync(PlatformToRegionConverter.ToRegion(platformRoute), puuid);

        public async Task<ImmutableList<string>> ListIdsByPuuidAsync(Platform platformRoute, string puuid, ListIdsByPuuidAsyncOptions parameters)
            => await ListIdsByPuuidAsync(PlatformToRegionConverter.ToRegion(platformRoute), puuid, parameters);
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
