namespace BlossomiShymae.RiotBlossom.Middleware
{
    /// <summary>
    /// An interface for establishing a contract as response middleware. <see cref="UseResponseAsync(ExecuteInfo, HttpResponseMessage, Action)"/>
    /// will be executed after receiving an HTTP response.
    /// </summary>
    public interface IResponseMiddleware
    {
        /// <summary>
        /// Executed after receiving a response.
        /// </summary>
        /// <param name="info">Routing information of request.</param>
        /// <param name="res">The raw HTTP response message.</param>
        /// <param name="next">Action to invoke for continuing to the next middleware. Not invoking will end the the response middleware chain.</param>
        /// <returns></returns>
        Task UseResponseAsync(ExecuteInfo info, HttpResponseMessage res, Action next);
    }
}
