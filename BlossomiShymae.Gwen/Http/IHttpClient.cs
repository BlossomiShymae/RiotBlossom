namespace BlossomiShymae.Gwen.Http
{
    internal interface IHttpClient
    {
        Task<string> GetStringAsync(string uri);
        Task<byte[]> GetByteArrayAsync(string uri);
    }
}
