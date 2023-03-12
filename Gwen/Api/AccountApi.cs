namespace Gwen.Api
{
    public static class AccountApi
    {
        private static readonly string _uri = "/riot/account/v1/accounts";
        private static readonly string _accountByPuuidUri = "/by-puuid/{0}";
        private static readonly string _accountByRiotIdUri = "/by-riot-id/{0}/{1}";
        private static readonly string _accountByAccessTokenUri = "/me";
        private static readonly string _activeShardUri = "/riot/account/v1/active-shards/by-game/{0}/by-puuid/{1}";
    }
}
