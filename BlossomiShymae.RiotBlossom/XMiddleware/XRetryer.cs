namespace BlossomiShymae.RiotBlossom.XMiddleware
{
    /// <summary>
    /// The default middleware implementation for retrying requests. Unsuccessful requests will be retried a set 
    /// amount of times. Exhausting the retry limit or receiving a 429 - Too Many Requests will throw an exception.
    /// </summary>
    public class XRetry : IRetryMiddleware
    {
        public static XRetry Default { get; } = new XRetry(2, 15);
        public int RetryCount { get; init; }
        public int RetryDelay { get; init; }

        public XRetry(int retryCount, int retryDelay)
        {
            RetryCount = retryCount;
            RetryDelay = retryDelay;
        }

        public async Task<HttpResponseMessage> UseRetryAsync(Func<Task<HttpResponseMessage>> resFunc)
        {
            var retryAfterSeconds = RetryDelay;
            while (true)
            {
                HttpResponseMessage? responseMessage;
                try
                {
                    responseMessage = await resFunc();
                    if ((int)responseMessage.StatusCode == 429)
                        throw new HttpRequestException(responseMessage.ReasonPhrase, null, System.Net.HttpStatusCode.TooManyRequests);
                }
                catch (HttpRequestException) { throw; }
                catch (ArgumentNullException) { throw; }
                catch (InvalidOperationException) { throw; }
                catch (TaskCanceledException) { throw; }
                retryAfterSeconds *= 2;
                if (responseMessage != null)
                    return responseMessage;
            }
        }
    }
}
