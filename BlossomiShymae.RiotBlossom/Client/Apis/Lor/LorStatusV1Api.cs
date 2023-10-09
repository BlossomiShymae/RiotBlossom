using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolStatus;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Lor
{
    public interface ILorStatusV1Api
    {
        /// <summary>
        /// Get Legends of Runeterra status for the current region.
        /// </summary>
        /// <param name="shard"></param>
        /// <returns></returns>
        Task<PlatformDataDto> GetPlatformStatusAsync(RuneterraShard shard);
    }

    internal class LorStatusV1Api : DataApi, ILorStatusV1Api
    {
        public LorStatusV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PlatformDataDto> GetPlatformStatusAsync(RuneterraShard shard)
        {
            var data = await CallAsync<PlatformDataDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(LorStatusV1Api),
                Method = UrlMethod.LorStatusV1PlatformData
            }).ConfigureAwait(false);

            return data;
        }
    }
}
