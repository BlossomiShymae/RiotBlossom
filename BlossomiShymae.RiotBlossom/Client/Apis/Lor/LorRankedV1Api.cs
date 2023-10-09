using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lor.LorRanked;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Lor
{
    public interface ILorRankedV1Api
    {
        /// <summary>
        /// Get the player leaderboard in Master tier.
        /// </summary>
        /// <param name="shard"></param>
        /// <returns></returns>
        Task<LeaderboardDto> GetMasterLeaderboardAsync(RuneterraShard shard);
    }

    internal class LorRankedV1Api : DataApi, ILorRankedV1Api
    {
        public LorRankedV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<LeaderboardDto> GetMasterLeaderboardAsync(RuneterraShard shard)
        {
            var data = await CallAsync<LeaderboardDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(LorRankedV1Api),
                Method = UrlMethod.LorRankedV1Leaderboards,
            }).ConfigureAwait(false);
            
            return data;
        }
    }
}
