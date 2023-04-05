using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class RiotApiTests
    {
        [TestMethod()]
        [ExpectedException(typeof(MissingApiKeyException))]
        public async Task Api_WithNoRiotKey_ShouldThrowException()
        {
            IRiotBlossomClient client = RiotBlossomCore.CreateClient(new()
            {
                HttpClient = new HttpClient()
            });

            SummonerDto dto = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        public async Task Api_RunIterativelyForLimiter_ShouldRunWithoutException()
        {
            IRiotBlossomClient client = StubConfig.Client;

            SummonerDto summonerDto = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
            ImmutableList<string> matchIds = await client.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerRegion, summonerDto.Puuid, new() { Count = 100 });

            foreach (string matchId in matchIds)
            {
                await client.Riot.Match.GetByIdAsync(StubConfig.SummonerRegion, matchId);
            }
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public async Task Api_RunWhenAllForLimiter_ShouldRunWithoutException()
        {
            IRiotBlossomClient client = StubConfig.Client;

            SummonerDto summonerDto = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
            ImmutableList<string> matchIds = await client.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerRegion, summonerDto.Puuid, new() { Count = 100 });

            await Task.WhenAll(matchIds.Select(x => client.Riot.Match.GetByIdAsync(StubConfig.SummonerRegion, x)));
        }
    }
}
