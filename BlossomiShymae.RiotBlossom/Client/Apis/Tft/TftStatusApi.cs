using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.LolStatus;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface ITftStatusApi
    {
        /// <summary>
        /// Get Teamfight Tactics status for the given platform.
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        Task<PlatformDataDto> GetPlatformStatusAsync(Platform platform);
    }

    internal class TftStatusApi : ITftStatusApi
    {
        private static readonly string s_uri = "/tft/status/v1/platform-data";
        private readonly ComposableApi<PlatformDataDto> _platformDataDtoApi;

        public TftStatusApi(RiotHttpClient riotHttpClient)
        {
            _platformDataDtoApi = new(riotHttpClient);
        }

        public async Task<PlatformDataDto> GetPlatformStatusAsync(Platform platform)
        {
            PlatformDataDto data = await _platformDataDtoApi.GetValueAsync(PlatformMapper.GetId(platform), s_uri);
            return data;
        }
    }
}
