using Gwen.Dto.Summoner;
using Gwen.Http;

namespace Gwen.Api
{
    public static class SummonerApi
    {
        private static readonly string _uri = "/lol/summoner/v4/summoners";
        private static readonly string _summonerByRSOPuuidUri = "/fufillment/v1/summoners/by-puuid/{0}";
        private static readonly string _summonerByAccountIdUri = _uri + "/by-account/{0}";
        private static readonly string _summonerBySummonerNameUri = _uri + "/by-name/{0}";
        private static readonly string _summonerByPuuidUri = _uri + "/by-puuid/{0}";
        private static readonly string _summonerByAccessTokenUri = _uri + "/me";
        private static readonly string _summonerBySummonerIdUri = _uri + "/{0}";

        public static ComposableApi.UseByRoutingValue<Container>
            Use(HttpClient client, string riotApiKey, XMiddlewares middlewares) =>
            (routingValue) =>
            {
                RiotGamesClient.GetAsyncFunc func = RiotGamesClient.GetAsync(client, riotApiKey, routingValue, middlewares);
                ComposableApi.GetDtoAsyncFunc<SummonerDto> dtoFunc = ComposableApi.GetDtoAsync<SummonerDto>(func);
                return new Container
                {
                    GetSummonerByAccountIdAsync = (string accountId) => dtoFunc(string.Format(_summonerByAccountIdUri, accountId), string.Empty),
                    GetSummonerByNameAsync = (string summonerName) => dtoFunc(string.Format(_summonerBySummonerNameUri, summonerName), string.Empty),
                    GetSummonerByPuuidAsync = (string puuid) => dtoFunc(string.Format(_summonerByPuuidUri, puuid), string.Empty),
                    GetSummonerByIdAsync = (string id) => dtoFunc(string.Format(_summonerBySummonerIdUri, id), string.Empty)
                };
            };

        public record Container
        {
            /// <summary>
            /// Get a <see cref="SummonerDto"/> by encrypted account ID.
            /// </summary>
            public GetSummonerByAccountIdAsyncFunc GetSummonerByAccountIdAsync { get; init; } = default!;
            /// <summary>
            /// Get a <see cref="SummonerDto"/> by summoner name.
            /// </summary>
            public GetSummonerByNameAsyncFunc GetSummonerByNameAsync { get; init; } = default!;
            /// <summary>
            /// Get a <see cref="SummonerDto"/> by encrypted PUUID.
            /// </summary>
            public GetSummonerByPuuidAsyncFunc GetSummonerByPuuidAsync { get; init; } = default!;
            /// <summary>
            /// Get a <see cref="SummonerDto"/> by encrypted summoner ID.
            /// </summary>
            public GetSummonerByIdAsyncFunc GetSummonerByIdAsync { get; init; } = default!;

        }

        public delegate Task<SummonerDto> GetSummonerByAccountIdAsyncFunc(string accountId);
        public delegate Task<SummonerDto> GetSummonerByNameAsyncFunc(string summonerName);
        public delegate Task<SummonerDto> GetSummonerByPuuidAsyncFunc(string puuid);
        public delegate Task<SummonerDto> GetSummonerByIdAsyncFunc(string id);
    }
}
