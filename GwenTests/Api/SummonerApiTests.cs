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
            var gwen = GwenCore.UseWidespreadClient(new GwenCore.Settings
            {
                HttpClient = new HttpClient(),
                RiotApiKey = _riotApiKey,
            });

            var summonerDto = await gwen.Riot[Type.PlatformRoute.NorthAmerica].Summoner.GetSummonerByNameAsync("uwuie time");

            Assert.IsTrue(summonerDto is SummonerDto);
        }
    }
}