namespace Gwen.XMiddleware
{
	/// <summary>
	/// The default middleware implementation for retrying requests. Unsuccessful requests will be retried a set 
	/// amount of times. Exhausting the retry limit will throw an exception.
	/// </summary>
	public class XRetry : IRetryMiddleware
	{
		public static XRetry Default { get; } = new XRetry();

		public async Task<HttpResponseMessage> UseRetry(Func<Task<HttpResponseMessage>> resFunc)
		{
			var retryAfterSeconds = 15;
			while (true)
			{
				HttpResponseMessage? responseMessage;
				try
				{
					responseMessage = await resFunc();
					if ((int)responseMessage.StatusCode == 429)
						throw new HttpRequestException(responseMessage.ReasonPhrase, null, System.Net.HttpStatusCode.TooManyRequests);
				}
				catch (Exception ex)
				{
					throw new SystemException(ex.Message);
				}
				retryAfterSeconds *= 2;
				if (responseMessage != null)
					return responseMessage;
			}
		}
	}
}
