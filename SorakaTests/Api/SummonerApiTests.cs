using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soraka.Core;

namespace Soraka.Api.Tests
{
	[TestClass()]
	public class SummonerApiTests
	{
		private static readonly string _riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY") ?? string.Empty;

		[TestMethod()]
		public async Task UseApiTest()
		{
			var soraka = SorakaCore.UsePlatformRouteDictionary(new SorakaCoreSettings
			{
				HttpClient = new HttpClient(),
				RiotApiKey = _riotApiKey,
				MiddlewarePipeline = new Http.RiotGamesClient.MiddlewarePipeline(),
				PlatformRoute = Type.PlatformRoute.NorthAmerica
			});

			var response = await soraka[Type.PlatformRoute.NorthAmerica].Summoner.GetSummonerBySummonerNameAsync("uwuie time");
			Console.WriteLine(await response.Content.ReadAsStringAsync());

			Assert.IsTrue(response.IsSuccessStatusCode);
		}
	}
}