namespace BlossomiShymae.RiotBlossom.Middleware
{
    /// <summary>
    /// An interface for establishing a contract as request middleware. <see cref="UseRequestAsync(ExecuteInfo, HttpRequestMessage, Action, Action{Byte[]})"/>
    /// will be executed before sending an HTTP request.
    /// </summary>
    public interface IRequestMiddleware
    {
        /// <summary>
        /// Executed before sending a request.
        /// </summary>
        /// <param name="info">Routing information of request.</param>
        /// <param name="req">The raw HTTP request message.</param>
        /// <param name="next">Action to invoke for continuing to the next middleware. Not invoking will end the request middleware chain.</param>
        /// <param name="hit">Action to invoke for sending cached data.</param>
        /// <returns></returns>
        Task UseRequestAsync(ExecuteInfo info, HttpRequestMessage req, Action next, Action<byte[]> hit);
    }
}
