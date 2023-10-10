using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Core.Cache;
using BlossomiShymae.RiotBlossom.Core.Exceptions;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match;
using System.Collections.Immutable;
using System.Configuration;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Lol
{
    public interface IMatchV5Api
    {
        /// <summary>
        /// Get a match by ID.
        /// </summary>
        /// <exception cref="CorruptedMatchException"></exception>
        /// <param name="shard"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchDto> GetByIdAsync(RegionShard shard, string id);
        /// <summary>
        /// Get a match timeline by ID.
        /// </summary>
        /// <exception cref="CorruptedMatchException"></exception>
        /// <param name="shard"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchTimelineDto> GetTimelineByIdAsync(RegionShard shard, string id);
        /// <summary>
        /// List the last 20 most recent match IDs for encrypted PUUID.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<List<string>> GetMatchlistByPuuidAsync(MatchV5MatchlistOptions options);
    }

    public record MatchV5MatchlistOptions
    {
        public required RegionShard Shard { get; set; }
        public required string Puuid { get; set; }
        public int Start { get; set; } = 0;
        public int Count { get; set; } = 20;
        public long? StartTime { get; set; }
        public long? EndTime { get; set; }
        public int? Queue { get; set; }
        public string? Type { get; set; }
    }

    internal class MatchV5Api(ApiConfiguration configuration) : DataApi(configuration), IMatchV5Api
    {
        public async Task<MatchDto> GetByIdAsync(RegionShard shard, string id)
        {
            var data = await CallAsync<MatchDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(MatchV5Api),
                Method = UrlMethod.LolMatchV5ByMatchId,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.MatchId, id }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<string>> GetMatchlistByPuuidAsync(MatchV5MatchlistOptions options)
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
            if (options.Queue != null)
            {
                parameters.Add(UrlMethod.QueueQuery, options.Queue.ToString()!);
            }
            if (options.Type != null)
            {
                parameters.Add(UrlMethod.TypeQuery, options.Type);
            }

            var data = await CallAsync<List<string>>(new()
            {
                Shard = options.Shard,
                Endpoint = nameof(MatchV5Api),
                Method = UrlMethod.LolMatchV5ByPuuid,
                Params = parameters
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<MatchTimelineDto> GetTimelineByIdAsync(RegionShard shard, string id)
        {
            var data = await CallAsync<MatchTimelineDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(MatchV5Api),
                Method = UrlMethod.LolMatchV5Timeline,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.MatchId, id }
                }
            }).ConfigureAwait(false);

            return data;
        }
    }
}
