﻿using Gwen.Dto.Summoner;
using Gwen.Http;

namespace Gwen.Api
{
    internal class SummonerApi
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

        /// <summary>
        /// Get a summoner by encrypted account ID.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public async Task<SummonerDto> GetByAccountIdAsync(string accountId)
            => await _summonerDtoApi.GetDtoAsync(string.Format(_summonerByAccountIdUri, accountId));

        /// <summary>
        /// Get a summoner by summoner name.
        /// </summary>
        /// <param name="summonerName"></param>
        /// <returns></returns>
        public async Task<SummonerDto> GetByNameAsync(string summonerName)
            => await _summonerDtoApi.GetDtoAsync(string.Format(_summonerBySummonerNameUri, summonerName));

        /// <summary>
        /// Get a summoner by encrypted PUUID.
        /// </summary>
        /// <param name="puuid"></param>
        /// <returns></returns>
        public async Task<SummonerDto> GetByPuuidAsync(string puuid)
            => await _summonerDtoApi.GetDtoAsync(string.Format(_summonerByPuuidUri, puuid));

        /// <summary>
        /// Get a summoner by encrypted ID.
        /// </summary>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        public async Task<SummonerDto> GetByIdAsync(string summonerId)
            => await _summonerDtoApi.GetDtoAsync(string.Format(_summonerBySummonerIdUri, summonerId));
    }
}
