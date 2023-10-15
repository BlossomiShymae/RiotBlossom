using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.ChampionMastery;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Lol
{
    public interface IChampionMasteryV4Api
    {
        /// <summary>
        /// Get champion mastery entry by summoner ID and champion ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="summonerId"></param>
        /// <param name="championId"></param>
        /// <returns></returns>
        Task<ChampionMasteryDto> GetBySummonerIdAsync(LeagueShard shard, string summonerId, long championId);

        /// <summary>
        /// Get the total summation of individual champion mastery levels for associated summoner ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<int> GetTotalScoreBySummonerIdAsync(LeagueShard shard, string summonerId);

        /// <summary>
        /// Get a list of all champion mastery entries for summoner ID. Sorted by <see cref="ChampionMasteryDto.ChampionPoints"/>
        /// descending.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<List<ChampionMasteryDto>> GetEntriesBySummonerIdAsync(LeagueShard shard, string summonerId);

        /// <summary>
        /// Get a list of requested champion mastery entries sorted by <see cref="ChampionMasteryDto.ChampionPoints"/>
        /// descending.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="summonerId"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<List<ChampionMasteryDto>> GetEntriesTopBySummonerIdAsync(LeagueShard shard, string summonerId, int count = 3);
        /// <summary>
        /// Get champion mastery entry by PUUID and champion ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="puuid"></param>
        /// <param name="championId"></param>
        /// <returns></returns>
        Task<ChampionMasteryDto> GetByPuuidAsync(LeagueShard shard, string puuid, long championId);
        /// <summary>
        /// Get the total summation of individual champion mastery levels for associated PUUID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<int> GetTotalScoreByPuuidAsync(LeagueShard shard, string puuid);
        /// <summary>
        /// Get a list of all champion mastery entries for PUUID. Sorted by <see cref="ChampionMasteryDto.ChampionPoints"/> 
        /// descending.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<List<ChampionMasteryDto>> GetEntriesByPuuidAsync(LeagueShard shard, string puuid);
        /// <summary>
        /// Get a list of requested champion mastery entries sorted by <see cref="ChampionMasteryDto.ChampionPoints"/>
        /// descending.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="puuid"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<List<ChampionMasteryDto>> GetEntriesTopByPuuidAsync(LeagueShard shard, string puuid, int count = 3);
    }

    internal class ChampionMasteryV4Api : DataApi, IChampionMasteryV4Api
    {
        public ChampionMasteryV4Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ChampionMasteryDto> GetByPuuidAsync(LeagueShard shard, string puuid, long championId)
        {
            var data = await CallAsync<ChampionMasteryDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(ChampionMasteryV4Api),
                Method = UrlMethod.LolChampionMasteryV4ByEncryptedPuuidChampionId,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedPuuid, puuid },
                    { UrlMethod.ChampionId, championId.ToString() }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<ChampionMasteryDto> GetBySummonerIdAsync(LeagueShard shard, string summonerId, long championId)
        {
            var data = await CallAsync<ChampionMasteryDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(ChampionMasteryV4Api),
                Method = UrlMethod.LolChampionMasteryV4ByEncryptedSummonerIdChampionId,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedSummonerId, summonerId },
                    { UrlMethod.ChampionId, championId.ToString() }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<ChampionMasteryDto>> GetEntriesByPuuidAsync(LeagueShard shard, string puuid)
        {
            var data = await CallAsync<List<ChampionMasteryDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(ChampionMasteryV4Api),
                Method = UrlMethod.LolChampionMasteryV4ByEncryptedPuuid,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedPuuid, puuid }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<ChampionMasteryDto>> GetEntriesBySummonerIdAsync(LeagueShard shard, string summonerId)
        {
            var data = await CallAsync<List<ChampionMasteryDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(ChampionMasteryV4Api),
                Method = UrlMethod.LolChampionMasteryV4ByEncryptedSummonerId,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedSummonerId, summonerId }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<ChampionMasteryDto>> GetEntriesTopByPuuidAsync(LeagueShard shard, string puuid, int count = 3)
        {
            var data = await CallAsync<List<ChampionMasteryDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(ChampionMasteryV4Api),
                Method = UrlMethod.LolChampionMasteryV4ByEncryptedPuuidTop,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedPuuid, puuid },
                    { UrlMethod.CountQuery, count.ToString() }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<ChampionMasteryDto>> GetEntriesTopBySummonerIdAsync(LeagueShard shard, string summonerId, int count = 3)
        {
            var data = await CallAsync<List<ChampionMasteryDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(ChampionMasteryV4Api),
                Method = UrlMethod.LolChampionMasteryV4ByEncryptedSummonerIdTop,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedSummonerId, summonerId },
                    { UrlMethod.CountQuery, count.ToString() }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<int> GetTotalScoreByPuuidAsync(LeagueShard shard, string puuid)
        {
            var data = await CallAsync<int>(new()
            {
                Shard = shard,
                Endpoint = nameof(ChampionMasteryV4Api),
                Method = UrlMethod.LolChampionMasteryV4ScoresByEncryptedPuuid,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedPuuid, puuid }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<int> GetTotalScoreBySummonerIdAsync(LeagueShard shard, string summonerId)
        {
            var data = await CallAsync<int>(new()
            {
                Shard = shard,
                Endpoint = nameof(ChampionMasteryV4Api),
                Method = UrlMethod.LolChampionMasteryV4ScoresByEncryptedSummonerId,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedSummonerId, summonerId }
                }
            }).ConfigureAwait(false);

            return data;
        }
    }
}
