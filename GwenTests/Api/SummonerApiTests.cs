using Gwen.Dto.Summoner;
using GwenTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gwen.Api.Tests
{
	[TestClass()]
	public class SummonerApiTests
	{
		[TestMethod()]
		public async Task UseApiTest()
		{
			var gwen = StubClient.UseWidespread();

			var summonerDto = await gwen.Riot[Type.PlatformRoute.NorthAmerica].Summoner.GetSummonerByNameAsync("uwuie time");

			Assert.IsTrue(summonerDto is SummonerDto);
		}
	}
}