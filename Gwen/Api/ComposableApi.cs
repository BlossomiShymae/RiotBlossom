using Gwen.Http;
using System.Text.Json;

namespace Gwen.Api
{
	internal class ComposableApi<T>
	{
		private readonly IHttpClient _httpClient;

		public ComposableApi(IHttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		internal async Task<T> GetValueAsync(string uri)
		{
			string data = await _httpClient.GetStringAsync(uri);
			var options = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true,
			};
			var dto = JsonSerializer.Deserialize<T>(data, options);
			if (dto == null)
				throw new NullReferenceException($"Failed to deserialize response data {data}");
			return dto;
		}

		internal async Task<T> GetValueAsync(string routingValue, string uri)
		{
			if (_httpClient is RiotHttpClient client)
			{
				string data = await client.GetStringAsync(routingValue, uri);
				var options = new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
					DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
					WriteIndented = true,
				};
				var dto = JsonSerializer.Deserialize<T>(data, options);
				if (dto == null)
					throw new NullReferenceException($"Failed to deserialize response data {data}");
				return dto;
			}
			else
			{
				throw new InvalidOperationException("Method can only operate if http client is a Riot http client");
			}
		}
	}
}
