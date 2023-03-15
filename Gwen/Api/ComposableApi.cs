using Gwen.Http;
using System.Text.Json;

namespace Gwen.Api
{
	internal class ComposableApi<T>
	{
		private readonly RiotGamesClient _riotGamesClient;

		public ComposableApi(RiotGamesClient riotGamesClient)
		{
			_riotGamesClient = riotGamesClient;
		}

		internal async Task<T> GetDtoAsync(string uri) => await GetDtoAsync(uri, string.Empty);

		internal async Task<T> GetDtoAsync(string uri, string query)
		{
			string data = await _riotGamesClient.GetStringAsync(uri, query);
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
	}
}
