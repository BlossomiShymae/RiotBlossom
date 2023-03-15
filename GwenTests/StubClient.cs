using Gwen.Core;

namespace GwenTests
{
	public static class StubClient
	{
		private static readonly string _riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY") ?? string.Empty;
		private static readonly IBlanketStitch _blanketStitch = GwenCore.CreateBlanketStitch(
			new GwenCore.Settings
			{
				HttpClient = new HttpClient(),
				RiotApiKey = _riotApiKey
			});

		public static IBlanketStitch BlanketStitch => _blanketStitch;
	}
}
