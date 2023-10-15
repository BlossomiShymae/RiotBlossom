﻿using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Summoner;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Lol
{
    public interface ISummonerV4Api
    {
        /// <summary>
        /// Get a summoner by encrypted account ID.
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

    internal class SummonerV4Api(ApiConfiguration configuration) : DataApi(configuration), ISummonerV4Api
    {
        public async Task<SummonerDto> GetByAccountIdAsync(LeagueShard shard, string accountId)
        {
            var data = await CallAsync<SummonerDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(SummonerV4Api),
                Method = UrlMethod.LolSummonerV4ByEncryptedAccountId,
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
                Endpoint = nameof(SummonerV4Api),
                Method = UrlMethod.LolSummonerV4ByEncryptedSummonerId,
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
                Endpoint = nameof(SummonerV4Api),
                Method = UrlMethod.LolSummonerV4ByName,
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
                Endpoint = nameof(SummonerV4Api),
                Method = UrlMethod.LolSummonerV4ByEncryptedPuuid,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedPuuid, puuid }
                }
            }).ConfigureAwait(false);
            
            return data;
        }
    }
}
