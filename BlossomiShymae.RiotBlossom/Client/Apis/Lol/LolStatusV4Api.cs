using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolStatus;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Lol
{
    public interface ILolStatusV4Api
    {
        /// <summary>
        /// Get League of Legends status for the current platform.
        /// </summary>
        /// <returns></returns>
        Task<PlatformDataDto> GetPlatformStatusAsync(LeagueShard shard);
    }

    internal class LolStatusV4Api : DataApi, ILolStatusV4Api
    {
        public LolStatusV4Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<PlatformDataDto> GetPlatformStatusAsync(LeagueShard shard)
        {
            var data = await CallAsync<PlatformDataDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(LolStatusV4Api),
                Method = UrlMethod.LolStatusV4PlatformData,
            }).ConfigureAwait(false);

            return data;
        }
    }
}
