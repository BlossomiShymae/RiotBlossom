using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Middleware;
using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

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
        private static readonly IRiotBlossomClient s_client = RiotBlossomCore.CreateClient(
            new RiotBlossomCore.Settings
            {
                HttpClient = HttpClient,
                RiotApiKey = s_riotApiKey,
                RiotMiddlewareStack = new()
                {
                    RequestSeries = ImmutableArray.Create(new IRequestMiddleware[] { s_limiter }),
                    ResponseSeries = ImmutableArray.Create(new IResponseMiddleware[] { s_limiter }),
                    Retry = s_retryer
                },
                DataMiddlewareStack = new()
                {
                    RequestSeries = ImmutableArray<IRequestMiddleware>.Empty,
                    ResponseSeries = ImmutableArray<IResponseMiddleware>.Empty,
                    Retry = null
                }
            });
        public static IRiotBlossomClient Client => s_client;
        private static readonly IRiotBlossomClient s_throwingClient = RiotBlossomCore.CreateClient(new()
        {
            HttpClient = HttpClient,
            RiotApiKey = s_riotApiKey,
            RiotMiddlewareStack = new()
            {
                RequestSeries = ImmutableArray.Create(new IRequestMiddleware[] { s_throwingLimiter }),
                ResponseSeries = ImmutableArray.Create(new IResponseMiddleware[] { s_throwingLimiter }),
                Retry = s_retryer
            },
            DataMiddlewareStack = new()
            {
                RequestSeries = ImmutableArray<IRequestMiddleware>.Empty,
                ResponseSeries = ImmutableArray<IResponseMiddleware>.Empty,
                Retry = null
            }
        });
        public static IRiotBlossomClient ThrowingClient => s_throwingClient;
        public static string SummonerName { get; } = "uwuie time";
        public static string SummonerTagLine { get; } = "NA1";
        public static Platform SummonerPlatform { get; } = Platform.NorthAmerica;
        public static Region SummonerRegion { get; } = Region.Americas;
    }
}
