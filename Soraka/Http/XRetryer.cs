namespace Soraka.Http
{
	public static class XRetryer
	{
		public static async Task<HttpResponseMessage> Use(Func<Task<HttpResponseMessage>> func)
		{
			var retryAfterSeconds = 15;
			HttpResponseMessage responseMessage;
			while (true)
			{
				try
				{
					responseMessage = await func();
					if (responseMessage.IsSuccessStatusCode) break;
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ex);
				}
				finally
				{
					retryAfterSeconds *= 2;
					await Task.Delay(retryAfterSeconds * 1000);
				}
			}
			return responseMessage;
		}
	}

	public delegate Task<HttpResponseMessage> RetryMiddleware(Func<Task<HttpResponseMessage>> responseMessageFunc);
}
