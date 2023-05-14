using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LorMatch
{
    public record MetadataDto : DataObject<MetadataDto>
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
        /// The list of participant PUUIDs.
        /// </summary>
        public ImmutableList<string> Participants { get; init; } = ImmutableList<string>.Empty;
    }
}
