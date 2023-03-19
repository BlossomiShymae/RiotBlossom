using System.Collections.Concurrent;

namespace Gwen.XMiddleware
{
	public class XBoundedCache : IRequestMiddleware, IResponseMiddleware
	{
		private static readonly ConcurrentDictionary<string, string> _cache = new();
		public static XBoundedCache Default { get; } = new XBoundedCache();

		public Task UseRequest(XExecuteInfo info, HttpRequestMessage req, Action next, Action<string> hit)
		{
			string key = req.RequestUri?.OriginalString ?? string.Empty;
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

		public async Task UseResponse(XExecuteInfo info, HttpResponseMessage res, Action next)
		{
			string key = res.RequestMessage?.RequestUri?.OriginalString ?? string.Empty;
			if (!string.IsNullOrEmpty(key) && res.IsSuccessStatusCode)
			{
				// When cache is too big, play Mario Party dice block and remove a key-value item from it to make room! >w<
				if (_cache.Count > 1000)
				{
					var item = _cache.ElementAt(Random.Shared.Next(0, _cache.Count - 1));
					_cache.Remove(item.Key, out _);
				}

				if (res.IsSuccessStatusCode)
				{
					_cache[key] = await res.Content.ReadAsStringAsync();
				}
			}
			next();
		}
	}
}
