using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GwenTests.Api.Riot
{
	[TestClass()]
	public class AccountApiTests
	{
		public static AccountDto account = default!;

		[ClassInitialize()]
		public static async Task Initialize(TestContext testContext)
		{
			IGwenClient gwen = StubConfig.SimpleWrapper;

			account = await gwen.Riot.Account.GetAccountByRiotIdAsync(StubConfig.SummonerRegion, StubConfig.SummonerName, StubConfig.SummonerTagLine);
		}

		[TestMethod()]
		public async Task Api_WithPuuid_ShouldReturnAccountDto()
		{
			IGwenClient gwen = StubConfig.SimpleWrapper;

			AccountDto dto = await gwen.Riot.Account.GetAccountByPuuidAsync(StubConfig.SummonerRegion, account.Puuid);

			Assert.IsInstanceOfType(dto, typeof(AccountDto));
		}

		[TestMethod()]
		public async Task Api_WithRiotId_ShouldReturnAccountDto()
		{
			IGwenClient gwen = StubConfig.SimpleWrapper;

			AccountDto dto = await gwen.Riot.Account.GetAccountByRiotIdAsync(StubConfig.SummonerRegion, StubConfig.SummonerName, StubConfig.SummonerTagLine);

			Assert.IsInstanceOfType(dto, typeof(AccountDto));
		}
	}
}
