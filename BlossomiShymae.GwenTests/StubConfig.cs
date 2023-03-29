using BlossomiShymae.Gwen.Core.Wrapper;
using BlossomiShymae.Gwen.Type;

namespace GwenTests
{
    public static class StubConfig
    {
        private static readonly string s_riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY") ?? string.Empty;
        private static readonly IGwenClient s_gwen = GwenCore.CreateClient(
            new GwenCore.Settings
            {
                HttpClient = new HttpClient(),
                RiotApiKey = s_riotApiKey
            });
        public static IGwenClient Gwen => s_gwen;
        public static string SummonerName { get; } = "uwuie time";
        public static string SummonerTagLine { get; } = "NA1";
        public static PlatformRoute SummonerPlatform { get; } = PlatformRoute.NorthAmerica;
        public static RegionalRoute SummonerRegion { get; } = RegionalRoute.Americas;
    }
}
