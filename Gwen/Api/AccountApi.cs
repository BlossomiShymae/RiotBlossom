using Gwen.Dto.Account;
using Gwen.Http;

namespace Gwen.Api
{
    internal class AccountApi
    {
        private static readonly string _uri = "/riot/account/v1/accounts";
        private static readonly string _accountByPuuidUri = _uri + "/by-puuid/{0}";
        private static readonly string _accountByRiotIdUri = _uri + "/by-riot-id/{0}/{1}";
        private static readonly string _accountByAccessTokenUri = _uri + "/me";
        private static readonly string _activeShardUri = "/riot/account/v1/active-shards/by-game/{0}/by-puuid/{1}";
        private readonly ComposableApi<AccountDto> _accountDtoApi;

        public AccountApi(RiotGamesClient riotGamesClient)
        {
            _accountDtoApi = new(riotGamesClient);
        }

        /// <summary>
        /// Get an account by PUUID.
        /// </summary>
        /// <param name="puuid"></param>
        /// <returns></returns>
        public async Task<AccountDto> GetAccountByPuuidAsync(string puuid) => await _accountDtoApi.GetDtoAsync(string.Format(_accountByPuuidUri, puuid));

        /// <summary>
        /// Get an account by Riot ID (associated game name and tag line).
        /// </summary>
        /// <param name="gameName"></param>
        /// <param name="tagLine"></param>
        /// <returns></returns>
        public async Task<AccountDto> GetAccountByRiotIdAsync(string gameName, string tagLine) => await _accountDtoApi.GetDtoAsync(string.Format(_accountByRiotIdUri, gameName, tagLine));
    }
}
