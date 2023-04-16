using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.TftMatch
{
    public record MetadataDto
    {
        /// <summary>
        /// The match data version.
        /// </summary>
        [JsonPropertyName("data_version")]
        public string DataVersion { get; init; } = default!;
        /// <summary>
        /// The match ID.
        /// </summary>
        [JsonPropertyName("match_id")]
        public string MatchId { get; init; } = default!;
        /// <summary>
        /// The list of active participant PUUIDs.
        /// </summary>
        public ImmutableList<string> Participants { get; init; } = ImmutableList<string>.Empty;
    }
}
