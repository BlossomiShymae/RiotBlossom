using Gwen.Dto.Summoner;
using Gwen.Http;

namespace Gwen.Api.Riot
{
    public interface ISummonerApi
    {
        /// <summary>
        /// Get a summoner by encrypted account ID.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByAccountIdAsync(string accountId);

        /// <summary>
        /// Get a summoner by encrypted ID.
        /// </summary>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByIdAsync(string summonerId);

        /// <summary>
        /// Get a summoner by summoner name.
        /// </summary>
        /// <param name="summonerName"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByNameAsync(string summonerName);

        /// <summary>
        /// Get a summoner by encrypted PUUID.
        /// </summary>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<SummonerDto> GetByPuuidAsync(string puuid);
    }

    internal class SummonerApi : ISummonerApi
    {
        private static readonly string _uri = "/lol/summoner/v4/summoners";
        private static readonly string _summonerByRSOPuuidUri = "/fufillment/v1/summoners/by-puuid/{0}";
        private static readonly string _summonerByAccountIdUri = _uri + "/by-account/{0}";
        private static readonly string _summonerBySummonerNameUri = _uri + "/by-name/{0}";
        private static readonly string _summonerByPuuidUri = _uri + "/by-puuid/{0}";
        private static readonly string _summonerByAccessTokenUri = _uri + "/me";
        private static readonly string _summonerBySummonerIdUri = _uri + "/{0}";
        private readonly ComposableApi<SummonerDto> _summonerDtoApi;

        public SummonerApi(RiotGamesClient riotGamesClient)
        {
            _summonerDtoApi = new(riotGamesClient);
        }

        /// <inheritdoc/>
        public async Task<SummonerDto> GetByAccountIdAsync(string accountId)
            => await _summonerDtoApi.GetValueAsync(string.Format(_summonerByAccountIdUri, accountId));

        /// <inheritdoc/>
        public async Task<SummonerDto> GetByNameAsync(string summonerName)
            => await _summonerDtoApi.GetValueAsync(string.Format(_summonerBySummonerNameUri, summonerName));

        /// <inheritdoc/>
        public async Task<SummonerDto> GetByPuuidAsync(string puuid)
            => await _summonerDtoApi.GetValueAsync(string.Format(_summonerByPuuidUri, puuid));

        /// <inheritdoc/>
        public async Task<SummonerDto> GetByIdAsync(string summonerId)
            => await _summonerDtoApi.GetValueAsync(string.Format(_summonerBySummonerIdUri, summonerId));
    }
}
