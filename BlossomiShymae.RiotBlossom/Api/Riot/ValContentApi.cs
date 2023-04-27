using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.ValContent;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface IValContentApi
    {
        /// <summary>
        /// Get VALORANT content.
        /// </summary>
        /// <param name="valRegion"></param>
        /// <returns></returns>
        Task<ContentDto> GetContentAsync(ValRegion valRegion);
        /// <summary>
        /// Get VALORANT content filtered by locale.
        /// </summary>
        /// <param name="valRegion"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        Task<ContentDto> GetContentByLocaleAsync(ValRegion valRegion, string locale);
    }

    internal class ValContentApi : IValContentApi
    {
        private static readonly string s_uri = "/val/content/v1/contents";
        private readonly ComposableApi<ContentDto> _contentDtoApi;

        public ValContentApi(RiotHttpClient riotHttpClient)
        {
            _contentDtoApi = new(riotHttpClient);
        }

        public async Task<ContentDto> GetContentAsync(ValRegion valRegion)
            => await _contentDtoApi.GetValueAsync(ValRegionMapper.GetId(valRegion), s_uri);

        public async Task<ContentDto> GetContentByLocaleAsync(ValRegion valRegion, string locale)
            => await _contentDtoApi.GetValueAsync(ValRegionMapper.GetId(valRegion), $"{s_uri}?locale={locale}");
    }
}
