using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class RiotApiTests
    {
        [TestMethod()]
        [ExpectedException(typeof(MissingApiKeyException))]
        public async Task Api_WithNoRiotKey_ShouldThrowException()
        {
            IRiotBlossomClient client = RiotBlossomCore.CreateClientBuilder()
                .AddHttpClient(StubConfig.HttpClient)
                .Build();

            SummonerDto dto = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }
    }
}
