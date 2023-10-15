using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolStatus;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Val
{
    public interface IValStatusV1Api
    {
        /// <summary>
        /// Get VALORANT status for the given platform.
        /// </summary>
        /// <param name="shard"></param>
        /// <returns></returns>
        Task<PlatformDataDto> GetPlatformStatusAsync(ValorantShard shard);
    }

    internal class ValStatusV1Api : DataApi, IValStatusV1Api
    {
        public ValStatusV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PlatformDataDto> GetPlatformStatusAsync(ValorantShard shard)
        {
            var data = await CallAsync<PlatformDataDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(ValStatusV1Api),
                Method = UrlMethod.ValStatusV1PlatformData,
            }).ConfigureAwait(false);

            return data;
        }
    }
}
