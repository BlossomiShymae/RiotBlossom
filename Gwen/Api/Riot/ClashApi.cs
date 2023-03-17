using Gwen.Dto.Clash;
using Gwen.Http;

namespace Gwen.Api.Riot
{
	public interface IClashApi
	{
		/// <summary>
		/// Get a clash team by ID.
		/// </summary>
		/// <param name="teamId"></param>
		/// <returns></returns>
		Task<TeamDto> GetTeamByIdAsync(string teamId);
		/// <summary>
		/// Get a clash tournament by ID.
		/// </summary>
		/// <param name="tournamentId"></param>
		/// <returns></returns>
		Task<TournamentDto> GetTournamentByIdAsync(string tournamentId);
		/// <summary>
		/// Get a clash tournament by team ID.
		/// </summary>
		/// <param name="teamId"></param>
		/// <returns></returns>
		Task<TournamentDto> GetTournamentByTeamIdAsync(string teamId);
		/// <summary>
		/// List all active or upcoming clash tournaments.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<TournamentDto>> ListActiveTournamentsAsync();
		/// <summary>
		/// List active Clash players for encrypted summoner ID. If a summoner registers for multiple tournaments
		/// at once, then both registrations will appear.
		/// </summary>
		/// <param name="summonerId"></param>
		/// <returns></returns>
		Task<IEnumerable<PlayerDto>> ListPlayersBySummonerIdAsync(string summonerId);
	}

	internal class ClashApi : IClashApi
	{
		private static readonly string _uri = "/lol/clash/v1";
		private static readonly string _playersBySummonerIdUri = _uri + "/players/by-summoner/{0}";
		private static readonly string _teamByTeamIdUri = _uri + "/teams/{0}";
		private static readonly string _tournamentsUri = _uri + "/tournaments";
		private static readonly string _tournamentByTeamIdUri = _tournamentsUri + "/by-team/{0}";
		private static readonly string _tournamentById = _tournamentsUri + "/{0}";
		private readonly ComposableApi<IEnumerable<PlayerDto>> _playerDtosApi;
		private readonly ComposableApi<TeamDto> _teamDtoApi;
		private readonly ComposableApi<IEnumerable<TournamentDto>> _tournamentDtosApi;
		private readonly ComposableApi<TournamentDto> _tournamentDtoApi;

		public ClashApi(RiotHttpClient riotGamesClient)
		{
			_playerDtosApi = new(riotGamesClient);
			_teamDtoApi = new(riotGamesClient);
			_tournamentDtosApi = new(riotGamesClient);
			_tournamentDtoApi = new(riotGamesClient);
		}

		public async Task<IEnumerable<PlayerDto>> ListPlayersBySummonerIdAsync(string summonerId)
			=> await _playerDtosApi.GetValueAsync(string.Format(_playersBySummonerIdUri, summonerId));

		public async Task<TeamDto> GetTeamByIdAsync(string teamId)
			=> await _teamDtoApi.GetValueAsync(string.Format(_teamByTeamIdUri, teamId));

		public async Task<IEnumerable<TournamentDto>> ListActiveTournamentsAsync()
			=> await _tournamentDtosApi.GetValueAsync(_tournamentsUri);

		public async Task<TournamentDto> GetTournamentByTeamIdAsync(string teamId)
			=> await _tournamentDtoApi.GetValueAsync(string.Format(_tournamentByTeamIdUri, teamId));

		public async Task<TournamentDto> GetTournamentByIdAsync(string tournamentId)
			=> await _tournamentDtoApi.GetValueAsync(string.Format(_tournamentById, tournamentId));
	}
}
