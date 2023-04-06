using BlossomiShymae.RiotBlossom.Exception;

namespace BlossomiShymae.RiotBlossom.Middleware
{
    /// <summary>
    /// The default middleware implementation for retrying requests. Unsuccessful requests will be retried a set 
    /// amount of times. Exhausting the retry limit or receiving a 429 - Too Many Requests will throw an exception.
    /// </summary>
    public class Retryer : IRetryMiddleware
    {
        /// <summary>
        /// The attempts to retry before throwing an <see cref="ExhaustedRetryerException"/>.
        /// </summary>
        public int RetryCount { get; init; } = 2;
        /// <summary>
        /// The time span to delay after an unsuccessful request.
        /// </summary>
        public TimeSpan RetryDelay { get; init; } = TimeSpan.FromSeconds(15.0);

        public async Task<HttpResponseMessage> UseRetryAsync(Func<Task<HttpResponseMessage>> resFunc)
        {
            TimeSpan retryDelay = RetryDelay;
            TimeSpan retryAfter = TimeSpan.Zero;
            for (int i = 0; i < RetryCount + 1; i++)
            {
                HttpResponseMessage? responseMessage;
                try
                {
                    responseMessage = await resFunc();
                    if (responseMessage.IsSuccessStatusCode)
                        return responseMessage;

                    int code = (int)responseMessage.StatusCode;
                    if (code == 429)
                    {
                        LimiterHeaders headers = Limiter.ProcessHeaders(responseMessage.Headers);
                        retryAfter = TimeSpan.FromSeconds(headers.XRetryAfterSeconds);
                        Console.WriteLine("Encountered enforced 429 - Too Many Requests...");
                    }
                    else if (code >= 400 && code < 500)
                        throw new HttpRequestException(string.Empty, null, responseMessage.StatusCode);
                }
                catch (HttpRequestException) { throw; }
                catch (ArgumentNullException) { throw; }
                catch (InvalidOperationException) { throw; }
                catch (TaskCanceledException) { throw; }
                catch (System.Exception) { throw; }

                bool isLast = i == RetryCount - 1;
                if (isLast)
                    break;

                if (retryAfter.TotalSeconds == 0)
                    await Task.Delay(retryDelay);
                else
                    await Task.Delay(retryAfter);
                // Double the delay duration
                retryDelay *= 2;
            }
            throw new ExhaustedRetryerException("Retries exceeded");
        }
    }
}
