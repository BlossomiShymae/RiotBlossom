namespace Gwen.Http
{
	internal interface IHttpClient
	{
		Task<string> GetStringAsync(string uri);
	}
}
