using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface ISummonerApi
    {
        /// <summary>
        /// Get a summoner by encrypted account ID.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByAccountIdAsync(PlatformRoute platformRoute, string accountId);

        /// <summary>
        /// Get a summoner by encrypted ID.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByIdAsync(PlatformRoute platformRoute, string summonerId);

        /// <summary>
        /// Get a summoner by summoner name.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="summonerName"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByNameAsync(PlatformRoute platformRoute, string summonerName);

        /// <summary>
        /// Get a summoner by encrypted PUUID.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByPuuidAsync(PlatformRoute platformRoute, string puuid);
    }

    internal class SummonerApi : ISummonerApi
    {
        private static readonly string s_uri = "/lol/summoner/v4/summoners";
        private static readonly string s_summonerByAccountIdUri = s_uri + "/by-account/{0}";
        private static readonly string s_summonerBySummonerNameUri = s_uri + "/by-name/{0}";
        private static readonly string s_summonerByPuuidUri = s_uri + "/by-puuid/{0}";
        private static readonly string s_summonerBySummonerIdUri = s_uri + "/{0}";
        private readonly ComposableApi<SummonerDto> _summonerDtoApi;

        public SummonerApi(RiotHttpClient riotGamesClient)
        {
            _summonerDtoApi = new(riotGamesClient);
        }

        public async Task<SummonerDto> GetByAccountIdAsync(PlatformRoute platformRoute, string accountId)
            => await _summonerDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(s_summonerByAccountIdUri, accountId));

        public async Task<SummonerDto> GetByNameAsync(PlatformRoute platformRoute, string summonerName)
            => await _summonerDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(s_summonerBySummonerNameUri, summonerName));

        public async Task<SummonerDto> GetByPuuidAsync(PlatformRoute platformRoute, string puuid)
            => await _summonerDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(s_summonerByPuuidUri, puuid));

        public async Task<SummonerDto> GetByIdAsync(PlatformRoute platformRoute, string summonerId)
            => await _summonerDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(s_summonerBySummonerIdUri, summonerId));
    }
}
