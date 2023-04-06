namespace BlossomiShymae.RiotBlossom.XMiddleware
{
    public record XLimiterHeaders
    {
        public XLimiterHeader XAppRateLimit { get; init; } = default!;
        public XLimiterHeader XAppRateLimitCount { get; init; } = default!;
        public XLimiterHeader XMethodRateLimit { get; init; } = default!;
        public XLimiterHeader XMethodRateLimitCount { get; init; } = default!;
        public int XAppRetryAfterSeconds { get; init; }
        public int XMethodRetryAfterSeconds { get; init; }
        public int XRetryAfterSeconds { get; init; }
    }
}
