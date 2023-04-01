﻿using BlossomiShymae.Gwen.Core;
using BlossomiShymae.Gwen.Dto.Riot.LolChallenges;
using BlossomiShymae.Gwen.Http;
using BlossomiShymae.Gwen.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.Gwen.Api.Riot
{
    public interface ILolChallengesApi
    {
        /// <summary>
        /// Get challenge configuration information by ID.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ChallengeConfigInfoDto> GetConfigInfoByIdAsync(PlatformRoute platformRoute, long id);
        /// <summary>
        /// Get a dictionary of challenge percentiles for players who have achieved it.
        /// </summary>
        /// <returns></returns>
        Task<ImmutableDictionary<string, ImmutableDictionary<string, double>>> GetPercentilesAsync(PlatformRoute platformRoute);
        /// <summary>
        /// Get challenge percentiles from ID for players who have achieved it.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ImmutableDictionary<string, double>> GetPercentilesByIdAsync(PlatformRoute platformRoute, long id);
        /// <summary>
        /// Get progressed challenge information details for encrypted PUUID.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<PlayerInfoDto> GetPlayerInfoByPuuidAsync(PlatformRoute platformRoute, string puuid);
        /// <summary>
        /// Get the apex players for challenge level.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="level"></param>
        /// <param name="id"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<ImmutableList<ApexPlayerInfoDto>> ListApexPlayerInfosAsync(PlatformRoute platformRoute, ChallengeLevel level, long id, int limit = 0);
        /// <summary>
        /// List all basic challenge configuration information.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <returns></returns>
        Task<ImmutableList<ChallengeConfigInfoDto>> ListConfigInfosAsync(PlatformRoute platformRoute);
    }

    internal class LolChallengesApi : ILolChallengesApi
    {
        private static readonly string s_uri = "/lol/challenges/v1/challenges";
        private static readonly string s_challengesConfigUri = s_uri + "/config";
        private static readonly string s_challengesPercentilesUri = s_uri + "/percentiles";
        private static readonly string s_challengesConfigForChallengeIdUri = s_uri + "/{0}/config";
        private static readonly string s_challengesTopPlayersByChallengeIdAndLevelUri = s_uri + "/{0}/leaderboards/by-level/{1}";
        private static readonly string s_challengesPercentilesForChallengeIdUri = s_uri + "/{0}/percentiles";
        private static readonly string s_challengesProgressedUri = "/lol/challenges/v1/player-data/{0}";
        private readonly ComposableApi<List<ChallengeConfigInfoDto>> _challengeConfigInfoDtosApi;
        private readonly ComposableApi<Dictionary<string, Dictionary<string, double>>> _challengePercentilesApi;
        private readonly ComposableApi<ChallengeConfigInfoDto> _challengeConfigInfoDtoApi;
        private readonly ComposableApi<List<ApexPlayerInfoDto>> _apexPlayerInfoDtosApi;
        private readonly ComposableApi<Dictionary<string, double>> _challengeThresholdsApi;
        private readonly ComposableApi<PlayerInfoDto> _playerInfoDtoApi;

        public LolChallengesApi(RiotHttpClient riotGamesClient)
        {
            _challengeConfigInfoDtosApi = new(riotGamesClient);
            _challengePercentilesApi = new(riotGamesClient);
            _challengeConfigInfoDtoApi = new(riotGamesClient);
            _apexPlayerInfoDtosApi = new(riotGamesClient);
            _challengeThresholdsApi = new(riotGamesClient);
            _playerInfoDtoApi = new(riotGamesClient);
        }

        public async Task<ImmutableList<ChallengeConfigInfoDto>> ListConfigInfosAsync(PlatformRoute platformRoute)
        {
            List<ChallengeConfigInfoDto> dtoCollection = await _challengeConfigInfoDtosApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), s_challengesConfigUri);
            return dtoCollection.ToImmutableList();
        }

        public async Task<ImmutableDictionary<string, ImmutableDictionary<string, double>>> GetPercentilesAsync(PlatformRoute platformRoute)
        {
            var percentiles = await _challengePercentilesApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), s_challengesPercentilesUri); ;
            return percentiles.ToImmutableDictionary(k => k.Key, v => v.Value.ToImmutableDictionary());
        }

        public async Task<ChallengeConfigInfoDto> GetConfigInfoByIdAsync(PlatformRoute platformRoute, long id)
            => await _challengeConfigInfoDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(s_challengesConfigForChallengeIdUri, id));

        public async Task<ImmutableList<ApexPlayerInfoDto>> ListApexPlayerInfosAsync(PlatformRoute platformRoute, ChallengeLevel level, long id, int limit = 0)
        {
            List<ApexPlayerInfoDto> dtoCollection = await _apexPlayerInfoDtosApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(s_challengesTopPlayersByChallengeIdAndLevelUri, id, level.ToString().ToUpper()) + (limit == 0 ? string.Empty : $"?limit={limit}"));
            return dtoCollection.ToImmutableList();
        }

        public async Task<ImmutableDictionary<string, double>> GetPercentilesByIdAsync(PlatformRoute platformRoute, long id)
        {
            Dictionary<string, double> percentiles = await _challengeThresholdsApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(s_challengesPercentilesForChallengeIdUri, id)); ;
            return percentiles.ToImmutableDictionary();
        }

        public async Task<PlayerInfoDto> GetPlayerInfoByPuuidAsync(PlatformRoute platformRoute, string puuid)
            => await _playerInfoDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(s_challengesProgressedUri, puuid));
    }
}
