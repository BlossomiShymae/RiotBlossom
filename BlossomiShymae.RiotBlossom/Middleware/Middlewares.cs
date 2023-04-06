using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Middleware
{
    /// <summary>
    /// A collection of middlewares used for the HTTP request/execute/response cycle.
    /// </summary>
    public record Middlewares
    {
        public ImmutableArray<IRequestMiddleware> XRequests { get; init; } = ImmutableArray.Create(new IRequestMiddleware[]
        {
            InMemoryCache.Default,
            Limiter.Default
        });
        public ImmutableArray<IResponseMiddleware> XResponses { get; init; } = ImmutableArray.Create(new IResponseMiddleware[]
        {
            InMemoryCache.Default,
            Limiter.Default
        });
        public IRetryMiddleware XRetry { get; init; } = Middleware.Retryer.Default;
    }
}
