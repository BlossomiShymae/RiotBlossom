using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Net.Http.Headers;

namespace BlossomiShymae.RiotBlossom.Middleware
{
    /// <summary>
    /// The default middleware implementation for rate limiting requests to the Riot Games API.
    /// </summary>
    public class AlgorithmicLimiter : IRequestMiddleware, IResponseMiddleware
    {
        public record Settings
        {
            /// <summary>
            /// The type to use for shaping requests.
            /// </summary>
            public LimiterShaper ShaperType { get; init; } = LimiterShaper.Burst;
            /// <summary>
            /// Whether to throw a <see cref="Exception.TooManyRequestsException"/> on receiving a 429.
            /// </summary>
            public bool CanThrowOn429 { get; init; } = true;
            /// <summary>
            /// Whether to throw a <see cref="Exception.WarningLimiterException"/> when a rate limit is reached.
            /// Setting to false will have the limiter automatically await the time remaining before retrying.
            /// </summary>
            public bool CanThrowOnLimit { get; init; } = true;
        }

        private readonly ImmutableDictionary<LimiterShaper, IShaper> _shaper;
        private readonly LimiterShaper _shaperType;

        public AlgorithmicLimiter(Settings settings)
        {
            _shaperType = settings.ShaperType;
            _shaper = new Dictionary<LimiterShaper, IShaper>()
            {
                { settings.ShaperType, new BurstShaper(settings.CanThrowOn429, settings.CanThrowOnLimit) },
            }.ToImmutableDictionary();
        }

        public AlgorithmicLimiter() : this(new()) { }

        public async Task UseRequestAsync(ExecuteInfo info, HttpRequestMessage req, Action next, Action<byte[]> hit)
        {
            await _shaper[_shaperType].UseRequestAsync(info, req, next, hit);
        }

        public async Task UseResponseAsync(ExecuteInfo info, HttpResponseMessage res, Action next)
        {
            await _shaper[_shaperType].UseResponseAsync(info, res, next);
        }

        internal static Headers ProcessHeaders(HttpResponseHeaders headers)
        {
            Header applicationLimit = ProcessHeader(headers, RiotHeader.ApplicationLimit);
            Header applicationCounter = ProcessHeader(headers, RiotHeader.ApplicationCount);
            Header methodLimit = ProcessHeader(headers, RiotHeader.MethodLimit);
            Header methodCounter = ProcessHeader(headers, RiotHeader.MethodCount);

            int applicationRetryAfterSeconds = ProcessRateLimit(applicationLimit, applicationCounter);
            int methodRetryAfterSeconds = ProcessRateLimit(methodLimit, methodCounter);
            int retryAfterSeconds = 0;
            try
            {
                retryAfterSeconds = int.Parse(ExtractHeader(headers, RiotHeader.RetryAfter));
            }
            catch (InvalidOperationException) { }

            return new Headers
            {
                ApplicationLimit = applicationLimit,
                ApplicationCounter = applicationCounter,
                MethodLimit = methodLimit,
                MethodCounter = methodCounter,
                ApplicationRetryAfterSeconds = applicationRetryAfterSeconds,
                MethodRetryAfterSeconds = methodRetryAfterSeconds,
                RetryAfterSeconds = retryAfterSeconds
            };
        }

        private static int ProcessRateLimit(Header limitHeader, Header counterHeader)
        {
            if (limitHeader.Limit.Length != counterHeader.Limit.Length)
                throw new InvalidOperationException("X-Rate-Limit headers have unbalanced limits and counts");

            var retryAfterSeconds = 0;
            for (int i = 0; i < limitHeader.Limit.Length; i++)
            {
                if (counterHeader.Limit[i].Count + 1 >= limitHeader.Limit[i].Count)
                    if (retryAfterSeconds < limitHeader.Limit[i].Seconds)
                        retryAfterSeconds = limitHeader.Limit[i].Seconds;
            }

            return retryAfterSeconds;
        }

        private static Header ProcessHeader(HttpResponseHeaders headers, string key)
        {
            string commaSeperatedRateLimit = ExtractHeader(headers, key);
            string[] commaSeperatedRateLimits = commaSeperatedRateLimit
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            var rateLimiters = commaSeperatedRateLimits
                .Select(x => x
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToImmutableArray())
                .Select(x => (x[0], x[1]))
                .ToImmutableArray();

            return new Header(rateLimiters);
        }

        private static string ExtractHeader(HttpResponseHeaders headers, string key)
        {
            string? value = headers.GetValues(key).FirstOrDefault();
            return value ?? throw new NullReferenceException($"X-Rate-Limit header value for {key} is null");
        }

        internal record Headers
        {
            public Header ApplicationLimit { get; init; } = default!;
            public Header ApplicationCounter { get; init; } = default!;
            public Header MethodLimit { get; init; } = default!;
            public Header MethodCounter { get; init; } = default!;
            public int ApplicationRetryAfterSeconds { get; init; }
            public int MethodRetryAfterSeconds { get; init; }
            public int RetryAfterSeconds { get; init; }
        }

        internal record Header(ImmutableArray<(int Count, int Seconds)> Limit);

        internal record Route
        {
            public Header ApplicationLimit { get; init; } = default!;
            public Header ApplicationCounter { get; init; } = default!;
            public int ApplicationRetryAfterSeconds { get; init; }
            public int RetryAfterSeconds { get; init; }
            public ConcurrentDictionary<string, Method> HeadersByMethod { get; init; } = new ConcurrentDictionary<string, Method>();
        }

        internal record Method
        {
            public Header Limit { get; init; } = default!;
            public Header Count { get; init; } = default!;
            public int RetryAfter { get; init; }
        }
    }
}
