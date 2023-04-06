namespace BlossomiShymae.RiotBlossom.Middleware
{
    public record LimiterHeaders
    {
        public LimiterHeader XAppRateLimit { get; init; } = default!;
        public LimiterHeader XAppRateLimitCount { get; init; } = default!;
        public LimiterHeader XMethodRateLimit { get; init; } = default!;
        public LimiterHeader XMethodRateLimitCount { get; init; } = default!;
        public int XAppRetryAfterSeconds { get; init; }
        public int XMethodRetryAfterSeconds { get; init; }
        public int XRetryAfterSeconds { get; init; }
    }
}
