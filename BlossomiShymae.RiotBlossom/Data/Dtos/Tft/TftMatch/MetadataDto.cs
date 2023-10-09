using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Tft.TftMatch
{
    public record MetadataDto : DataObject
    {
        /// <summary>
        /// The match data version.
        /// </summary>
        [JsonPropertyName("data_version")]
        public required string DataVersion { get; init; }
        /// <summary>
        /// The match ID.
        /// </summary>
        [JsonPropertyName("match_id")]
        public required string MatchId { get; init; }
        /// <summary>
        /// The list of active participant PUUIDs.
        /// </summary>
        public List<string> Participants { get; init; } = [];
    }
}
