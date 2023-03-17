using Gwen.Dto.League;
using Gwen.Http;

namespace Gwen.Api.Riot
{
	public interface ILeagueApi
	{
		/// <summary>
		/// Get the challenger league for given queue type.
		/// </summary>
		/// <param name="queue"></param>
		/// <returns></returns>
		Task<LeagueListDto> GetChallengerLeagueByQueueAsync(string queue);
		/// <summary>
		/// Get the grandmaster league for given queue type.
		/// </summary>
		/// <param name="queue"></param>
		/// <returns></returns>
		Task<LeagueListDto> GetGrandmasterLeagueByQueueAsync(string queue);
		/// <summary>
		/// Get league with given ID (includes inactive entries).
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<LeagueListDto> GetLeagueByIdAsync(string id);
		/// <summary>
		/// Get the master league for given queue type.
		/// </summary>
		/// <param name="queue"></param>
		/// <returns></returns>
		Task<LeagueListDto> GetMasterLeagueByQueueAsync(string queue);
		/// <summary>
		/// List all league entries for given queue type, rank tier, and rank division.
		/// </summary>
		/// <param name="queue"></param>
		/// <param name="tier"></param>
		/// <param name="division"></param>
		/// <returns></returns>
		Task<IEnumerable<LeagueEntryDto>> ListLeagueEntriesAsync(string queue, string tier, string division);
		/// <summary>
		/// List league entries in all queues for encrypted summoner ID.
		/// </summary>
		/// <param name="summonerId"></param>
		/// <returns></returns>
		Task<IEnumerable<LeagueEntryDto>> ListLeagueEntriesBySummonerIdAsync(string summonerId);
	}

	internal class LeagueApi : ILeagueApi
	{
		private static readonly string _uri = "/lol/league/v4";
		private static readonly string _challengerLeagueByQueue = _uri + "/challengerleagues/by-queue/{0}";
		private static readonly string _leagueEntriesBySummonerId = _uri + "/entries/by-summoner/{0}";
		private static readonly string _leagueEntriesByQueueTierDivision = _uri + "/entries/{0}/{1}/{2}";
		private static readonly string _grandmasterLeagueByQueue = _uri + "/grandmasterleagues/by-queue/{0}";
		private static readonly string _leagueByLeagueId = _uri + "/leagues/{0}";
		private static readonly string _masterLeagueByQueue = _uri + "/masterleagues/by-queue/{0}";
		private readonly ComposableApi<LeagueListDto> _leagueListDtoApi;
		private readonly ComposableApi<IEnumerable<LeagueEntryDto>> _leagueEntryDtosApi;

		public LeagueApi(RiotGamesClient riotGamesClient)
		{
			_leagueListDtoApi = new(riotGamesClient);
			_leagueEntryDtosApi = new(riotGamesClient);
		}

		public async Task<LeagueListDto> GetChallengerLeagueByQueueAsync(string queue)
			=> await _leagueListDtoApi.GetValueAsync(string.Format(_challengerLeagueByQueue, queue));

		public async Task<IEnumerable<LeagueEntryDto>> ListLeagueEntriesBySummonerIdAsync(string summonerId)
			=> await _leagueEntryDtosApi.GetValueAsync(string.Format(_leagueEntriesBySummonerId, summonerId));

		public async Task<IEnumerable<LeagueEntryDto>> ListLeagueEntriesAsync(string queue, string tier, string division)
			=> await _leagueEntryDtosApi.GetValueAsync(string.Format(_leagueEntriesByQueueTierDivision, queue, tier, division));

		public async Task<LeagueListDto> GetGrandmasterLeagueByQueueAsync(string queue)
			=> await _leagueListDtoApi.GetValueAsync(string.Format(_grandmasterLeagueByQueue, queue));

		public async Task<LeagueListDto> GetLeagueByIdAsync(string id)
			=> await _leagueListDtoApi.GetValueAsync(string.Format(_leagueByLeagueId, id));

		public async Task<LeagueListDto> GetMasterLeagueByQueueAsync(string queue)
			=> await _leagueListDtoApi.GetValueAsync(string.Format(_masterLeagueByQueue, queue));
	}
}
