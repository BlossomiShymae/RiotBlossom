using BlossomiShymae.Gwen.Core.Wrapper;
using BlossomiShymae.Gwen.Dto.CDragon.Champion;
using BlossomiShymae.Gwen.SewingKit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.GwenTests.SewingKit
{
    [TestClass()]
    public class NeedleTests
    {
        [TestMethod()]
        public async Task Needle_WithSummoner_ShouldWork()
        {
            IGwenClient gwen = StubConfig.Gwen;

            var data = await Needle<string>.From(StubConfig.SummonerName)
                .Bind(x => gwen.Riot.Summoner.GetByNameAsync(StubConfig.SummonerPlatform, x))
                .Bind(x => gwen.Riot.ChampionMastery.ListBySummonerIdAsync(StubConfig.SummonerPlatform, x.Id))
                .Bind(x => gwen.CDragon.GetChampionByIdAsync((int)x.First().ChampionId))
                .WorkAsync();

            Assert.IsInstanceOfType(data, typeof(Champion));
        }
    }
}
