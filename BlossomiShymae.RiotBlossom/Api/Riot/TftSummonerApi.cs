using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface ITftSummonerApi
    {
        /// <summary>
        /// Get a summoner by account ID.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByAccountIdAsync(Platform platform, string accountId);
        /// <summary>
        /// Get a summoner by encrypted ID.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByIdAsync(Platform platform, string summonerId);
        /// <summary>
        /// Get a summoner by summoner name.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="summonerName"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByNameAsync(Platform platform, string summonerName);
        /// <summary>
        /// Get a summoner by encrypted PUUID.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByPuuidAsync(Platform platform, string puuid);
    }

    internal class TftSummonerApi : ITftSummonerApi
    {
        private static readonly string s_uri = "/tft/summoner/v1/summoners";
        private static readonly string s_summonerByAccountIdUri = s_uri + "/by-account/{0}";
        private static readonly string s_summonerBySummonerNameUri = s_uri + "/by-name/{0}";
        private static readonly string s_summonerByPuuidUri = s_uri + "/by-puuid/{0}";
        private static readonly string s_summonerBySummonerIdUri = s_uri + "/{0}";
        private readonly ComposableApi<SummonerDto> _summonerDtoApi;

        public TftSummonerApi(RiotHttpClient riotHttpClient)
        {
            _summonerDtoApi = new(riotHttpClient);
        }

        public async Task<SummonerDto> GetByAccountIdAsync(Platform platform, string accountId)
            => await _summonerDtoApi.GetValueAsync(PlatformMapper.GetId(platform), string.Format(s_summonerByAccountIdUri, accountId));

        public async Task<SummonerDto> GetByIdAsync(Platform platform, string summonerId)
            => await _summonerDtoApi.GetValueAsync(PlatformMapper.GetId(platform), string.Format(s_summonerBySummonerIdUri, summonerId));

        public async Task<SummonerDto> GetByNameAsync(Platform platform, string summonerName)
            => await _summonerDtoApi.GetValueAsync(PlatformMapper.GetId(platform), string.Format(s_summonerBySummonerNameUri, summonerName));

        public async Task<SummonerDto> GetByPuuidAsync(Platform platform, string puuid)
            => await _summonerDtoApi.GetValueAsync(PlatformMapper.GetId(platform), string.Format(s_summonerByPuuidUri, puuid));
    }
}
