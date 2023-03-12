using Gwen.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gwen.Api.Tests
{
    [TestClass()]
    public class SummonerApiTests
    {
        private static readonly string _riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY") ?? string.Empty;

        [TestMethod()]
        public async Task UseApiTest()
        {
            var Gwen = GwenCore.UsePlatformRouteDictionary(new GwenCoreSettings
            {
                HttpClient = new HttpClient(),
                RiotApiKey = _riotApiKey,
                MiddlewarePipeline = new Http.RiotGamesClient.MiddlewarePipeline(),
                PlatformRoute = Type.PlatformRoute.NorthAmerica
            });

            var response = await Gwen[Type.PlatformRoute.NorthAmerica].Summoner.GetSummonerByNameAsync("uwuie time");
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}