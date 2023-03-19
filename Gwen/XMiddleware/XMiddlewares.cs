using System.Collections.Immutable;

namespace Gwen.XMiddleware
{
    public record XMiddlewares
    {
        public ImmutableArray<XRequestMiddleware> XRequests { get; init; } = new List<XRequestMiddleware>
            {
                XBoundedCache.UseRequest,
                XRateLimiter.UseRequest
            }.ToImmutableArray();
        public ImmutableArray<XResponseMiddleware> XResponses { get; init; } = new List<XResponseMiddleware>
            {
                XBoundedCache.UseResponse,
                XRateLimiter.UseResponse
            }.ToImmutableArray();
        public XRetryMiddleware XRetry { get; init; } = XMiddleware.XRetry.UseRetry;
    }


    public delegate Task XRequestMiddleware(XExecuteInfo executeInfo, HttpRequestMessage requestMessage, Action<string> hit, Action next);
    public delegate Task XResponseMiddleware(XExecuteInfo executeInfo, HttpResponseMessage responseMessage, Action next);
    public delegate Task<HttpResponseMessage> XRetryMiddleware(Func<Task<HttpResponseMessage>> responseMessageFunc);
}
