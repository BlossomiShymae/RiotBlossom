using Gwen.Core;
using Gwen.Dto.Riot.Account;
using Gwen.Http;
using Gwen.Type;

namespace Gwen.Api.Riot
{
    public interface IAccountApi
    {
        /// <summary>
        /// Get an account by PUUID.
        /// </summary>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<AccountDto> GetAccountByPuuidAsync(RegionalRoute regionalRoute, string puuid);

        /// <summary>
        /// Get an account by Riot ID (associated game name and tag line).
        /// </summary>
        /// <param name="gameName"></param>
        /// <param name="tagLine"></param>
        /// <returns></returns>
        Task<AccountDto> GetAccountByRiotIdAsync(RegionalRoute regionalRoute, string gameName, string tagLine);
    }

    internal class AccountApi : IAccountApi
    {
        private static readonly string _uri = "/riot/account/v1/accounts";
        private static readonly string _accountByPuuidUri = _uri + "/by-puuid/{0}";
        private static readonly string _accountByRiotIdUri = _uri + "/by-riot-id/{0}/{1}";
        private static readonly string _accountByAccessTokenUri = _uri + "/me";
        private static readonly string _activeShardUri = "/riot/account/v1/active-shards/by-game/{0}/by-puuid/{1}";
        private readonly ComposableApi<AccountDto> _accountDtoApi;

        public AccountApi(RiotHttpClient riotGamesClient)
        {
            _accountDtoApi = new(riotGamesClient);
        }

        public async Task<AccountDto> GetAccountByPuuidAsync(RegionalRoute regionalRoute, string puuid)
            => await _accountDtoApi.GetValueAsync(RegionRouteMapper.GetRegion(regionalRoute), string.Format(_accountByPuuidUri, puuid));

        public async Task<AccountDto> GetAccountByRiotIdAsync(RegionalRoute regionalRoute, string gameName, string tagLine)
            => await _accountDtoApi.GetValueAsync(RegionRouteMapper.GetRegion(regionalRoute), string.Format(_accountByRiotIdUri, gameName, tagLine));
    }
}
