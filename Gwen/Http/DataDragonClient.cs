namespace Gwen.Http
{
    public static class DataDragonClient
    {
        public static GetAsyncFunc
            GetAsync(HttpClient client) =>
            async (uri) => await client.GetAsync($"https://ddragon.leagueoflegends.com{uri}");

        public delegate Task<HttpResponseMessage> GetAsyncFunc(string uri);
    }
}
