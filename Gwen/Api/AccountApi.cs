using Gwen.Dto.Account;
using Gwen.Http;

namespace Gwen.Api
{
    public static class AccountApi
    {
        private static readonly string _uri = "/riot/account/v1/accounts";
        private static readonly string _accountByPuuidUri = _uri + "/by-puuid/{0}";
        private static readonly string _accountByRiotIdUri = _uri + "/by-riot-id/{0}/{1}";
        private static readonly string _accountByAccessTokenUri = _uri + "/me";
        private static readonly string _activeShardUri = "/riot/account/v1/active-shards/by-game/{0}/by-puuid/{1}";

        public static Api.UseByRoutingValue<Container>
            Use(HttpClient client, string riotApiKey, XMiddlewares middlewares) =>
            (routingValue) =>
            {
                RiotGamesClient.GetAsyncFunc func = RiotGamesClient.GetAsync(client, riotApiKey, routingValue, middlewares);
                Api.GetDtoAsyncFunc<AccountDto> dtoFunc = Api.GetDtoAsync<AccountDto>(func);
                return new Container
                {
                    GetAccountByPuuidAsync = (string puuid) => dtoFunc(string.Format(_accountByPuuidUri, puuid), string.Empty),
                    GetAccountByRiotIdAsync = (string gameName, string tagLine) => dtoFunc(string.Format(_accountByRiotIdUri, gameName, tagLine), string.Empty)

                };
            };

        public record Container
        {
            /// <summary>
            /// Get a <see cref="AccountDto"/> by PUUID.
            /// </summary>
            public GetAccountByPuuidAsyncFunc GetAccountByPuuidAsync { get; init; } = default!;
            /// <summary>
            /// Get a <see cref="AccountDto"/> by Riot ID (associated game name and tag line).
            /// </summary>
            public GetAccountByRiotIdAsyncFunc GetAccountByRiotIdAsync { get; init; } = default!;
        }

        public delegate Task<AccountDto> GetAccountByPuuidAsyncFunc(string puuid);
        public delegate Task<AccountDto> GetAccountByRiotIdAsyncFunc(string gameName, string tagLine);
    }
}
