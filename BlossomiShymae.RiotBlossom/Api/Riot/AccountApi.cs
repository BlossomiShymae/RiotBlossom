using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Account;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface IAccountApi
    {
        /// <summary>
        /// Get an account by PUUID.
        /// </summary>
        /// <param name="regionalRoute"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<AccountDto> GetAccountByPuuidAsync(RegionalRoute regionalRoute, string puuid);

        /// <summary>
        /// Get an account by PUUID.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<AccountDto> GetAccountByPuuidAsync(PlatformRoute platformRoute, string puuid);

        /// <summary>
        /// Get an account by Riot ID (associated game name and tag line).
        /// </summary>
        /// <param name="regionalRoute"></param>
        /// <param name="gameName"></param>
        /// <param name="tagLine"></param>
        /// <returns></returns>
        Task<AccountDto> GetAccountByRiotIdAsync(RegionalRoute regionalRoute, string gameName, string tagLine);

        /// <summary>
        /// Get an account by Riot ID (associated game name and tag line).
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="gameName"></param>
        /// <param name="tagLine"></param>
        /// <returns></returns>
        Task<AccountDto> GetAccountByRiotIdAsync(PlatformRoute platformRoute, string gameName, string tagLine);
    }

    internal class AccountApi : IAccountApi
    {
        private static readonly string s_uri = "/riot/account/v1/accounts";
        private static readonly string s_accountByPuuidUri = s_uri + "/by-puuid/{0}";
        private static readonly string s_accountByRiotIdUri = s_uri + "/by-riot-id/{0}/{1}";
        private readonly ComposableApi<AccountDto> _accountDtoApi;

        public AccountApi(RiotHttpClient riotGamesClient)
        {
            _accountDtoApi = new(riotGamesClient);
        }

        public async Task<AccountDto> GetAccountByPuuidAsync(RegionalRoute regionalRoute, string puuid)
            => await _accountDtoApi.GetValueAsync(RegionRouteMapper.GetRegion(regionalRoute), string.Format(s_accountByPuuidUri, puuid));

        public async Task<AccountDto> GetAccountByPuuidAsync(PlatformRoute platformRoute, string puuid)
            => await GetAccountByPuuidAsync(PlatformToRegionConverter.ToRegion(platformRoute), puuid);

        public async Task<AccountDto> GetAccountByRiotIdAsync(RegionalRoute regionalRoute, string gameName, string tagLine)
            => await _accountDtoApi.GetValueAsync(RegionRouteMapper.GetRegion(regionalRoute), string.Format(s_accountByRiotIdUri, gameName, tagLine));

        public async Task<AccountDto> GetAccountByRiotIdAsync(PlatformRoute platformRoute, string gameName, string tagLine)
            => await GetAccountByRiotIdAsync(PlatformToRegionConverter.ToRegion(platformRoute), gameName, tagLine);
    }
}
