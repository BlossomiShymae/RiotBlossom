using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.LolChallenges;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Exception;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests.Api
{
    [TestClass()]
    public class RiotApiTests
    {
        public static SummonerDto Summoner = default!;

        [ClassInitialize()]
        public static async Task Initialize(TestContext context)
        {
            IRiotBlossomClient client = StubConfig.Client;

            Summoner = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        [ExpectedException(typeof(MissingApiKeyException))]
        public async Task Api_WithNoRiotKey_ShouldThrowException()
        {
            IRiotBlossomClient client = RiotBlossomCore.CreateClientBuilder()
                .AddHttpClient(StubConfig.HttpClient)
                .Build();

            SummonerDto dto = await client.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, StubConfig.SummonerName);
        }

        [TestMethod()]
        public async Task Api_WithObjectType_ShouldReturnTypedObject()
        {
            IRiotBlossomClient client = StubConfig.Client;

            SummonerDto dto = await client.Riot.GetAsync<SummonerDto>("na1", "/lol/summoner/v4/summoners/by-name/uwuie time");

            Assert.IsInstanceOfType(dto, typeof(SummonerDto));
        }

        [TestMethod()]
        public async Task Api_WithArrayType_ShouldReturnArrayObject()
        {
            IRiotBlossomClient client = StubConfig.Client;

            List<ChallengeConfigInfoDto> challengeConfigInfoList = await client.Riot.GetAsync<List<ChallengeConfigInfoDto>>("na1", "/lol/challenges/v1/challenges/config");

            Assert.IsTrue(challengeConfigInfoList.Count > 0);
        }

        [TestMethod()]
        public async Task Api_WithScalarType_ShouldReturnScalarValue()
        {
            IRiotBlossomClient client = StubConfig.Client;

            int totalScore = await client.Riot.GetAsync<int>("na1", $"/lol/champion-mastery/v4/scores/by-summoner/{Summoner.Id}");

            Assert.IsTrue(totalScore > 0);
        }
    }
}
