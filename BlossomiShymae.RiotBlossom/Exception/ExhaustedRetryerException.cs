namespace BlossomiShymae.RiotBlossom.Exception
{
    /// <summary>
    /// <para>An exception class for <see cref="XMiddleware.XRetryer"/> when all retries are exhausted.</para>
    /// </summary>
    public class ExhaustedRetryerException : System.Exception
    {
        public ExhaustedRetryerException(string message) : base(message) { }

        public ExhaustedRetryerException(string message, System.Exception inner) : base(message, inner) { }
    }
}
