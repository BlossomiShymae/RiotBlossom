namespace BlossomiShymae.RiotBlossom.Middleware
{
    /// <summary>
    /// An interface for establishing a contract as request middleware. <see cref="UseRequestAsync(ExecuteInfo, HttpRequestMessage, Action, Action{string})"/>
    /// will be executed before sending an HTTP request.
    /// </summary>
    public interface IRequestMiddleware
    {
        Task UseRequestAsync(ExecuteInfo info, HttpRequestMessage req, Action next, Action<string> hit);
    }
}
