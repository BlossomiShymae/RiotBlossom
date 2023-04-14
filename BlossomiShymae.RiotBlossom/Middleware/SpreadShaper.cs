using System.Collections.Concurrent;

namespace BlossomiShymae.RiotBlossom.Middleware
{
    internal class SpreadShaper : IShaper
    {
        private readonly ConcurrentDictionary<string, AlgorithmicLimiter.Route> _headersByRoutingValue = new();
        private readonly bool _canThrowOn429;
        private readonly bool _canThrowOnLimit;

        public SpreadShaper(bool canThrowOn429, bool canThrowOnLimit)
        {
            _canThrowOn429 = canThrowOn429;
            _canThrowOnLimit = canThrowOnLimit;
        }

        public async Task UseRequestAsync(ExecuteInfo info, HttpRequestMessage req, Action next, Action<byte[]> hit)
        {
            bool routeExists = _headersByRoutingValue.TryGetValue(info.RoutingValue, out AlgorithmicLimiter.Route? route);
            if (!routeExists || route == null)
            {
                next();
                return;
            }
            bool methodExists = route.HeadersByMethod.TryGetValue(info.MethodUri, out AlgorithmicLimiter.Method? method);
            if (!methodExists || method == null)
            {
                next();
                return;
            }

            var retryAfter429Seconds = route.RetryAfterSeconds;
            if (retryAfter429Seconds > 0)
            {
                string message = $"Retry after {retryAfter429Seconds} seconds";
                if (_canThrowOn429)
                    throw new Exception.TooManyRequestsException(message, TimeSpan.FromSeconds(retryAfter429Seconds));
                Console.WriteLine(message);
                await Task.Delay(retryAfter429Seconds * 1000);
            }

            // Pre-emptive caution delay just in case. <3
            var retryAfterSeconds = route.ApplicationRetryAfterSeconds > method.RetryAfter ? route.ApplicationRetryAfterSeconds : method.RetryAfter;
            if (retryAfterSeconds > 0)
            {
                string message = $"Wait for {retryAfterSeconds} seconds before making another request";
                if (_canThrowOnLimit)
                    throw new Exception.WarningLimiterException(message, TimeSpan.FromSeconds(retryAfterSeconds));
                Console.WriteLine(message);
                await Task.Delay(retryAfterSeconds * 1000);
                next();
                return;
            }

            // Process counters for spread delay
            List<(double Progress, TimeSpan Delay)> applicationTupleList = GetProgressDelayTupleList(route.ApplicationLimit, route.ApplicationCounter);
            List<(double Progress, TimeSpan Delay)> methodTupleList = GetProgressDelayTupleList(method.Limit, method.Count);
            (double progress, TimeSpan delay) = applicationTupleList
                .Concat(methodTupleList)
                .OrderByDescending(x => x.Progress)
                .First();

            await Task.Delay(progress >= 95 ? delay * 2 : delay);
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

        private static List<(double Progress, TimeSpan Delay)> GetProgressDelayTupleList(AlgorithmicLimiter.Header limitHeader, AlgorithmicLimiter.Header countHeader)
        {
            List<(double Progress, TimeSpan Delay)> list = new();
            for (int i = 0; i < limitHeader.Limit.Length; i++)
            {
                (int limitCount, int limitSeconds) = limitHeader.Limit[i];
                (int counterCount, int counterSeconds) = countHeader.Limit[i];

                double progress = (double)counterCount / counterSeconds;
                TimeSpan delay = TimeSpan.FromSeconds((double)limitSeconds / limitCount);
                list.Add((progress, delay));
            }
            return list;
        }
    }
}
