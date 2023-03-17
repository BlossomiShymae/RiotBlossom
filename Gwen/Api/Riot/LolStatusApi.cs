using Gwen.Dto.Riot.LolStatus;
using Gwen.Http;

namespace Gwen.Api.Riot
{
    public interface ILolStatusApi
    {
        /// <summary>
        /// Get League of Legends status for the current platform.
        /// </summary>
        /// <returns></returns>
        Task<PlatformDataDto> GetPlatformStatus();
    }

    internal class LolStatusApi : ILolStatusApi
    {
        private static readonly string _statusUri = "/lol/status/v4/platform-data";
        private readonly ComposableApi<PlatformDataDto> _platformDataDtoApi;

        public LolStatusApi(RiotHttpClient riotGamesClient)
        {
            _platformDataDtoApi = new(riotGamesClient);
        }

        public async Task<PlatformDataDto> GetPlatformStatus()
            => await _platformDataDtoApi.GetValueAsync(_statusUri);
    }
}
