namespace Gwen.Http
{
    public static class XRetry
    {
        public static async Task<HttpResponseMessage> UseRetry(Func<Task<HttpResponseMessage>> func)
        {
            var retryAfterSeconds = 15;
            HttpResponseMessage? responseMessage = null;
            while (true)
            {
                try
                {
                    responseMessage = await func();
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
