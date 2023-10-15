using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Riot.Account;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Riot
{
    public interface IAccountV1Api
    {
        /// <summary>
        /// Get an account by PUUID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<AccountDto> GetAccountByPuuidAsync(RegionShard shard, string puuid);

        /// <summary>
        /// Get an account by Riot ID (associated game name and tag line).
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="gameName"></param>
        /// <param name="tagLine"></param>
        /// <returns></returns>
        Task<AccountDto> GetAccountByRiotIdAsync(RegionShard shard, string gameName, string tagLine);
    }

    internal class AccountV1Api : DataApi, IAccountV1Api
    {
        public AccountV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<AccountDto> GetAccountByPuuidAsync(RegionShard shard, string puuid)
        {
            var data = await CallAsync<AccountDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(AccountV1Api),
                Method = UrlMethod.RiotAccountV1ByPuuid,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Puuid, puuid }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<AccountDto> GetAccountByRiotIdAsync(RegionShard shard, string gameName, string tagLine)
        {
            var data = await CallAsync<AccountDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(AccountV1Api),
                Method = UrlMethod.RiotAccountV1ByGameName,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.GameName, gameName },
                    { UrlMethod.TagLine, tagLine }
                }
            }).ConfigureAwait(false);

            return data;
        }
    }
}
