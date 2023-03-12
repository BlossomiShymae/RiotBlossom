using Soraka.Http;

namespace Soraka.Api
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

		public static Api.UseByRoutingValue<SummonerApiCollection>
			Use(HttpClient client, string riotApiKey, RiotGamesClient.MiddlewarePipeline middlewarePipeline) =>
			(routingValue) =>
			{
				RiotGamesClient.GetAsyncFunc func = RiotGamesClient.GetAsync(client, riotApiKey, routingValue, middlewarePipeline);
				return new SummonerApiCollection
				{
					GetSummonerBySummonerNameAsync = (string summonerName) => func(string.Format(_summonerBySummonerNameUri, summonerName), "")
				};
			};

		public delegate Task<HttpResponseMessage> GetSummonersBySummonerNameAsyncFunc(string summonerName);
	}

	public record SummonerApiCollection
	{
		public SummonerApi.GetSummonersBySummonerNameAsyncFunc GetSummonerBySummonerNameAsync { get; init; } = default!;
	}
}
