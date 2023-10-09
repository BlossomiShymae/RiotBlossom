using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Tft.TftMatch;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Tft
{
    public interface ITftMatchV1Api
    {
        /// <summary>
        /// Get a match by ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchDto> GetByIdAsync(RegionShard shard, string id);
        /// <summary>
        /// List the last 20 most recent match IDs for encrypted PUUID.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<List<string>> GetMatchlistByPuuidAsync(TftMatchV1MatchlistOptions options);
     }

     public record TftMatchV1MatchlistOptions
     {
        public required RegionShard Shard { get; set; }
        public required string Puuid { get; set; }
        public int Start { get; set; } = 0;
        public int Count { get; set; } = 20;
        public long? StartTime { get; set; }
        public long? EndTime { get; set; }
     }

    internal class TftMatchV1Api : DataApi, ITftMatchV1Api
    {
        public TftMatchV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<MatchDto> GetByIdAsync(RegionShard shard, string id)
        {
            var data = await CallAsync<MatchDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(TftMatchV1Api),
                Method = UrlMethod.TftMatchV1ById,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.MatchId, id }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<string>> GetMatchlistByPuuidAsync(TftMatchV1MatchlistOptions options)
        {
            var parameters = new Dictionary<string, string>()
            {
                { UrlMethod.Puuid, options.Puuid },
                { UrlMethod.StartQuery, options.Start.ToString() },
                { UrlMethod.CountQuery, options.Count.ToString() }
            };

            if (options.StartTime != null)
            {
                parameters.Add(UrlMethod.StartTimeQuery, options.StartTime.ToString()!);
            }
            if (options.EndTime != null)
            {
                parameters.Add(UrlMethod.EndTimeQuery, options.EndTime.ToString()!);
            }

            var data = await CallAsync<List<string>>(new()
            {
                Shard = options.Shard,
                Endpoint = nameof(TftMatchV1Api),
                Method = UrlMethod.TftMatchV1MatchesByPuudi,
                Params = parameters
            }).ConfigureAwait(false);

            return data;
        }
    }
}
