using System.Collections.Immutable;
using System.Net.Http.Headers;

namespace Gwen.Http
{
    public static class XRateLimiter
    {
        private static readonly string _appRateLimitKey = "x-app-rate-limit";
        private static readonly string _appRateLimitCountKey = "x-app-rate-limit-count";
        private static readonly string _methodRateLimitKey = "x-method-rate-limit";
        private static readonly string _methodRateLimitCountKey = "x-method-rate-limit-count";

        public static XRateLimiterHeaders ProcessHeaders(HttpResponseHeaders headers)
        {
            var processHeader = ProcessHeader(headers);

            var appRateLimit = processHeader(_appRateLimitKey);
            var appRateLimitCount = processHeader(_appRateLimitCountKey);
            var methodRateLimit = processHeader(_methodRateLimitKey);
            var methodRateLimitCount = processHeader(_methodRateLimitCountKey);

            var retryAfterSeconds = ProcessRateLimit(appRateLimit, appRateLimitCount);
            var secondaryRetryAfterSeconds = ProcessRateLimit(methodRateLimit, methodRateLimitCount);

            if (retryAfterSeconds < secondaryRetryAfterSeconds)
                retryAfterSeconds = secondaryRetryAfterSeconds;

            return new XRateLimiterHeaders
            {
                XAppRateLimit = appRateLimit,
                XAppRateLimitCount = appRateLimitCount,
                XMethodRateLimit = methodRateLimit,
                XMethodRateLimitCount = methodRateLimitCount,
                RetryAfterSeconds = retryAfterSeconds
            };
        }

        public static int ProcessRateLimit(XRateLimiterHeader xLimitHeader, XRateLimiterHeader xLimitCountHeader)
        {
            var retryAfterSeconds = 0;
            if (xLimitCountHeader.PrimaryLimiterArray[0] + 1 >= xLimitHeader.PrimaryLimiterArray[0])
                retryAfterSeconds = xLimitHeader.PrimaryLimiterArray[1];
            if (xLimitCountHeader.SecondaryLimiterArray[0] + 1 >= xLimitHeader.SecondaryLimiterArray[0])
                if (retryAfterSeconds < xLimitHeader.SecondaryLimiterArray[0])
                    retryAfterSeconds = xLimitHeader.SecondaryLimiterArray[1];

            return retryAfterSeconds;
        }

        public static ProcessHeaderFunc
            ProcessHeader(HttpResponseHeaders headers) =>
            (key) =>
            {
                var rateLimitCommaSeperatedString = headers.Get(key);
                var rateLimitColonSeperatedArray = rateLimitCommaSeperatedString
                    .Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (rateLimitColonSeperatedArray.Length != 2)
                    throw new InvalidOperationException($"There must be two rate limits for X header value");

                var primaryLimiterArray = rateLimitColonSeperatedArray[0]
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToImmutableArray();
                var secondaryLimiterArray = rateLimitColonSeperatedArray[1]
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToImmutableArray();

                return new XRateLimiterHeader(primaryLimiterArray, secondaryLimiterArray);
            };



        public delegate XRateLimiterHeader ProcessHeaderFunc(string key);

        public static string Get(this HttpResponseHeaders headers, string key)
        {
            var value = headers.GetValues(key).FirstOrDefault();
            if (value == null)
                throw new NullReferenceException($"X-Rate-Limit header value for {key} is null");
            return value;
        }
    }

    public record XRateLimiterHeaders
    {
        public XRateLimiterHeader XAppRateLimit { get; init; } = default!;
        public XRateLimiterHeader XAppRateLimitCount { get; init; } = default!;
        public XRateLimiterHeader XMethodRateLimit { get; init; } = default!;
        public XRateLimiterHeader XMethodRateLimitCount { get; init; } = default!;
        public int RetryAfterSeconds { get; init; }
    }

    public record XRateLimiterHeader(ImmutableArray<int> PrimaryLimiterArray, ImmutableArray<int> SecondaryLimiterArray);
}
