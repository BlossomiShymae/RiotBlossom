using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.LolStatus;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface ILolStatusApi
    {
        /// <summary>
        /// Get League of Legends status for the current platform.
        /// </summary>
        /// <returns></returns>
        Task<PlatformDataDto> GetPlatformStatusAsync(Platform platformRoute);
    }

    internal class LolStatusApi : ILolStatusApi
    {
        private static readonly string s_statusUri = "/lol/status/v4/platform-data";
        private readonly ComposableApi<PlatformDataDto> _platformDataDtoApi;

        public LolStatusApi(RiotHttpClient riotGamesClient)
        {
            _platformDataDtoApi = new(riotGamesClient);
        }

        public async Task<PlatformDataDto> GetPlatformStatusAsync(Platform platformRoute)
            => await _platformDataDtoApi.GetValueAsync(PlatformMapper.GetId(platformRoute), s_statusUri);
    }
}
