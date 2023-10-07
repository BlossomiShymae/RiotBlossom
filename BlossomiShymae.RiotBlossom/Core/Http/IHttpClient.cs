namespace BlossomiShymae.RiotBlossom.Http
{
    internal interface IHttpClient
    {
        Task<string> GetStringAsync(string uri, string routingValue);
        Task<byte[]> GetByteArrayAsync(string uri);
    }
}
