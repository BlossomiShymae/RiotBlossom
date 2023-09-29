using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.LolStatus;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface IValStatusApi
    {
        /// <summary>
        /// Get VALORANT status for the given platform.
        /// </summary>
        /// <param name="valRegion"></param>
        /// <returns></returns>
        Task<PlatformDataDto> GetPlatformStatusAsync(ValRegion valRegion);
    }

    internal class ValStatusApi : IValStatusApi
    {
        private static readonly string s_uri = "/val/status/v1/platform-data";
        private readonly ComposableApi<PlatformDataDto> _platformDataDtoApi;

        public ValStatusApi(RiotHttpClient riotHttpClient)
        {
            _platformDataDtoApi = new(riotHttpClient);
        }

        public async Task<PlatformDataDto> GetPlatformStatusAsync(ValRegion valRegion)
            => await _platformDataDtoApi.GetValueAsync(ValRegionMapper.GetId(valRegion), s_uri);
    }
}
