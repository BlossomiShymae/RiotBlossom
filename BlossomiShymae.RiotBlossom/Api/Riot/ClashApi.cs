﻿using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Clash;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface IClashApi
    {
        /// <summary>
        /// Get a clash team by ID.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="teamId"></param>
        /// <returns></returns>
        Task<TeamDto> GetTeamByIdAsync(Platform platformRoute, string teamId);
        /// <summary>
        /// Get a clash tournament by ID.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="tournamentId"></param>
        /// <returns></returns>
        Task<TournamentDto> GetTournamentByIdAsync(Platform platformRoute, string tournamentId);
        /// <summary>
        /// Get a clash tournament by team ID.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="teamId"></param>
        /// <returns></returns>
        Task<TournamentDto> GetTournamentByTeamIdAsync(Platform platformRoute, string teamId);
        /// <summary>
        /// List all active or upcoming clash tournaments.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <returns></returns>
        Task<ImmutableList<TournamentDto>> ListActiveTournamentsAsync(Platform platformRoute);
        /// <summary>
        /// List active Clash players for encrypted summoner ID. If a summoner registers for multiple tournaments
        /// at once, then both registrations will appear.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<ImmutableList<PlayerDto>> ListPlayersBySummonerIdAsync(Platform platformRoute, string summonerId);
    }

    internal class ClashApi : IClashApi
    {
        private static readonly string s_uri = "/lol/clash/v1";
        private static readonly string s_playersBySummonerIdUri = s_uri + "/players/by-summoner/{0}";
        private static readonly string s_teamByTeamIdUri = s_uri + "/teams/{0}";
        private static readonly string s_tournamentsUri = s_uri + "/tournaments";
        private static readonly string s_tournamentByTeamIdUri = s_tournamentsUri + "/by-team/{0}";
        private static readonly string s_tournamentById = s_tournamentsUri + "/{0}";
        private readonly ComposableApi<List<PlayerDto>> _playerDtosApi;
        private readonly ComposableApi<TeamDto> _teamDtoApi;
        private readonly ComposableApi<List<TournamentDto>> _tournamentDtosApi;
        private readonly ComposableApi<TournamentDto> _tournamentDtoApi;

        public ClashApi(RiotHttpClient riotGamesClient)
        {
            _playerDtosApi = new(riotGamesClient);
            _teamDtoApi = new(riotGamesClient);
            _tournamentDtosApi = new(riotGamesClient);
            _tournamentDtoApi = new(riotGamesClient);
        }

        public async Task<ImmutableList<PlayerDto>> ListPlayersBySummonerIdAsync(Platform platformRoute, string summonerId)
        {
            List<PlayerDto> dtoCollection = await _playerDtosApi.GetValueAsync(PlatformMapper.GetId(platformRoute), string.Format(s_playersBySummonerIdUri, summonerId));
            return dtoCollection.ToImmutableList();
        }

        public async Task<TeamDto> GetTeamByIdAsync(Platform platformRoute, string teamId)
            => await _teamDtoApi.GetValueAsync(PlatformMapper.GetId(platformRoute), string.Format(s_teamByTeamIdUri, teamId));

        public async Task<ImmutableList<TournamentDto>> ListActiveTournamentsAsync(Platform platformRoute)
        {
            List<TournamentDto> dtoCollection = await _tournamentDtosApi.GetValueAsync(PlatformMapper.GetId(platformRoute), s_tournamentsUri);
            return dtoCollection.ToImmutableList();
        }

        public async Task<TournamentDto> GetTournamentByTeamIdAsync(Platform platformRoute, string teamId)
            => await _tournamentDtoApi.GetValueAsync(PlatformMapper.GetId(platformRoute), string.Format(s_tournamentByTeamIdUri, teamId));

        public async Task<TournamentDto> GetTournamentByIdAsync(Platform platformRoute, string tournamentId)
            => await _tournamentDtoApi.GetValueAsync(PlatformMapper.GetId(platformRoute), string.Format(s_tournamentById, tournamentId));
    }
}
