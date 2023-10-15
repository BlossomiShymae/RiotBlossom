using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Constants.Types.Lol;
using BlossomiShymae.RiotBlossom.Data.Constants.Types.Tft;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.League;
using BlossomiShymae.RiotBlossom.Data.Dtos.Tft.TftLeague;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Tft
{
    public interface ITftLeagueV1Api
    {
        /// <summary>
        /// Get the challenger league.
        /// </summary>
        /// <param name="shard"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetChallengerLeagueAsync(LeagueShard shard);
        /// <summary>
        /// Get the grandmaster league.
        /// </summary>
        /// <param name="shard"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetGrandmasterLeagueAsync(LeagueShard shard);
        /// <summary>
        /// Get the master league.
        /// </summary>
        /// <param name="shard"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetMasterLeagueAsync(LeagueShard shard);
        /// <summary>
        /// Get league with given ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LeagueListDto> GetByIdAsync(LeagueShard shard, string id);
        /// <summary>
        /// List all league entries for given tier and division.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="tier"></param>
        /// <param name="division"></param>
        /// <returns></returns>
        Task<List<Data.Dtos.Tft.TftLeague.LeagueEntryDto>> GetLeagueEntriesAsync(LeagueShard shard, LeagueTier tier, LeagueDivision division);
        /// <summary>
        /// List league entries for encrypted summoner ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<List<Data.Dtos.Tft.TftLeague.LeagueEntryDto>> GetLeagueEntriesBySummonerIdAsync(LeagueShard shard, string summonerId);
        /// <summary>
        /// Get the top rated ladder for given queue.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        Task<List<TopRatedLadderEntryDto>> GetTopRatedLadderByQueueAsync(LeagueShard shard, TftLeagueQueue queue);
    }

    internal class TftLeagueV1Api : DataApi, ITftLeagueV1Api
    {
        public TftLeagueV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<LeagueListDto> GetByIdAsync(LeagueShard shard, string id)
        {
            var data = await CallAsync<LeagueListDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftLeagueV1Api),
                Method = UrlMethod.TftLeagueV1ById,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.LeagueId, id }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<LeagueListDto> GetChallengerLeagueAsync(LeagueShard shard)
        {
            var data = await CallAsync<LeagueListDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftLeagueV1Api),
                Method = UrlMethod.TftLeagueV1Challenger,
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<LeagueListDto> GetGrandmasterLeagueAsync(LeagueShard shard)
        {
            var data = await CallAsync<LeagueListDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftLeagueV1Api),
                Method = UrlMethod.TftLeagueV1Grandmaster
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<Data.Dtos.Tft.TftLeague.LeagueEntryDto>> GetLeagueEntriesAsync(LeagueShard shard, LeagueTier tier, LeagueDivision division)
        {
            var data = await CallAsync<List<Data.Dtos.Tft.TftLeague.LeagueEntryDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftLeagueV1Api),
                Method = UrlMethod.TftLeagueV1EntriesByTier,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Tier, tier.Value },
                    { UrlMethod.Division, division.Value }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<Data.Dtos.Tft.TftLeague.LeagueEntryDto>> GetLeagueEntriesBySummonerIdAsync(LeagueShard shard, string summonerId)
        {
            var data = await CallAsync<List<Data.Dtos.Tft.TftLeague.LeagueEntryDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftLeagueV1Api),
                Method = UrlMethod.TftLeagueV1EntriesBySummonerId,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.SummonerId, summonerId }
                }
            }).ConfigureAwait(false);
            return data;
        }

        public async Task<LeagueListDto> GetMasterLeagueAsync(LeagueShard shard)
        {
            var data = await CallAsync<LeagueListDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftLeagueV1Api),
                Method = UrlMethod.TftLeagueV1Master,
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<TopRatedLadderEntryDto>> GetTopRatedLadderByQueueAsync(LeagueShard shard, TftLeagueQueue queue)
        {
            var data = await CallAsync<List<TopRatedLadderEntryDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftLeagueV1Api),
                Method = UrlMethod.TftLeagueV1LadderByQueue,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Queue, queue.Value }
                }
            }).ConfigureAwait(false);

            return data;
        }
    }
}
