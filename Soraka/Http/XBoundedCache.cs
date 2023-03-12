using System.Collections.Concurrent;

namespace Soraka.Http
{
	public static class XBoundedCache
	{
		private static readonly ConcurrentDictionary<string, HttpResponseMessage> _cache = new();

		public static HttpRequestMessage UseRequest(HttpRequestMessage requestMessage, Action<HttpResponseMessage> hit)
		{
			String key = requestMessage.RequestUri?.OriginalString ?? string.Empty;
			if (!string.IsNullOrEmpty(key))
			{
				try
				{
					var res = _cache[key];
					if (res != null)
						hit(res);
				}
				catch (Exception) { }
			}

			return requestMessage;
		}

		public static HttpResponseMessage UseResponse(HttpResponseMessage responseMessage)
		{
			String key = responseMessage.RequestMessage?.RequestUri?.OriginalString ?? string.Empty;
			if (!string.IsNullOrEmpty(key) && responseMessage.IsSuccessStatusCode)
			{
				// When cache is too big, play Mario Party dice block and remove a key-value item from it to make room! >w<
				if (_cache.Count > 1000)
				{
					var item = _cache.ElementAt(Random.Shared.Next(0, _cache.Count - 1));
					_cache.Remove(item.Key, out _);
					item.Value.Dispose();
				}
				_cache[key] = responseMessage;
			}

			return responseMessage;
		}
	}
}
