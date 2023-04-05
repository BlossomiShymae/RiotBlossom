using BlossomiShymae.RiotBlossom.Core.Wrapper;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossomTests
{
    public static class StubConfig
    {
        private static readonly string s_riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY") ?? string.Empty;
        private static readonly IRiotBlossomClient s_client = RiotBlossomCore.CreateClient(
            new RiotBlossomCore.Settings
            {
                HttpClient = new HttpClient(),
                RiotApiKey = s_riotApiKey
            });
        public static IRiotBlossomClient Client => s_client;
        public static string SummonerName { get; } = "uwuie time";
        public static string SummonerTagLine { get; } = "NA1";
        public static PlatformRoute SummonerPlatform { get; } = PlatformRoute.NorthAmerica;
        public static RegionalRoute SummonerRegion { get; } = RegionalRoute.Americas;
    }
}
