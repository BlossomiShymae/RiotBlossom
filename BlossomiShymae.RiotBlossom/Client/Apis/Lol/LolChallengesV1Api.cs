using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Constants.Types.Lol;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolChallenges;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Lol
{
    public interface ILolChallengesV1Api
    {
        /// <summary>
        /// Get challenge configuration information by ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ChallengeConfigInfoDto> GetConfigInfoByIdAsync(LeagueShard shard, long id);
        /// <summary>
        /// Get a dictionary of challenge percentiles for players who have achieved it.
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, Dictionary<string, double>>> GetPercentilesAsync(LeagueShard shard);
        /// <summary>
        /// Get challenge percentiles from ID for players who have achieved it.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Dictionary<string, double>> GetPercentilesByIdAsync(LeagueShard shard, long id);
        /// <summary>
        /// Get progressed challenge information details for encrypted PUUID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<PlayerInfoDto> GetPlayerInfoByPuuidAsync(LeagueShard shard, string puuid);
        /// <summary>
        /// Get the apex players for challenge level.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="level"></param>
        /// <param name="id"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<List<ApexPlayerInfoDto>> GetApexPlayerInfosAsync(LeagueShard shard, ChallengeLevel level, long id, int limit = 0);
        /// <summary>
        /// List all basic challenge configuration information.
        /// </summary>
        /// <param name="shard"></param>
        /// <returns></returns>
        Task<List<ChallengeConfigInfoDto>> GetConfigInfosAsync(LeagueShard shard);
    }

    internal class LolChallengesV1Api : DataApi, ILolChallengesV1Api
    {
        public LolChallengesV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<ApexPlayerInfoDto>> GetApexPlayerInfosAsync(LeagueShard shard, ChallengeLevel level, long id, int limit = 0)
        {
            var data = await CallAsync<List<ApexPlayerInfoDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(LolChallengesV1Api),
                Method = UrlMethod.LolChallengesV1Leaderboards,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Level, level.Value },
                    { UrlMethod.ChallengeId, id.ToString() },
                    { UrlMethod.LimitQuery, limit.ToString() }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<ChallengeConfigInfoDto> GetConfigInfoByIdAsync(LeagueShard shard, long id)
        {
            var data = await CallAsync<ChallengeConfigInfoDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(LolChallengesV1Api),
                Method = UrlMethod.LolChallengesV1ConfigById,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.ChallengeId, id.ToString() }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<ChallengeConfigInfoDto>> GetConfigInfosAsync(LeagueShard shard)
        {
            var data = await CallAsync<List<ChallengeConfigInfoDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(LolChallengesV1Api),
                Method = UrlMethod.LolChallengesV1Config,
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<Dictionary<string, Dictionary<string, double>>> GetPercentilesAsync(LeagueShard shard)
        {
            var data = await CallAsync<Dictionary<string, Dictionary<string, double>>>(new()
            {
                Shard = shard,
                Endpoint = nameof(LolChallengesV1Api),
                Method = UrlMethod.LolChallengesV1Percentiles,
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<Dictionary<string, double>> GetPercentilesByIdAsync(LeagueShard shard, long id)
        {
            var data = await CallAsync<Dictionary<string, double>>(new()
            {
                Shard = shard,
                Endpoint = nameof(LolChallengesV1Api),
                Method = UrlMethod.LolChallengesV1PercentilesById,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.ChallengeId, id.ToString() }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<PlayerInfoDto> GetPlayerInfoByPuuidAsync(LeagueShard shard, string puuid)
        {
            var data = await CallAsync<PlayerInfoDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(LolChallengesV1Api),
                Method = UrlMethod.LolChallengesV1PlayerDataByPuuid,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Puuid, puuid }
                }
            }).ConfigureAwait(false);

            return data;
        }
    }
}
