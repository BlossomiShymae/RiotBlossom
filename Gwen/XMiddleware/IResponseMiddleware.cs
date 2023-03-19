namespace Gwen.XMiddleware
{
	public interface IResponseMiddleware
	{
		Task UseResponse(XExecuteInfo info, HttpResponseMessage res, Action next);
	}
}
