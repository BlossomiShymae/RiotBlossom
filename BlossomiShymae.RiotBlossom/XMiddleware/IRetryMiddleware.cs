namespace BlossomiShymae.RiotBlossom.XMiddleware
{
    /// <summary>
    /// An interface for establishing a contract as retry middleware. <see cref="UseRetryAsync(Func{Task{HttpResponseMessage}})"/> 
    /// will be exclusively used to invoke the HTTP response function with retrying functionality.
    /// </summary>
    public interface IRetryMiddleware
    {
        Task<HttpResponseMessage> UseRetryAsync(Func<Task<HttpResponseMessage>> resFunc);
    }
}
