namespace BlossomiShymae.RiotBlossom.Exception
{
    /// <summary>
    /// An exception class used for when <see cref="Middleware.AlgorithmicLimiter"/> has reached a rate limit and
    /// cannot make any more requests without waiting. Not to be confused with <see cref="TooManyRequestsException"/> 
    /// where an actual 429 occurs.
    /// </summary>
    public class WarningLimiterException : System.Exception
    {
        private readonly TimeSpan _retryAfter;
        public TimeSpan RetryAfter { get => _retryAfter; }

        public WarningLimiterException(string message, TimeSpan retryAfter) : base(message)
        {
            _retryAfter = retryAfter;
        }

        public WarningLimiterException(string message, TimeSpan retryAfter, System.Exception innerException) : base(message, innerException)
        {
            _retryAfter = retryAfter;
        }
    }
}
