using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.Account;
using Gwen.Type;
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
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			account = await gwen.Riot.Account.GetAccountByRiotIdAsync(RegionalRoute.Americas, "uwuie time", "NA1");
		}

		[TestMethod()]
		public async Task Api_WithPuuid_ShouldReturnAccountDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			AccountDto dto = await gwen.Riot.Account.GetAccountByPuuidAsync(RegionalRoute.Americas, account.Puuid);

			Assert.IsInstanceOfType(dto, typeof(AccountDto));
		}

		[TestMethod()]
		public async Task Api_WithRiotId_ShouldReturnAccountDto()
		{
			ISimpleWrapper gwen = StubClient.SimpleWrapper;

			AccountDto dto = await gwen.Riot.Account.GetAccountByRiotIdAsync(RegionalRoute.Americas, "uwuie time", "NA1");

			Assert.IsInstanceOfType(dto, typeof(AccountDto));
		}
	}
}
