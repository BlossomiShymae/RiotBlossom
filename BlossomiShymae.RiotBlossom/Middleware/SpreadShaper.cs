namespace BlossomiShymae.RiotBlossom.Middleware
{
    internal class SpreadShaper : IShaper
    {
        public Task UseRequestAsync(ExecuteInfo info, HttpRequestMessage req, Action next, Action<byte[]> hit)
        {
            throw new NotImplementedException();
        }

        public Task UseResponseAsync(ExecuteInfo info, HttpResponseMessage res, Action next)
        {
            throw new NotImplementedException();
        }
    }
}
