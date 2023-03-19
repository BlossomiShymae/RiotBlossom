using System.Collections.Immutable;

namespace Gwen.XMiddleware
{
    public record XMiddlewares
    {
        public ImmutableArray<IRequestMiddleware> XRequests { get; init; } = new ImmutableArray<IRequestMiddleware>
        {
            XBoundedCache.Default,
            XRateLimiter.Default
        };
        public ImmutableArray<IResponseMiddleware> XResponses { get; init; } = new ImmutableArray<IResponseMiddleware>
        {
            XBoundedCache.Default,
            XRateLimiter.Default
        };
        public IRetryMiddleware XRetry { get; init; } = XMiddleware.XRetry.Default;
    }
}
