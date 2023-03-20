using Gwen.Dto.Riot.Clash;
using Gwen.Http;
using Gwen.Type;
using System.Collections.ObjectModel;

namespace Gwen.Api.Riot
{
	public interface IClashApi
	{
		/// <summary>
		/// Get a clash team by ID.
		/// </summary>
		/// <param name="teamId"></param>
		/// <returns></returns>
		Task<TeamDto> GetTeamByIdAsync(PlatformRoute platformRoute, string teamId);
		/// <summary>
		/// Get a clash tournament by ID.
		/// </summary>
		/// <param name="tournamentId"></param>
		/// <returns></returns>
		Task<TournamentDto> GetTournamentByIdAsync(PlatformRoute platformRoute, string tournamentId);
		/// <summary>
		/// Get a clash tournament by team ID.
		/// </summary>
		/// <param name="teamId"></param>
		/// <returns></returns>
		Task<TournamentDto> GetTournamentByTeamIdAsync(PlatformRoute platformRoute, string teamId);
		/// <summary>
		/// List all active or upcoming clash tournaments.
		/// </summary>
		/// <returns></returns>
		Task<ReadOnlyCollection<TournamentDto>> ListActiveTournamentsAsync(PlatformRoute platformRoute);
		/// <summary>
		/// List active Clash players for encrypted summoner ID. If a summoner registers for multiple tournaments
		/// at once, then both registrations will appear.
		/// </summary>
		/// <param name="summonerId"></param>
		/// <returns></returns>
		Task<ReadOnlyCollection<PlayerDto>> ListPlayersBySummonerIdAsync(PlatformRoute platformRoute, string summonerId);
	}

	internal class ClashApi : IClashApi
	{
		private static readonly string _uri = "/lol/clash/v1";
		private static readonly string _playersBySummonerIdUri = _uri + "/players/by-summoner/{0}";
		private static readonly string _teamByTeamIdUri = _uri + "/teams/{0}";
		private static readonly string _tournamentsUri = _uri + "/tournaments";
		private static readonly string _tournamentByTeamIdUri = _tournamentsUri + "/by-team/{0}";
		private static readonly string _tournamentById = _tournamentsUri + "/{0}";
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

		public async Task<ReadOnlyCollection<PlayerDto>> ListPlayersBySummonerIdAsync(PlatformRoute platformRoute, string summonerId)
		{
			List<PlayerDto> dtoCollection = await _playerDtosApi.GetValueAsync(string.Format(_playersBySummonerIdUri, summonerId));
			return dtoCollection.AsReadOnly();
		}

		public async Task<TeamDto> GetTeamByIdAsync(PlatformRoute platformRoute, string teamId)
			=> await _teamDtoApi.GetValueAsync(string.Format(_teamByTeamIdUri, teamId));

		public async Task<ReadOnlyCollection<TournamentDto>> ListActiveTournamentsAsync(PlatformRoute platformRoute)
		{
			List<TournamentDto> dtoCollection = await _tournamentDtosApi.GetValueAsync(_tournamentsUri);
			return dtoCollection.AsReadOnly();
		}

		public async Task<TournamentDto> GetTournamentByTeamIdAsync(PlatformRoute platformRoute, string teamId)
			=> await _tournamentDtoApi.GetValueAsync(string.Format(_tournamentByTeamIdUri, teamId));

		public async Task<TournamentDto> GetTournamentByIdAsync(PlatformRoute platformRoute, string tournamentId)
			=> await _tournamentDtoApi.GetValueAsync(string.Format(_tournamentById, tournamentId));
	}
}
