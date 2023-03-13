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

        public static Api.UseByRoutingValue<Container>
            Use(HttpClient client, string riotApiKey, RiotGamesClient.MiddlewarePipeline middlewarePipeline) =>
            (routingValue) =>
            {
                RiotGamesClient.GetAsyncFunc func = RiotGamesClient.GetAsync(client, riotApiKey, routingValue, middlewarePipeline);
                Api.GetDtoAsyncFunc<SummonerDto> dtoFunc = Api.GetDtoAsync<SummonerDto>(func);
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
            public GetSummonerByAccountIdAsyncFunc GetSummonerByAccountIdAsync { get; init; } = default!;
            public GetSummonerByNameAsyncFunc GetSummonerByNameAsync { get; init; } = default!;
            public GetSummonerByPuuidAsyncFunc GetSummonerByPuuidAsync { get; init; } = default!;
            public GetSummonerByIdAsyncFunc GetSummonerByIdAsync { get; init; } = default!;

        }

        public delegate Task<SummonerDto> GetSummonerByAccountIdAsyncFunc(string accountId);
        public delegate Task<SummonerDto> GetSummonerByNameAsyncFunc(string summonerName);
        public delegate Task<SummonerDto> GetSummonerByPuuidAsyncFunc(string puuid);
        public delegate Task<SummonerDto> GetSummonerByIdAsyncFunc(string id);
    }
}
