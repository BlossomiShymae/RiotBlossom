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

		public static SummonerApiCollection UseApi(HttpClient client)
		{
			return new SummonerApiCollection
			{
				GetSummonerBySummonerNameAsync = RiotGamesClient.GetAsync(client)("na1")(_summonerBySummonerNameUri)
			};
		}
	}

	public record SummonerApiCollection
	{
		public RiotGamesClient.GetAsyncFunc GetSummonerBySummonerNameAsync { get; init; } = default!;
	}
}
