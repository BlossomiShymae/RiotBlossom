using System.Collections.Concurrent;

namespace Gwen.XMiddleware
{
    public static class XBoundedCache
    {
        private static readonly ConcurrentDictionary<string, string> _cache = new();

        public static Task UseRequest(XExecuteInfo executeInfo, HttpRequestMessage requestMessage, Action<string> hit, Action next)
        {
            string key = requestMessage.RequestUri?.OriginalString ?? string.Empty;
            bool isHit = false;
            if (!string.IsNullOrEmpty(key))
            {
                try
                {
                    var res = _cache[key];
                    if (res != null)
                    {
                        isHit = true;
                        hit(res);
                    }
                }
                catch (Exception) { }
            }
            if (!isHit)
                next();
            return Task.CompletedTask;
        }

        public static async Task UseResponse(XExecuteInfo executeInfo, HttpResponseMessage responseMessage, Action next)
        {

            string key = responseMessage.RequestMessage?.RequestUri?.OriginalString ?? string.Empty;
            if (!string.IsNullOrEmpty(key) && responseMessage.IsSuccessStatusCode)
            {
                // When cache is too big, play Mario Party dice block and remove a key-value item from it to make room! >w<
                if (_cache.Count > 1000)
                {
                    var item = _cache.ElementAt(Random.Shared.Next(0, _cache.Count - 1));
                    _cache.Remove(item.Key, out _);
                }

                if (responseMessage.IsSuccessStatusCode)
                {
                    _cache[key] = await responseMessage.Content.ReadAsStringAsync();
                }
            }
            next();
        }
    }
}
