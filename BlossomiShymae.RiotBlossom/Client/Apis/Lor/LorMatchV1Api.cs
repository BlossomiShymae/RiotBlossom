using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lor.LorMatch;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Lor
{
    public interface ILorMatchV1Api
    {
        /// <summary>
        /// Get the list of match IDs by PUUID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<List<string>> GetMatchlistByPuuidAsync(RuneterraShard shard, string puuid);
        /// <summary>
        /// Get match by ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchDto> GetByIdAsync(RuneterraShard shard, string id);

    }

    internal class LorMatchV1Api : DataApi, ILorMatchV1Api
    {
        public LorMatchV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<MatchDto> GetByIdAsync(RuneterraShard shard, string id)
        {
            var data = await CallAsync<MatchDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(LorMatchV1Api),
                Method = UrlMethod.LorMatchV1ById,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.MatchId, id }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<string>> GetMatchlistByPuuidAsync(RuneterraShard shard, string puuid)
        {
            var data = await CallAsync<List<string>>(new()
            {
                Shard = shard,
                Endpoint = nameof(LorMatchV1Api),
                Method = UrlMethod.LorMatchV1MatchesByPuuid,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Puuid, puuid }
                }
            }).ConfigureAwait(false);

            return data;
        }
    }
}
