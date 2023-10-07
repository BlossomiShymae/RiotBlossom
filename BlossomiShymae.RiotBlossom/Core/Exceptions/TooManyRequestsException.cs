namespace BlossomiShymae.RiotBlossom.Exception
{
    /// <summary>
    /// An exception class used for a 429 - Too Many Requests.
    /// </summary>
    public class TooManyRequestsException : System.Exception
    {
        private readonly TimeSpan _retryAfter;
        /// <summary>
        /// The time span duration to retry after, if any exists.
        /// </summary>
        public TimeSpan RetryAfter { get => _retryAfter; }

        public TooManyRequestsException(string message, TimeSpan retryAfter) : base(message)
        {
            _retryAfter = retryAfter;
        }

        public TooManyRequestsException(string message, TimeSpan retryAfter, System.Exception innerException) : base(message, innerException)
        {
            _retryAfter = retryAfter;
        }
    }
}
