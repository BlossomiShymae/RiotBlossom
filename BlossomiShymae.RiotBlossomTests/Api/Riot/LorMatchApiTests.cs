using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Account;
using BlossomiShymae.RiotBlossom.Dto.Riot.LorMatch;
using BlossomiShymae.RiotBlossom.Dto.Riot.LorRanked;
using BlossomiShymae.RiotBlossom.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossomTests.Api.Riot
{
    [TestClass()]
    public class LorMatchApiTests
    {
        public static AccountDto Account = default!;
        public static string MatchId = "fb053415-b5a9-4c45-85a6-8553c8245c34";

        [ClassInitialize()]
        public static async Task Initialize(TestContext testContext)
        {
            IRiotBlossomClient client = StubConfig.Client;

            LeaderboardDto leaderboard = await client.Riot.LorRanked.GetMasterLeaderboardAsync(LorRegion.Americas);
            Account = await client.Riot.Account.GetAccountByRiotIdAsync(Region.Americas, leaderboard.Players.First().Name, "na1");
        }

        [TestMethod()]
        public async Task Api_WithPuuid_ShouldReturnMatchIdCollection()
        {
            IRiotBlossomClient client = StubConfig.Client;

            ImmutableList<string> ids = await client.Riot.LorMatch.ListIdsByPuuidAsync(LorRegion.Americas, Account.Puuid);

            Assert.IsInstanceOfType(ids, typeof(ImmutableList<string>));
        }

        [TestMethod()]
        public async Task Api_WithId_ShouldReturnMatchDto()
        {
            IRiotBlossomClient client = StubConfig.Client;

            MatchDto dto = await client.Riot.LorMatch.GetByIdAsync(LorRegion.Americas, MatchId);

            Assert.IsInstanceOfType(dto, typeof(MatchDto));
        }
    }
}
