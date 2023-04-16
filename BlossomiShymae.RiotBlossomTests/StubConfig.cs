using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Middleware;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossomTests
{
    public static class StubConfig
    {
        public static readonly HttpClient HttpClient = new();
        private static readonly string s_riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY") ?? string.Empty;
        private static readonly AlgorithmicLimiter s_limiter = new(new()
        {
            CanThrowOn429 = false,
            CanThrowOnLimit = false,
            ShaperType = LimiterShaper.Burst
        });
        private static readonly AlgorithmicLimiter s_throwingLimiter = new(new()
        {
            CanThrowOn429 = true,
            CanThrowOnLimit = true,
            ShaperType = LimiterShaper.Burst
        });
        private static readonly InMemoryCache s_riotCache = new("rb-riot-cache");
        private static readonly InMemoryCache s_dataCache = new("rb-data-cache");
        private static readonly Retryer s_retryer = new();
        private static readonly IRiotBlossomClient s_client = RiotBlossomCore.CreateClientBuilder()
            .AddRiotApiKey(s_riotApiKey)
            .AddHttpClient(HttpClient)
            .AddRiotMiddlewareStack(o =>
            {
                o.AddAlgorithmicLimiter(s_limiter);
                o.AddRetryer(s_retryer);
                return o;
            })
            .AddDataMiddlewareStack(o => o)
            .Build();
        public static IRiotBlossomClient Client => s_client;
        private static readonly IRiotBlossomClient s_throwingClient = RiotBlossomCore.CreateClientBuilder()
            .AddHttpClient(HttpClient)
            .AddRiotApiKey(s_riotApiKey)
            .AddRiotMiddlewareStack(o =>
            {
                o.AddAlgorithmicLimiter(s_throwingLimiter);
                o.AddRetryer(s_retryer);
                return o;
            })
            .AddDataMiddlewareStack(o => o)
            .Build();
        public static IRiotBlossomClient ThrowingClient => s_throwingClient;
        public static string SummonerName { get; } = "uwuie time";
        public static string SummonerTagLine { get; } = "NA1";
        public static Platform SummonerPlatform { get; } = Platform.NorthAmerica;
        public static Region SummonerRegion { get; } = Region.Americas;
    }
}
