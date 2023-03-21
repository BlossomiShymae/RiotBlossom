namespace Gwen.XMiddleware
{
	/// <summary>
	/// An interface for establishing a contract as response middleware. <see cref="UseResponse(XExecuteInfo, HttpResponseMessage, Action)"/>
	/// will be executed after receiving an HTTP response.
	/// </summary>
	public interface IResponseMiddleware
	{
		Task UseResponse(XExecuteInfo info, HttpResponseMessage res, Action next);
	}
}
