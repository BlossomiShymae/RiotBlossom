using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.XMiddleware
{
    /// <summary>
    /// A collection of middlewares used for the HTTP request/execute/response cycle.
    /// </summary>
    public record XMiddlewares
    {
        public ImmutableArray<IRequestMiddleware> XRequests { get; init; } = ImmutableArray.Create(new IRequestMiddleware[]
        {
            XInMemoryCache.Default,
            XLimiter.Default
        });
        public ImmutableArray<IResponseMiddleware> XResponses { get; init; } = ImmutableArray.Create(new IResponseMiddleware[]
        {
            XInMemoryCache.Default,
            XLimiter.Default
        });
        public IRetryMiddleware XRetry { get; init; } = XMiddleware.XRetryer.Default;
    }
}
