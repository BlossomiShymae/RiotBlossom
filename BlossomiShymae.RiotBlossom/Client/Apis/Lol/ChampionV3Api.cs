using BlossomiShymae.RiotBlossom.Client.Apis;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Champion;

namespace BlossomiShymae.RiotBlossom.Apis.Lol
{
    public interface IChampionV3Api
    {
        /// <summary>
        /// Get the current champion rotation pools.
        /// </summary>
        /// <returns></returns>
        Task<ChampionInfo> GetChampionRotations(LeagueShard shard);
    }

    internal class ChampionV3Api : DataApi, IChampionV3Api
    {
        public ChampionV3Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ChampionInfo> GetChampionRotations(LeagueShard shard)
        {
            var data = await CallAsync<ChampionInfo>(new()
            {
                Shard = shard,
                Endpoint = nameof(ChampionV3Api),
                Method = UrlMethod.LolChampionV3ChampionRotations,
            }).ConfigureAwait(false);

            return data;
        }
    }
}
