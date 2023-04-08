using System.Collections.Concurrent;

namespace BlossomiShymae.RiotBlossom.Middleware
{
    internal class BurstShaper : IShaper
    {
        private readonly ConcurrentDictionary<string, AlgorithmicLimiter.Route> _headersByRoutingValue = new();
        private readonly bool _canThrowOn429;
        private readonly bool _canThrowOnLimit;

        public BurstShaper(bool canThrowOn429, bool canThrowOnLimit)
        {
            _canThrowOn429 = canThrowOn429;
            _canThrowOnLimit = canThrowOnLimit;
        }

        public async Task UseRequestAsync(ExecuteInfo info, HttpRequestMessage req, Action next, Action<byte[]> hit)
        {
            var route = _headersByRoutingValue.GetValueOrDefault(info.RoutingValue, new());
            var method = route.HeadersByMethod.GetValueOrDefault(info.MethodUri, new());

            var retryAfter429Seconds = route.RetryAfterSeconds;
            if (retryAfter429Seconds > 0)
            {
                string message = $"Retry after {retryAfter429Seconds} seconds";
                if (_canThrowOn429)
                    throw new Exception.TooManyRequestsException(message, TimeSpan.FromSeconds(retryAfter429Seconds));
                Console.WriteLine(message);
                await Task.Delay(retryAfter429Seconds * 1000);
            }

            var retryAfterSeconds = route.ApplicationRetryAfterSeconds > method.RetryAfter ? route.ApplicationRetryAfterSeconds : method.RetryAfter;
            if (retryAfterSeconds > 0)
            {
                string message = $"Wait for {retryAfterSeconds} seconds before making another request";
                if (_canThrowOnLimit)
                    throw new Exception.WarningLimiterException(message, TimeSpan.FromSeconds(retryAfterSeconds));
                Console.WriteLine(message);
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
