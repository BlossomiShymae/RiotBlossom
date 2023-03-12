using Gwen.Core;
using Gwen.Dto.Summoner;
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

            var summonerDto = await Gwen[Type.PlatformRoute.NorthAmerica].Summoner.GetSummonerByNameAsync("uwuie time");
            Console.WriteLine(summonerDto.Puuid);

            Assert.IsTrue(summonerDto is SummonerDto);
        }
    }
}