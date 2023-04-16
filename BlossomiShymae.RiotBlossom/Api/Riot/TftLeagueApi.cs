using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.League;
using BlossomiShymae.RiotBlossom.Dto.Riot.TftLeague;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;
using LeagueEntryDto = BlossomiShymae.RiotBlossom.Dto.Riot.League.LeagueEntryDto;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface ITftLeagueApi
    {
        /// <summary>
        /// Get the challenger league.
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetChallengerLeagueAsync(Platform platform);
        /// <summary>
        /// Get the grandmaster league.
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetGrandmasterLeagueAsync(Platform platform);
        /// <summary>
        /// Get the master league.
        /// </summary>
        /// <param name="platform"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetMasterLeagueAsync(Platform platform);
        /// <summary>
        /// Get league with given ID.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetLeagueByIdAsync(Platform platform, string id);
        /// <summary>
        /// List all league entries for given tier and division.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="tier"></param>
        /// <param name="division"></param>
        /// <returns></returns>
        Task<ImmutableList<LeagueEntryDto>> ListLeagueEntriesAsync(Platform platform, LeagueTier tier, LeagueDivision division);
        /// <summary>
        /// List league entries for encrypted summoner ID.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<ImmutableList<LeagueEntryDto>> ListLeagueEntriesBySummonerIdAsync(Platform platform, string summonerId);
        /// <summary>
        /// Get the top rated ladder for given queue.
        /// </summary>
        /// <param name="platform"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        Task<ImmutableList<TopRatedLadderEntryDto>> ListTopRatedLadderByQueueAsync(Platform platform, string queue);
    }

    internal class TftLeagueApi : ITftLeagueApi
    {
        private static readonly string s_uri = "/tft/league/v1";
        private static readonly string s_challengeLeagueUri = s_uri + "/challenger";
        private static readonly string s_grandmasterLeagueUri = s_uri + "/grandmaster";
        private static readonly string s_masterLeagueUri = s_uri + "/master";
        private static readonly string s_leagueEntriesBySummonerIdUri = s_uri + "/entries/by-summoner/{0}";
        private static readonly string s_leagueEntriesByTierDivisionUri = s_uri + "/entries/{0}/{1}";
        private static readonly string s_leagueByLeagueIdUri = s_uri + "/leagues/{0}";
        private static readonly string s_topRatedLadderByQueueUri = s_uri + "/rated-ladders/{0}/top";
        private readonly ComposableApi<LeagueListDto> _leagueListDtoApi;
        private readonly ComposableApi<List<LeagueEntryDto>> _leagueEntryDtosApi;
        private readonly ComposableApi<List<TopRatedLadderEntryDto>> _topRatedLadderEntryDtosApi;

        public TftLeagueApi(RiotHttpClient riotHttpClient)
        {
            _leagueListDtoApi = new(riotHttpClient);
            _leagueEntryDtosApi = new(riotHttpClient);
            _topRatedLadderEntryDtosApi = new(riotHttpClient);
        }

        public async Task<LeagueListDto> GetChallengerLeagueAsync(Platform platform)
        {
            LeagueListDto leagueListDto = await _leagueListDtoApi.GetValueAsync(PlatformMapper.GetId(platform), s_challengeLeagueUri);
            return leagueListDto;
        }

        public async Task<LeagueListDto> GetGrandmasterLeagueAsync(Platform platform)
        {
            LeagueListDto leagueListDto = await _leagueListDtoApi.GetValueAsync(PlatformMapper.GetId(platform), s_grandmasterLeagueUri);
            return leagueListDto;
        }

        public async Task<LeagueListDto> GetLeagueByIdAsync(Platform platform, string id)
        {
            LeagueListDto leagueListDto = await _leagueListDtoApi.GetValueAsync(PlatformMapper.GetId(platform), string.Format(s_leagueByLeagueIdUri, id));
            return leagueListDto;
        }

        public async Task<LeagueListDto> GetMasterLeagueAsync(Platform platform)
        {
            LeagueListDto leagueListDto = await _leagueListDtoApi.GetValueAsync(PlatformMapper.GetId(platform), s_masterLeagueUri);
            return leagueListDto;
        }

        public async Task<ImmutableList<LeagueEntryDto>> ListLeagueEntriesAsync(Platform platform, LeagueTier tier, LeagueDivision division)
        {
            List<LeagueEntryDto> entries = await _leagueEntryDtosApi.GetValueAsync(PlatformMapper.GetId(platform), string.Format(s_leagueEntriesByTierDivisionUri, LeagueTierMapper.GetValue(tier), LeagueDivisionMapper.GetValue(division)));
            return entries.ToImmutableList();
        }

        public async Task<ImmutableList<LeagueEntryDto>> ListLeagueEntriesBySummonerIdAsync(Platform platform, string summonerId)
        {
            List<LeagueEntryDto> entries = await _leagueEntryDtosApi.GetValueAsync(PlatformMapper.GetId(platform), string.Format(s_leagueEntriesBySummonerIdUri, summonerId));
            return entries.ToImmutableList();
        }

        public async Task<ImmutableList<TopRatedLadderEntryDto>> ListTopRatedLadderByQueueAsync(Platform platform, string queue)
        {
            List<TopRatedLadderEntryDto> entries = await _topRatedLadderEntryDtosApi.GetValueAsync(PlatformMapper.GetId(platform), string.Format(s_topRatedLadderByQueueUri, queue));
            return entries.ToImmutableList();
        }
    }
}
