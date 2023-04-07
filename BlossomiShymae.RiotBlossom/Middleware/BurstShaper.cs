using System.Collections.Concurrent;

namespace BlossomiShymae.RiotBlossom.Middleware
{
    internal class BurstShaper : IShaper
    {
        private readonly ConcurrentDictionary<string, AlgorithmicLimiter.Route> _headersByRoutingValue = new();

        public async Task UseRequestAsync(ExecuteInfo info, HttpRequestMessage req, Action next, Action<byte[]> hit)
        {
            var route = _headersByRoutingValue.GetValueOrDefault(info.RoutingValue, new());
            var method = route.HeadersByMethod.GetValueOrDefault(info.MethodUri, new());

            var retryAfter429Seconds = route.RetryAfterSeconds;
            if (retryAfter429Seconds > 0)
            {
                Console.WriteLine($"Encountered an enforced 429 response, retrying after {retryAfter429Seconds} seconds...");
                await Task.Delay(retryAfter429Seconds * 1000);
            }

            var retryAfterSeconds = route.ApplicationRetryAfterSeconds > method.RetryAfter ? route.ApplicationRetryAfterSeconds : method.RetryAfter;
            if (retryAfterSeconds > 0)
            {
                Console.WriteLine($"Delaying for {retryAfterSeconds} seconds to avoid 429...");
                await Task.Delay(retryAfterSeconds * 1000);
            }
            next();
        }

        public Task UseResponseAsync(ExecuteInfo info, HttpResponseMessage res, Action next)
        {
            var xRateLimiterHeaders = AlgorithmicLimiter.ProcessHeaders(res.Headers);
            var route = _headersByRoutingValue.GetValueOrDefault(info.RoutingValue, new());
            var headersByMethod = route.HeadersByMethod;
            var newMethod = new AlgorithmicLimiter.Method
            {
                Limit = xRateLimiterHeaders.MethodLimit,
                Count = xRateLimiterHeaders.MethodCounter,
                RetryAfter = xRateLimiterHeaders.MethodRetryAfterSeconds
            };
            headersByMethod[info.MethodUri] = newMethod;

            var newRoute = new AlgorithmicLimiter.Route
            {
                ApplicationLimit = xRateLimiterHeaders.ApplicationLimit,
                ApplicationCounter = xRateLimiterHeaders.ApplicationCounter,
                ApplicationRetryAfterSeconds = xRateLimiterHeaders.ApplicationRetryAfterSeconds,
                HeadersByMethod = headersByMethod,
                RetryAfterSeconds = xRateLimiterHeaders.RetryAfterSeconds
            };
            _headersByRoutingValue[info.RoutingValue] = newRoute;

            next();
            return Task.CompletedTask;
        }
    }
}
