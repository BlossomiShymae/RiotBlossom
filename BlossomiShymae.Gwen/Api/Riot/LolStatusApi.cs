using BlossomiShymae.Gwen.Core;
using BlossomiShymae.Gwen.Dto.Riot.LolStatus;
using BlossomiShymae.Gwen.Http;
using BlossomiShymae.Gwen.Type;

namespace BlossomiShymae.Gwen.Api.Riot
{
    public interface ILolStatusApi
    {
        /// <summary>
        /// Get League of Legends status for the current platform.
        /// </summary>
        /// <returns></returns>
        Task<PlatformDataDto> GetPlatformStatusAsync(PlatformRoute platformRoute);
    }

    internal class LolStatusApi : ILolStatusApi
    {
        private static readonly string _statusUri = "/lol/status/v4/platform-data";
        private readonly ComposableApi<PlatformDataDto> _platformDataDtoApi;

        public LolStatusApi(RiotHttpClient riotGamesClient)
        {
            _platformDataDtoApi = new(riotGamesClient);
        }

        public async Task<PlatformDataDto> GetPlatformStatusAsync(PlatformRoute platformRoute)
            => await _platformDataDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), _statusUri);
    }
}
