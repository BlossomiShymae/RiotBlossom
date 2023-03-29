using BlossomiShymae.Gwen.Core.Wrapper;
using BlossomiShymae.Gwen.Dto.Riot.Summoner;
using BlossomiShymae.Gwen.PException;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.GwenTests.Api.Riot
{
    [TestClass()]
    public class RiotApiTests
    {
        [TestMethod()]
        [ExpectedException(typeof(InvalidRiotKeyException))]
        public async Task Api_WithNoRiotKey_ShouldThrowException()
        {
            IGwenClient gwen = GwenCore.CreateClient(new()
            {
                HttpClient = new HttpClient()
            });

            SummonerDto dto = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }
    }
}
