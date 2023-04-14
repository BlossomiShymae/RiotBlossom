using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossomTests
{
    [TestClass()]
    public class LimiterTests
    {
        [TestMethod()]
        [ExpectedException(typeof(WarningLimiterException))]
        public async Task Api_RunIterativelyForLimiter_ShouldThrowWarningException()
        {
            IRiotBlossomClient client = StubConfig.ThrowingClient;

            SummonerDto summonerDto = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
            ImmutableList<string> matchIds = await client.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerPlatform, summonerDto.Puuid);

            for (int i = 0; i < 121; i++)
            {
                await client.Riot.Match.GetByIdAsync(StubConfig.SummonerPlatform, matchIds.First());
            }
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
        [ExpectedException(typeof(WarningLimiterException))]
        public async Task Api_WhenAllForLimiter_ShouldThrowWarningException()
        {
            IRiotBlossomClient client = StubConfig.ThrowingClient;

            SummonerDto summonerDto = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
            ImmutableList<string> matchIds = await client.Riot.Match.ListIdsByPuuidAsync(StubConfig.SummonerPlatform, summonerDto.Puuid);

            await Task.WhenAll(Enumerable.Range(0, 121).Select(x => client.Riot.Match.GetByIdAsync(StubConfig.SummonerPlatform, matchIds.First())));
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
