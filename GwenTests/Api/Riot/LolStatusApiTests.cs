using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.LolStatus;
using Gwen.Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GwenTests.Api.Riot
{
	[TestClass()]
	public class LolStatusApiTests
	{
		[TestMethod()]
		public async Task Api_ByDefault_ShouldReturnPlatformDataDto()
		{
			IGwenClient gwen = StubConfig.Gwen;

			PlatformDataDto dto = await gwen.Riot.LolStatus.GetPlatformStatusAsync(PlatformRoute.NorthAmerica);

			Assert.IsInstanceOfType(dto, typeof(PlatformDataDto));
		}
	}
}
