using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.LorRanked;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface ILorRankedApi
    {
        /// <summary>
        /// Get the player leaderboard in Master tier.
        /// </summary>
        /// <param name="lorRegion"></param>
        /// <returns></returns>
        Task<LeaderboardDto> GetMasterLeaderboardAsync(LorRegion lorRegion);
    }

    internal class LorRankedApi : ILorRankedApi
    {
        private static readonly string s_masterLeaderboardUri = "/lor/ranked/v1/leaderboards";
        private readonly ComposableApi<LeaderboardDto> _leaderboardDtoApi;

        public LorRankedApi(RiotHttpClient riotHttpClient)
        {
            _leaderboardDtoApi = new(riotHttpClient);
        }

        public Task<LeaderboardDto> GetMasterLeaderboardAsync(LorRegion lorRegion)
            => _leaderboardDtoApi.GetValueAsync(LorRegionMapper.GetId(lorRegion), s_masterLeaderboardUri);
    }
}
