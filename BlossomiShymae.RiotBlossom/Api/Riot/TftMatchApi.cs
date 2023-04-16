using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.TftMatch;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface ITftMatchApi
    {
        /// <summary>
        /// Get a match by ID.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchDto> GetByIdAsync(Region region, string id);
        /// <summary>
        /// Get a match by ID.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchDto> GetByIdAsync(Platform platform, string id);
        /// <summary>
        /// List the last 20 most recent match IDs for encrypted PUUID.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<ImmutableList<string>> ListIdsByPuuidAsync(Region region, string puuid);
        /// <summary>
        /// List the last 20 most recent match IDs for encrypted PUUID.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<ImmutableList<string>> ListIdsByPuuidAsync(Platform platform, string puuid);
        /// <summary>
        /// List the match IDs for encrypted PUUID with given option constraints.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="puuid"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<ImmutableList<string>> ListIdsByPuuidAsync(Region region, string puuid, TftListIdsByPuuidAsyncOptions options);
        /// <summary>
        /// List the match IDs for encrypted PUUID with given option constraints.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="puuid"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<ImmutableList<string>> ListIdsByPuuidAsync(Platform platform, string puuid, TftListIdsByPuuidAsyncOptions options);
    }

    internal class TftMatchApi : ITftMatchApi
    {
        private static readonly string s_uri = "/tft/match/v1/matches";
        private static readonly string s_matchIdsByPuuidUri = s_uri + "/by-puuid/{0}/ids";
        private static readonly string s_matchByMatchIdUri = s_uri + "/{0}";
        private readonly ComposableApi<List<string>> _stringsApi;
        private readonly ComposableApi<MatchDto> _matchApi;

        public TftMatchApi(RiotHttpClient riotHttpClient)
        {
            _stringsApi = new(riotHttpClient);
            _matchApi = new(riotHttpClient);
        }

        public async Task<MatchDto> GetByIdAsync(Region region, string id)
        {
            MatchDto match = await _matchApi.GetValueAsync(RegionMapper.GetId(region), string.Format(s_matchByMatchIdUri, id));
            return match;
        }

        public async Task<MatchDto> GetByIdAsync(Platform platform, string id)
            => await GetByIdAsync(PlatformToRegionConverter.ToRegion(platform), id);

        public async Task<ImmutableList<string>> ListIdsByPuuidAsync(Region region, string puuid)
        {
            List<string> ids = await _stringsApi.GetValueAsync(RegionMapper.GetId(region), string.Format(s_matchIdsByPuuidUri, puuid));
            return ids.ToImmutableList();
        }

        public async Task<ImmutableList<string>> ListIdsByPuuidAsync(Platform platform, string puuid)
            => await ListIdsByPuuidAsync(PlatformToRegionConverter.ToRegion(platform), puuid);

        public async Task<ImmutableList<string>> ListIdsByPuuidAsync(Region region, string puuid, TftListIdsByPuuidAsyncOptions options)
        {
            List<string> ids = await _stringsApi.GetValueAsync(RegionMapper.GetId(region), string.Format(s_matchIdsByPuuidUri, puuid) + PropertiesToQueryConverter.ToQuery(options));
            return ids.ToImmutableList();
        }

        public async Task<ImmutableList<string>> ListIdsByPuuidAsync(Platform platform, string puuid, TftListIdsByPuuidAsyncOptions options)
            => await ListIdsByPuuidAsync(PlatformToRegionConverter.ToRegion(platform), puuid, options);
    }

    public record TftListIdsByPuuidAsyncOptions
    {
        public int? Start { get; init; }
        public long? EndTime { get; init; }
        public long? StartTime { get; init; }
        public int? Count { get; init; }
    }
}
