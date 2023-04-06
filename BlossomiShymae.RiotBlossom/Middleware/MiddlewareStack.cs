using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Middleware
{
    /// <summary>
    /// A collection of middlewares used for the HTTP request/execute/response cycle.
    /// </summary>
    public record MiddlewareStack
    {
        public ImmutableArray<IRequestMiddleware> RequestSeries { get; init; } = ImmutableArray.Create(new IRequestMiddleware[]
        {
            InMemoryCache.Default,
            Limiter.Default
        });
        public IRetryMiddleware Retry { get; init; } = Middleware.Retryer.Default;
        public ImmutableArray<IResponseMiddleware> ResponseSeries { get; init; } = ImmutableArray.Create(new IResponseMiddleware[]
        {
            InMemoryCache.Default,
            Limiter.Default
        });
    }
}
