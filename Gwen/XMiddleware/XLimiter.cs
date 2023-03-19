using AsyncKeyedLock;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Net.Http.Headers;

namespace Gwen.XMiddleware
{
    public class XLimiter : IRequestMiddleware, IResponseMiddleware
    {
        private static readonly AsyncKeyedLocker<string> s_locker = new AsyncKeyedLocker<string>();
        private static readonly ConcurrentDictionary<string, XRateLimiterRoute> _headersByRoutingValue = new();
        private static readonly string _appRateLimitKey = "x-app-rate-limit";
        private static readonly string _appRateLimitCountKey = "x-app-rate-limit-count";
        private static readonly string _methodRateLimitKey = "x-method-rate-limit";
        private static readonly string _methodRateLimitCountKey = "x-method-rate-limit-count";
        private static readonly string _retryAfterKey = "retry-after";
        public static XLimiter Default { get; } = new XLimiter();

        public async Task UseRequest(XExecuteInfo info, HttpRequestMessage req, Action next, Action<string> hit)
        {
            using (await s_locker.LockAsync(info.RoutingValue))
            {
                var route = _headersByRoutingValue.GetValueOrDefault(info.RoutingValue, new());
                var method = route.XRateLimiterHeadersByMethod.GetValueOrDefault(info.MethodUri, new());

                var retryAfter429Seconds = route.XRetryAfter;
                if (retryAfter429Seconds > 0)
                {
                    Console.WriteLine($"Encountered an enforced 429 response, retrying after {retryAfter429Seconds} seconds...");
                    await Task.Delay(retryAfter429Seconds * 1000);
                }

                var retryAfterSeconds = route.XAppRetryAfter > method.XMethodRetryAfter ? route.XAppRetryAfter : method.XMethodRetryAfter;
                if (retryAfterSeconds > 0)
                {
                    Console.WriteLine($"Delaying for {retryAfterSeconds} seconds to avoid 429...");
                    await Task.Delay(retryAfterSeconds * 1000);
                }
                next();
            }
        }

        public async Task UseResponse(XExecuteInfo info, HttpResponseMessage res, Action next)
        {
            using (await s_locker.LockAsync(info.RoutingValue))
            {
                var xRateLimiterHeaders = ProcessHeaders(res.Headers);
                var route = _headersByRoutingValue.GetValueOrDefault(info.RoutingValue, new());
                var headersByMethod = route.XRateLimiterHeadersByMethod;

                var newMethod = new XRateLimiterMethod
                {
                    XMethodRateLimit = xRateLimiterHeaders.XMethodRateLimit,
                    XMethodRateLimitCount = xRateLimiterHeaders.XMethodRateLimitCount,
                    XMethodRetryAfter = xRateLimiterHeaders.XMethodRetryAfterSeconds
                };
                headersByMethod[info.MethodUri] = newMethod;

                var newRoute = new XRateLimiterRoute
                {
                    XAppRateLimit = xRateLimiterHeaders.XAppRateLimit,
                    XAppRateLimitCount = xRateLimiterHeaders.XAppRateLimitCount,
                    XAppRetryAfter = xRateLimiterHeaders.XAppRetryAfterSeconds,
                    XRateLimiterHeadersByMethod = headersByMethod,
                    XRetryAfter = xRateLimiterHeaders.XRetryAfterSeconds
                };
                _headersByRoutingValue[info.RoutingValue] = newRoute;

                next();
            }
        }

        private static XRateLimiterHeaders ProcessHeaders(HttpResponseHeaders headers)
        {
            var appRateLimit = ProcessHeader(headers, _appRateLimitKey);
            var appRateLimitCount = ProcessHeader(headers, _appRateLimitCountKey);
            var methodRateLimit = ProcessHeader(headers, _methodRateLimitKey);
            var methodRateLimitCount = ProcessHeader(headers, _methodRateLimitCountKey);

            var appRetryAfterSeconds = ProcessRateLimit(appRateLimit, appRateLimitCount);
            var methodRetryAfterSeconds = ProcessRateLimit(methodRateLimit, methodRateLimitCount);
            int retryAfterSeconds = 0;
            try
            {
                retryAfterSeconds = int.Parse(ExtractHeader(headers, _retryAfterKey));
            }
            catch (InvalidOperationException) { }

            return new XRateLimiterHeaders
            {
                XAppRateLimit = appRateLimit,
                XAppRateLimitCount = appRateLimitCount,
                XMethodRateLimit = methodRateLimit,
                XMethodRateLimitCount = methodRateLimitCount,
                XAppRetryAfterSeconds = appRetryAfterSeconds,
                XMethodRetryAfterSeconds = methodRetryAfterSeconds,
                XRetryAfterSeconds = retryAfterSeconds
            };
        }

        private static int ProcessRateLimit(XRateLimiterHeader xLimitHeader, XRateLimiterHeader xLimitCountHeader)
        {
            if (xLimitHeader.RateLimiterArray.Length != xLimitCountHeader.RateLimiterArray.Length)
                throw new InvalidOperationException("X-Rate-Limit headers have unbalanced limits and counts");

            var retryAfterSeconds = 0;
            for (int i = 0; i < xLimitHeader.RateLimiterArray.Length; i++)
            {
                if (xLimitCountHeader.RateLimiterArray[i].requestCount + 1 >= xLimitHeader.RateLimiterArray[i].requestCount)
                    if (retryAfterSeconds < xLimitHeader.RateLimiterArray[i].intervalSeconds)
                        retryAfterSeconds = xLimitHeader.RateLimiterArray[i].intervalSeconds;
            }

            return retryAfterSeconds;
        }

        private static XRateLimiterHeader ProcessHeader(HttpResponseHeaders headers, string key)
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

            return new XRateLimiterHeader(rateLimiters);
        }

        private static string ExtractHeader(HttpResponseHeaders headers, string key)
        {
            string? value = headers.GetValues(key).FirstOrDefault();
            if (value == null)
                throw new NullReferenceException($"X-Rate-Limit header value for {key} is null");
            return value;
        }

        private record XRateLimiterRoute
        {
            public XRateLimiterHeader XAppRateLimit { get; init; } = default!;
            public XRateLimiterHeader XAppRateLimitCount { get; init; } = default!;
            public int XAppRetryAfter { get; init; }
            public int XRetryAfter { get; init; }
            public ConcurrentDictionary<string, XRateLimiterMethod> XRateLimiterHeadersByMethod { get; init; } = new ConcurrentDictionary<string, XRateLimiterMethod>();
        }

        private record XRateLimiterMethod
        {
            public XRateLimiterHeader XMethodRateLimit { get; init; } = default!;
            public XRateLimiterHeader XMethodRateLimitCount { get; init; } = default!;
            public int XMethodRetryAfter { get; init; }
        }

        private record XRateLimiterHeaders
        {
            public XRateLimiterHeader XAppRateLimit { get; init; } = default!;
            public XRateLimiterHeader XAppRateLimitCount { get; init; } = default!;
            public XRateLimiterHeader XMethodRateLimit { get; init; } = default!;
            public XRateLimiterHeader XMethodRateLimitCount { get; init; } = default!;
            public int XAppRetryAfterSeconds { get; init; }
            public int XMethodRetryAfterSeconds { get; init; }
            public int XRetryAfterSeconds { get; init; }
        }

        private record XRateLimiterHeader(ImmutableArray<(int requestCount, int intervalSeconds)> RateLimiterArray);
    }
}
