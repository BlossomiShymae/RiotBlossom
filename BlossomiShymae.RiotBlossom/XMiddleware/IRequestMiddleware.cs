namespace BlossomiShymae.RiotBlossom.XMiddleware
{
    /// <summary>
    /// An interface for establishing a contract as request middleware. <see cref="UseRequest(XExecuteInfo, HttpRequestMessage, Action, Action{string})"/>
    /// will be executed before sending an HTTP request.
    /// </summary>
    public interface IRequestMiddleware
    {
        Task UseRequest(XExecuteInfo info, HttpRequestMessage req, Action next, Action<string> hit);
    }
}
