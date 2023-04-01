using BlossomiShymae.Gwen.Core.Wrapper;
using BlossomiShymae.Gwen.Dto.Riot.Summoner;
using BlossomiShymae.Gwen.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.GwenTests.Api.Riot
{
    [TestClass()]
    public class RiotApiTests
    {
        [TestMethod()]
        [ExpectedException(typeof(MissingApiKeyException))]
        public async Task Api_WithNoRiotKey_ShouldThrowException()
        {
            IGwenClient gwen = GwenCore.CreateClient(new()
            {
                HttpClient = new HttpClient()
            });

            SummonerDto dto = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        public async Task Api_RunIterativelyForLimiter_ShouldRunWithoutException()
        {
            IGwenClient gwen = StubConfig.Gwen;

            SummonerDto summonerDto = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
            ImmutableList<string> matchIds = await gwen.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerRegion, summonerDto.Puuid, new() { Count = 100 });

            foreach (string matchId in matchIds)
            {
                await gwen.Riot.Match.GetByIdAsync(StubConfig.SummonerRegion, matchId);
            }
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public async Task Api_RunWhenAllForLimiter_ShouldRunWithoutException()
        {
            IGwenClient gwen = StubConfig.Gwen;

            SummonerDto summonerDto = await gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
            ImmutableList<string> matchIds = await gwen.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerRegion, summonerDto.Puuid, new() { Count = 100 });

            await Task.WhenAll(matchIds.Select(x => gwen.Riot.Match.GetByIdAsync(StubConfig.SummonerRegion, x)));
        }
    }
}
