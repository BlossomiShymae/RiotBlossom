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
			var soraka = SorakaCore.Use(new SorakaCoreSettings
			{
				HttpClient = new HttpClient(),
				RiotApiKey = _riotApiKey,
				MiddlewarePipeline = new Http.RiotGamesClient.MiddlewarePipeline(),
				PlatformRoute = Type.PlatformRoute.NorthAmerica
			});

			var response = await soraka.Summoner.GetSummonerBySummonerNameAsync("uwuie time");
			Console.WriteLine(await response.Content.ReadAsStringAsync());

			Assert.IsTrue(response.IsSuccessStatusCode);
		}
	}
}