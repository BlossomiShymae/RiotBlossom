using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValRanked;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Val
{
    public interface IValRankedV1Api
    {
        /// <summary>
        /// Get leaderboard for the competitive queue by act ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="actId"></param>
        /// <param name="startIndex"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        Task<LeaderboardDto> GetLeaderboardByActIdAsync(ValorantShard shard, string actId, int startIndex = 0, int size = 200);
    }

    internal class ValRankedV1Api : DataApi, IValRankedV1Api
    {
        public ValRankedV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<LeaderboardDto> GetLeaderboardByActIdAsync(ValorantShard shard, string actId, int startIndex = 0, int size = 200)
        {
            var data = await CallAsync<LeaderboardDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(ValRankedV1Api),
                Method = UrlMethod.ValRankedV1Leaderboards,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.ActId, actId },
                    { UrlMethod.StartIndexQuery, startIndex.ToString() },
                    { UrlMethod.SizeQuery, size.ToString() }
                }
            }).ConfigureAwait(false);

            return data;
        }
    }
}
