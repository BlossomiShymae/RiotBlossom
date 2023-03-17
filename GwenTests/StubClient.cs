using Gwen.Core.Wrapper;

namespace GwenTests
{
	public static class StubClient
	{
		private static readonly string _riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY") ?? string.Empty;
		private static readonly IBlanketWrapper _blanketWrapper = GwenCore.CreateBlanketWrapper(
			new GwenCore.Settings
			{
				HttpClient = new HttpClient(),
				RiotApiKey = _riotApiKey
			});

		public static IBlanketWrapper BlanketWrapper => _blanketWrapper;
	}
}
