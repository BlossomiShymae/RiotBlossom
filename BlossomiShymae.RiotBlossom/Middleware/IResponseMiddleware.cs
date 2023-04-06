namespace BlossomiShymae.RiotBlossom.Middleware
{
    /// <summary>
    /// An interface for establishing a contract as response middleware. <see cref="UseResponseAsync(ExecuteInfo, HttpResponseMessage, Action)"/>
    /// will be executed after receiving an HTTP response.
    /// </summary>
    public interface IResponseMiddleware
    {
        Task UseResponseAsync(ExecuteInfo info, HttpResponseMessage res, Action next);
    }
}
