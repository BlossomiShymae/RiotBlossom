using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface IValMatchApi
    {
        /// <summary>
        /// Get a VALORANT match by ID.
        /// </summary>
        /// <param name="valRegion"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchDto> GetByIdAsync(ValRegion valRegion, string id);
        /// <summary>
        /// Get a <see cref="MatchlistDto"/> by PUUID.
        /// </summary>
        /// <param name="valRegion"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<MatchlistDto> GetMatchlistByPuuidAsync(ValRegion valRegion, string puuid);
        /// <summary>
        /// Get recent matches by queue.
        /// </summary>
        /// <param name="valRegion"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        Task<RecentMatchesDto> GetRecentMatchesByQueueAsync(ValRegion valRegion, string queue);
    }

    internal class ValMatchApi : IValMatchApi
    {
        private static readonly string s_uri = "/val/match/v1";
        private static readonly string s_matchByIdUri = s_uri + "/matches/{0}";
        private static readonly string s_matchlistsByPuuidUri = s_uri + "/matchlists/by-puuid/{0}";
        private static readonly string s_recentMatchesByQueueUri = s_uri + "/recent-matches/by-queue/{0}";
        private readonly ComposableApi<MatchDto> _matchApi;
        private readonly ComposableApi<MatchlistDto> _matchlistApi;
        private readonly ComposableApi<RecentMatchesDto> _recentMatchesApi;

        public ValMatchApi(RiotHttpClient riotHttpClient)
        {
            _matchApi = new(riotHttpClient);
            _matchlistApi = new(riotHttpClient);
            _recentMatchesApi = new(riotHttpClient);
        }

        public async Task<MatchDto> GetByIdAsync(ValRegion valRegion, string id)
            => await _matchApi.GetValueAsync(ValRegionMapper.GetId(valRegion), string.Format(s_matchByIdUri, id));

        public async Task<MatchlistDto> GetMatchlistByPuuidAsync(ValRegion valRegion, string puuid)
            => await _matchlistApi.GetValueAsync(ValRegionMapper.GetId(valRegion), string.Format(s_matchlistsByPuuidUri, puuid));

        public async Task<RecentMatchesDto> GetRecentMatchesByQueueAsync(ValRegion valRegion, string queue)
            => await _recentMatchesApi.GetValueAsync(ValRegionMapper.GetId(valRegion), string.Format(s_recentMatchesByQueueUri, queue));
    }
}
