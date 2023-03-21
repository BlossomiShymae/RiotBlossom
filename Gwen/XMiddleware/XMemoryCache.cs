using System.Runtime.Caching;

namespace Gwen.XMiddleware
{
	/// <summary>
	/// The default middleware implementation for caching associated response data. Data will be 
	/// removed when the cache count limit is reached. Data will also expire after a determined amount
	/// of time passes.
	/// </summary>
	public class XMemoryCache : IRequestMiddleware, IResponseMiddleware
	{
		private static readonly MemoryCache s_cache = MemoryCache.Default;
		public static XMemoryCache Default { get; } = new XMemoryCache();

		public Task UseRequest(XExecuteInfo info, HttpRequestMessage req, Action next, Action<string> hit)
		{
			string key = req.RequestUri?.OriginalString ?? string.Empty;
			bool isHit = false;
			if (!string.IsNullOrEmpty(key))
			{
				try
				{
					var res = (string)s_cache[key];
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
				if (s_cache.GetCount() > 1000)
				{
					var item = s_cache.ElementAt(Random.Shared.Next(0, (int)s_cache.GetCount() - 1));
					s_cache.Remove(item.Key);
				}

				if (res.IsSuccessStatusCode)
				{
					string data = await res.Content.ReadAsStringAsync();
					s_cache.Add(key, data, new CacheItemPolicy
					{
						AbsoluteExpiration = DateTimeOffset.Now.AddHours(6)
					});
					s_cache[key] = await res.Content.ReadAsStringAsync();
				}
			}
			next();
		}
	}
}
