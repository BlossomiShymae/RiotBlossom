namespace BlossomiShymae.RiotBlossom.XMiddleware
{
    /// <summary>
    /// An interface for establishing a contract as response middleware. <see cref="UseResponseAsync(XExecuteInfo, HttpResponseMessage, Action)"/>
    /// will be executed after receiving an HTTP response.
    /// </summary>
    public interface IResponseMiddleware
    {
        Task UseResponseAsync(XExecuteInfo info, HttpResponseMessage res, Action next);
    }
}
