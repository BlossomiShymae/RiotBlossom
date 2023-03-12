using Gwen.Http;
using System.Text.Json;

namespace Gwen.Api
{
    public static class Api
    {
        public static GetDtoAsyncFunc<T> GetDtoAsync<T>(RiotGamesClient.GetAsyncFunc func)
            => async (string uri, string query)
            =>
            {
                string data = await func(uri, query);
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
            };

        public delegate Task<T> GetDtoAsyncFunc<T>(string uri, string query);
        public delegate T UseByRoutingValue<T>(string routingValue);
    }
}
