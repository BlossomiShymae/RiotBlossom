using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Soraka.Api.Tests
{
	[TestClass()]
	public class SummonerApiTests
	{
		[TestMethod()]
		public async Task UseApiTest()
		{
			var api = SummonerApi.UseApi(new HttpClient());

			var response = await api.GetSummonerBySummonerNameAsync("uwuie%20time");
			Trace.WriteLine(await response.Content.ReadAsStringAsync());

			Assert.IsTrue(response.IsSuccessStatusCode);
		}
	}
}