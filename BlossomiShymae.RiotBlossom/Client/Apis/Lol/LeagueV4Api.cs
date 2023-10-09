using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Constants.Types.Lol;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.League;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Lol
{
    public interface ILeagueV4Api
    {
        /// <summary>
        /// Get the challenger league for given queue type.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetChallengerLeagueByQueueAsync(LeagueShard shard, LeagueQueue queue);
        /// <summary>
        /// Get the grandmaster league for given queue type.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetGrandmasterLeagueByQueueAsync(LeagueShard shard, LeagueQueue queue);
        /// <summary>
        /// Get league with given ID (includes inactive entries).
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetLeagueByIdAsync(LeagueShard shard, string id);
        /// <summary>
        /// Get the master league for given queue type.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetMasterLeagueByQueueAsync(LeagueShard shard, LeagueQueue queue);
        /// <summary>
        /// List all league entries for given queue type, rank tier, and rank division.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="queue"></param>
        /// <param name="tier"></param>
        /// <param name="division"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<List<LeagueEntryDto>> GetLeagueEntriesAsync(LeagueShard shard, LeagueQueue queue, LeagueTier tier, LeagueDivision division, int page = 1);
        /// <summary>
        /// List league entries in all queues for encrypted summoner ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<List<LeagueEntryDto>> GetLeagueEntriesBySummonerIdAsync(LeagueShard shard, string summonerId);
    }

    internal class LeagueV4Api : DataApi, ILeagueV4Api
    {
        public LeagueV4Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<LeagueListDto> GetChallengerLeagueByQueueAsync(LeagueShard shard, LeagueQueue queue)
        {
            var data = await CallAsync<LeagueListDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(LeagueV4Api),
                Method = UrlMethod.LeagueV4ChallengerLeagues,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.QueueQuery, queue.Value }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<LeagueListDto> GetGrandmasterLeagueByQueueAsync(LeagueShard shard, LeagueQueue queue)
        {
            var data = await CallAsync<LeagueListDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(LeagueV4Api),
                Method = UrlMethod.LeagueV4GrandmasterLeagues,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Queue, queue.Value }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<LeagueListDto> GetLeagueByIdAsync(LeagueShard shard, string id)
        {
            var data = await CallAsync<LeagueListDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(LeagueV4Api),
                Method = UrlMethod.LeagueV4LeaguesById,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.LeagueId, id }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<LeagueEntryDto>> GetLeagueEntriesAsync(LeagueShard shard, LeagueQueue queue, LeagueTier tier, LeagueDivision division, int page = 1)
        {
            var data = await CallAsync<List<LeagueEntryDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(LeagueV4Api),
                Method = UrlMethod.LeagueV4EntriesByQueue,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Queue, queue.Value },
                    { UrlMethod.Tier, tier.Value },
                    { UrlMethod.Division, division.Value },
                    { UrlMethod.PageQuery, page.ToString() }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<LeagueEntryDto>> GetLeagueEntriesBySummonerIdAsync(LeagueShard shard, string summonerId)
        {
            var data = await CallAsync<List<LeagueEntryDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(LeagueV4Api),
                Method = UrlMethod.LeagueV4EntriesByEncryptedSummonerId,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedSummonerId, summonerId }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<LeagueListDto> GetMasterLeagueByQueueAsync(LeagueShard shard, LeagueQueue queue)
        {
            var data = await CallAsync<LeagueListDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(LeagueV4Api),
                Method = UrlMethod.LeagueV4MasterLeagues,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Queue, queue.Value }
                }
            }).ConfigureAwait(false);

            return data;
        }
    }
}
