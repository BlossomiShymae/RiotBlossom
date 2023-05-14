using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.TftMatch
{
    public record InfoDto : DataObject<InfoDto>
    {
        /// <summary>
        /// The Unix timestamp.
        /// </summary>
        [JsonPropertyName("game_date_time")]
        public long GameDateTime { get; init; }
        /// <summary>
        /// The game length in seconds.
        /// </summary>
        [JsonPropertyName("game_length")]
        public float GameLength { get; init; }
        /// <summary>
        /// The game variation key.
        /// </summary>
        [JsonPropertyName("game_variation")]
        public string GameVariation { get; init; } = default!;
        /// <summary>
        /// The game client version.
        /// </summary>
        [JsonPropertyName("game_version")]
        public string GameVersion { get; init; } = default!;
        /// <summary>
        /// The list of active participants.
        /// </summary>
        public ImmutableList<ParticipantDto> Participants { get; init; } = ImmutableList<ParticipantDto>.Empty;
        /// <summary>
        /// The queue ID of game.
        /// </summary>
        [JsonPropertyName("queue_id")]
        public int QueueId { get; init; }
        /// <summary>
        /// The current Teamfight Tactics set number.
        /// </summary>
        [JsonPropertyName("tft_set_number")]
        public int TftSetNumber { get; init; }
    }
}
