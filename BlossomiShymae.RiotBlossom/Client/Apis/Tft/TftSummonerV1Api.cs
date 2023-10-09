using BlossomiShymae.RiotBlossom.Client.Apis;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Summoner;

namespace BlossomiShymae.RiotBlossom.Api.Client.Apis.Tft
{
    public interface ITftSummonerV1Api
    {
        /// <summary>
        /// Get a summoner by account ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByAccountIdAsync(LeagueShard shard, string accountId);
        /// <summary>
        /// Get a summoner by encrypted ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByIdAsync(LeagueShard shard, string summonerId);
        /// <summary>
        /// Get a summoner by summoner name.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="summonerName"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByNameAsync(LeagueShard shard, string summonerName);
        /// <summary>
        /// Get a summoner by encrypted PUUID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByPuuidAsync(LeagueShard shard, string puuid);
    }

    internal class TftSummonerV1Api : DataApi, ITftSummonerV1Api
    {
        public TftSummonerV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<SummonerDto> GetByAccountIdAsync(LeagueShard shard, string accountId)
        {
            var data = await CallAsync<SummonerDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftSummonerV1Api),
                Method = UrlMethod.TftSummonerV1ByEncryptedAccountId,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedAccountId, accountId }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<SummonerDto> GetByIdAsync(LeagueShard shard, string summonerId)
        {
            var data = await CallAsync<SummonerDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftSummonerV1Api),
                Method = UrlMethod.TftSummonerV1ByEncryptedSummonerId,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedSummonerId, summonerId }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<SummonerDto> GetByNameAsync(LeagueShard shard, string summonerName)
        {
            var data = await CallAsync<SummonerDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftSummonerV1Api),
                Method = UrlMethod.TftSummonerV1ByName,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.SummonerName, summonerName }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<SummonerDto> GetByPuuidAsync(LeagueShard shard, string puuid)
        {
            var data = await CallAsync<SummonerDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftSummonerV1Api),
                Method = UrlMethod.TftSummonerV1ByEncryptedPuuid,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedPuuid, puuid }
                }
            }).ConfigureAwait(false);

            return data;
        }
    }
}
