using Gwen.Core.Wrapper;
using Gwen.Type;

namespace GwenTests
{
	public static class StubConfig
	{
		private static readonly string _riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY") ?? string.Empty;
		private static readonly IGwenClient _simpleWrapper = GwenCore.CreateClient(
			new GwenCore.Settings
			{
				HttpClient = new HttpClient(),
				RiotApiKey = _riotApiKey
			});
		public static IGwenClient SimpleWrapper => _simpleWrapper;
		public static string SummonerName { get; } = "uwuie time";
		public static string SummonerTagLine { get; } = "NA1";
		public static PlatformRoute SummonerPlatform { get; } = PlatformRoute.NorthAmerica;
		public static RegionalRoute SummonerRegion { get; } = RegionalRoute.Americas;
	}
}
