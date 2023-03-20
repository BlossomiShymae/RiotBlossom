using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.Champion;
using Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GwenTests.Api.Riot
{
	[TestClass()]
	public class ChampionApiTests
	{
		[TestMethod()]
		public async Task Api_ByDefault_ShouldReturnChampionInfo()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			ChampionInfo info = await gwen.Riot.Champion.ListAsync(PlatformRoute.NorthAmerica);

			Assert.IsInstanceOfType(info, typeof(ChampionInfo));
		}
	}
}
