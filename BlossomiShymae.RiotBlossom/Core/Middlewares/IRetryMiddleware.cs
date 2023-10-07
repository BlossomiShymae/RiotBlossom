namespace BlossomiShymae.RiotBlossom.Middleware
{
    /// <summary>
    /// An interface for establishing a contract as retry middleware. <see cref="UseRetryAsync(Func{Task{HttpResponseMessage}})"/> 
    /// will be exclusively used to invoke the HTTP response function with retrying functionality.
    /// </summary>
    public interface IRetryMiddleware
    {
        /// <summary>
        /// Executed on request.
        /// </summary>
        /// <param name="resFunc">Function to invoke for receiving a HTTP response.</param>
        /// <returns></returns>
        Task<HttpResponseMessage> UseRetryAsync(Func<Task<HttpResponseMessage>> resFunc);
    }
}
