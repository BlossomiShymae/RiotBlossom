using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Val
{
    public interface IValMatchV1Api
    {
        /// <summary>
        /// Get a VALORANT match by ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchDto> GetByIdAsync(ValorantShard shard, string id);
        /// <summary>
        /// Get a <see cref="MatchlistDto"/> by PUUID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<MatchlistDto> GetMatchlistByPuuidAsync(ValorantShard shard, string puuid);
        /// <summary>
        /// Get recent matches by queue.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        Task<RecentMatchesDto> GetRecentMatchesByQueueAsync(ValorantShard shard, string queue);
    }

    internal class ValMatchV1Api : DataApi, IValMatchV1Api
    {
        public ValMatchV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<MatchDto> GetByIdAsync(ValorantShard shard, string id)
        {
            var data = await CallAsync<MatchDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(ValMatchV1Api),
                Method = UrlMethod.ValMatchV1ById,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.MatchId, id }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<MatchlistDto> GetMatchlistByPuuidAsync(ValorantShard shard, string puuid)
        {
            var data = await CallAsync<MatchlistDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(ValMatchV1Api),
                Method = UrlMethod.ValMatchV1MatchesByPuuid,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Puuid, puuid }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<RecentMatchesDto> GetRecentMatchesByQueueAsync(ValorantShard shard, string queue)
        {
            var data = await CallAsync<RecentMatchesDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(ValMatchV1Api),
                Method = UrlMethod.ValMatchV1RecentMatches,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Queue, queue }
                }
            }).ConfigureAwait(false);

            return data;
        }
    }
}
