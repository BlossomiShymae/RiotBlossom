using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.ValRanked;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface IValRankedApi
    {
        /// <summary>
        /// Get leaderboard for the competitive queue by act ID.
        /// </summary>
        /// <param name="valRegion"></param>
        /// <param name="actId"></param>
        /// <returns></returns>
        Task<LeaderboardDto> GetLeaderboardByActIdAsync(ValRegion valRegion, string actId);
        /// <summary>
        /// Get leaderboard for the competitive queue by act ID with options.
        /// </summary>
        /// <param name="valRegion"></param>
        /// <param name="actId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<LeaderboardDto> GetLeaderboardByActIdAsync(ValRegion valRegion, string actId, GetLeaderboardByActIdAsyncOptions options);
    }

    internal class ValRankedApi : IValRankedApi
    {
        private static readonly string s_uri = "/val/ranked/v1/leaderboards/by-act/{0}";
        private readonly ComposableApi<LeaderboardDto> _leaderboardApi;

        public ValRankedApi(RiotHttpClient riotHttpClient)
        {
            _leaderboardApi = new(riotHttpClient);
        }

        public async Task<LeaderboardDto> GetLeaderboardByActIdAsync(ValRegion valRegion, string actId)
            => await _leaderboardApi.GetValueAsync(ValRegionMapper.GetId(valRegion), string.Format(s_uri, actId));

        public async Task<LeaderboardDto> GetLeaderboardByActIdAsync(ValRegion valRegion, string actId, GetLeaderboardByActIdAsyncOptions options)
            => await _leaderboardApi.GetValueAsync(ValRegionMapper.GetId(valRegion), string.Format(s_uri, actId) + PropertiesToQueryConverter.ToQuery(options));
    }

    public record GetLeaderboardByActIdAsyncOptions
    {
        public int? Size { get; init; }
        public int? StartIndex { get; init; }
    }
}
