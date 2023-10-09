using System.Reflection.Metadata;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValContent;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Val
{
    public interface IValContentV1Api
    {
        /// <summary>
        /// Get VALORANT content.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        Task<ContentDto> GetContentAsync(ValorantShard shard, string? locale = null);
    }

    internal class ValContentV1Api : DataApi, IValContentV1Api
    {
        public ValContentV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ContentDto> GetContentAsync(ValorantShard shard, string? locale = null)
        {
            var parameters = new Dictionary<string, string>();

            if (locale != null)
            {
                parameters.Add(UrlMethod.LocaleQuery, locale);
            }

            var data = await CallAsync<ContentDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(ValContentV1Api),
                Method = UrlMethod.ValContentV1Contents,
                Params = parameters
            }).ConfigureAwait(false);

            return data;
        }
    }
}
