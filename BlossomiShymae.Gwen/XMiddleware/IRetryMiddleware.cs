namespace BlossomiShymae.Gwen.XMiddleware
{
    /// <summary>
    /// An interface for establishing a contract as retry middleware. <see cref="UseRetry(Func{Task{HttpResponseMessage}})"/> 
    /// will be exclusively used to invoke the HTTP response function with retrying functionality.
    /// </summary>
    public interface IRetryMiddleware
    {
        Task<HttpResponseMessage> UseRetry(Func<Task<HttpResponseMessage>> resFunc);
    }
}
