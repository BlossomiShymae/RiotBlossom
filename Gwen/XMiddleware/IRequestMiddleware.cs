namespace Gwen.XMiddleware
{
	public interface IRequestMiddleware
	{
		Task UseRequest(XExecuteInfo info, HttpRequestMessage req, Action next, Action<string> hit);
	}
}
