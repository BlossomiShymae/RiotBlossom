using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LorMatch
{
    public record InfoDto : DataObject
    {
        /// <summary>
        /// The current game mode. (Legal values: Constructed, Expeditions, Tutorial, and a lot more not documented)
        /// </summary>
        [JsonPropertyName("game_mode")]
        public string GameMode { get; init; } = default!;
        /// <summary>
        /// The current game type. (Legal values: Ranked, Normal, AI, Tutorial, VanillaTrial, Singleton, StandardGauntlet, or an empty string for Lab games)
        /// </summary>
        [JsonPropertyName("game_type")]
        public string GameType { get; init; } = default!;
        /// <summary>
        /// The time the game has started in Coordinated Universal Time.
        /// </summary>
        [JsonPropertyName("game_start_time_utc")]
        public string GameStartTimeUtc { get; init; } = default!;
        /// <summary>
        /// The current game version.
        /// </summary>
        [JsonPropertyName("game_version")]
        public string GameVersion { get; init; } = default!;
        /// <summary>
        /// The players participating in game.
        /// </summary>
        public ImmutableList<PlayerDto> Players { get; init; } = ImmutableList<PlayerDto>.Empty;
        /// <summary>
        /// The total turns taken by both players.
        /// </summary>
        [JsonPropertyName("total_turn_count")]
        public int TotalTurnCount { get; init; }
    }
}
