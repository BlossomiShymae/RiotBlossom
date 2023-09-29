using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.LolStatus;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface ILorStatusApi
    {
        /// <summary>
        /// Get Legends of Runeterra status for the current region.
        /// </summary>
        /// <param name="regionRoute"></param>
        /// <returns></returns>
        Task<PlatformDataDto> GetPlatformStatusAsync(LorRegion regionRoute);
    }

    internal class LorStatusApi : ILorStatusApi
    {
        private static readonly string s_statusUri = "/lor/status/v1/platform-data";
        private readonly ComposableApi<PlatformDataDto> _platformDataDtoApi;

        public LorStatusApi(RiotHttpClient riotHttpClient)
        {
            _platformDataDtoApi = new(riotHttpClient);
        }

        public async Task<PlatformDataDto> GetPlatformStatusAsync(LorRegion regionRoute)
            => await _platformDataDtoApi.GetValueAsync(LorRegionMapper.GetId(regionRoute), s_statusUri);
    }
}
