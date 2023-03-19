namespace Gwen.XMiddleware
{
    public class XRetry : IRetryMiddleware
    {
        public static XRetry Default { get; } = new XRetry();

        public async Task<HttpResponseMessage> UseRetry(Func<Task<HttpResponseMessage>> resFunc)
        {
            var retryAfterSeconds = 15;
            HttpResponseMessage? responseMessage = null;
            while (true)
            {
                try
                {
                    responseMessage = await resFunc();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                retryAfterSeconds *= 2;
                if (responseMessage != null)
                    return responseMessage;
            }
        }
    }
}
