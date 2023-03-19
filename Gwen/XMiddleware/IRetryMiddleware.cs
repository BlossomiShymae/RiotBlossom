namespace Gwen.XMiddleware
{
	public interface IRetryMiddleware
	{
		Task<HttpResponseMessage> UseRetry(Func<Task<HttpResponseMessage>> resFunc);
	}
}
