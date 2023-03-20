using Gwen.Core.Wrapper;

namespace GwenTests
{
	public static class StubClient
	{
		private static readonly string _riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY") ?? string.Empty;
		private static readonly ISimpleWrapper _simpleWrapper = GwenCore.CreateSimpleWrapper(
			new GwenCore.Settings
			{
				HttpClient = new HttpClient(),
				RiotApiKey = _riotApiKey
			});
		public static ISimpleWrapper SimpleWrapper => _simpleWrapper;
	}
}
