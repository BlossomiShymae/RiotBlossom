using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolStatus;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Tft
{
    public interface ITftStatusV1Api
    {
        /// <summary>
        /// Get Teamfight Tactics status for the given platform.
        /// </summary>
        /// <param name="shard"></param>
        /// <returns></returns>
        Task<PlatformDataDto> GetPlatformStatusAsync(LeagueShard shard);
    }

    internal class TftStatusV1Api : DataApi, ITftStatusV1Api
    {
        public TftStatusV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PlatformDataDto> GetPlatformStatusAsync(LeagueShard shard)
        {
            var data = await CallAsync<PlatformDataDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftStatusV1Api),
                Method = UrlMethod.TftStatusV1PlatformData
            }).ConfigureAwait(false);

            return data;
        }
    }
}
