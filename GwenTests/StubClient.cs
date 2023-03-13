using Gwen.Core;

namespace GwenTests
{
	public static class StubClient
	{
		private static readonly string _riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY") ?? string.Empty;
		private static readonly GwenCore.WidespreadClient _widespread = GwenCore.UseWidespreadClient(
			new GwenCore.Settings
			{
				HttpClient = new HttpClient(),
				RiotApiKey = _riotApiKey
			});

		public static GwenCore.WidespreadClient UseWidespread() => _widespread;
	}
}
