using System.Collections.Immutable;
using BlossomiShymae.Gwen.Core;
using BlossomiShymae.Gwen.Dto.Riot.League;
using BlossomiShymae.Gwen.Http;
using BlossomiShymae.Gwen.Type;

namespace BlossomiShymae.Gwen.Api.Riot
{
    public interface ILeagueApi
    {
        /// <summary>
        /// Get the challenger league for given queue type.
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetChallengerLeagueByQueueAsync(PlatformRoute platformRoute, LeagueQueue queue);
        /// <summary>
        /// Get the grandmaster league for given queue type.
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetGrandmasterLeagueByQueueAsync(PlatformRoute platformRoute, LeagueQueue queue);
        /// <summary>
        /// Get league with given ID (includes inactive entries).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetLeagueByIdAsync(PlatformRoute platformRoute, string id);
        /// <summary>
        /// Get the master league for given queue type.
        /// </summary>
        /// <param name="queue"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetMasterLeagueByQueueAsync(PlatformRoute platformRoute, LeagueQueue queue);
        /// <summary>
        /// List all league entries for given queue type, rank tier, and rank division.
        /// </summary>
        /// <param name="queue"></param>
        /// <param name="tier"></param>
        /// <param name="division"></param>
        /// <returns></returns>
        Task<ImmutableList<LeagueEntryDto>> ListLeagueEntriesAsync(PlatformRoute platformRoute, LeagueQueue queue, LeagueTier tier, LeagueDivision division);
        /// <summary>
        /// List league entries in all queues for encrypted summoner ID.
        /// </summary>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<ImmutableList<LeagueEntryDto>> ListLeagueEntriesBySummonerIdAsync(PlatformRoute platformRoute, string summonerId);
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
        private readonly ComposableApi<List<LeagueEntryDto>> _leagueEntryDtosApi;

        public LeagueApi(RiotHttpClient riotGamesClient)
        {
            _leagueListDtoApi = new(riotGamesClient);
            _leagueEntryDtosApi = new(riotGamesClient);
        }

        public async Task<LeagueListDto> GetChallengerLeagueByQueueAsync(PlatformRoute platformRoute, LeagueQueue queue)
            => await _leagueListDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(_challengerLeagueByQueue, LeagueQueueMapper.GetValue(queue)));

        public async Task<ImmutableList<LeagueEntryDto>> ListLeagueEntriesBySummonerIdAsync(PlatformRoute platformRoute, string summonerId)
        {
            List<LeagueEntryDto> dtoCollection = await _leagueEntryDtosApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(_leagueEntriesBySummonerId, summonerId));
            return dtoCollection.ToImmutableList();
        }

        public async Task<ImmutableList<LeagueEntryDto>> ListLeagueEntriesAsync(PlatformRoute platformRoute, LeagueQueue queue, LeagueTier tier, LeagueDivision division)
        {
            List<LeagueEntryDto> dtoCollection = await _leagueEntryDtosApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(_leagueEntriesByQueueTierDivision, LeagueQueueMapper.GetValue(queue), LeagueTierMapper.GetValue(tier), LeagueDivisionMapper.GetValue(division)));
            return dtoCollection.ToImmutableList();
        }

        public async Task<LeagueListDto> GetGrandmasterLeagueByQueueAsync(PlatformRoute platformRoute, LeagueQueue queue)
            => await _leagueListDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(_grandmasterLeagueByQueue, LeagueQueueMapper.GetValue(queue)));

        public async Task<LeagueListDto> GetLeagueByIdAsync(PlatformRoute platformRoute, string id)
            => await _leagueListDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(_leagueByLeagueId, id));

        public async Task<LeagueListDto> GetMasterLeagueByQueueAsync(PlatformRoute platformRoute, LeagueQueue queue)
            => await _leagueListDtoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(_masterLeagueByQueue, LeagueQueueMapper.GetValue(queue)));
    }
}
