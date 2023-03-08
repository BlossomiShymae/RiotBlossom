using System.Net.Http.Json;

namespace Soraka.Http
{
	internal static class RiotGamesClient
	{
		public static Func<string, Func<string, Func<string, Task<T>>>>
			GetFromJsonAsync<T>(HttpClient client) =>
			(routingValue) =>
			(uri) =>
			async (query) =>
			{
				var res = await client.GetAsync($"https://{routingValue}.api.riotgames.com{uri}/{query}");
				T? data = default;
				if (res.IsSuccessStatusCode && (int)res.StatusCode != 204)
					data = await res.Content.ReadFromJsonAsync<T>();
				else
					throw new HttpRequestException(res.StatusCode.ToString());
				if (data == null)
					throw new NullReferenceException(nameof(data));

				return data;
			};
	}
}
