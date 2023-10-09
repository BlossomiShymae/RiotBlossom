using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lor.LorMatch
{
    public record InfoDto : DataObject
    {
        /// <summary>
        /// The current game mode. (Legal values: Constructed, Expeditions, Tutorial, and a lot more not documented)
        /// </summary>
        [JsonPropertyName("game_mode")]
        public required string GameMode { get; init; } 
        /// <summary>
        /// The current game type. (Legal values: Ranked, Normal, AI, Tutorial, VanillaTrial, Singleton, StandardGauntlet, or an empty string for Lab games)
        /// </summary>
        [JsonPropertyName("game_type")]
        public required string GameType { get; init; } 
        /// <summary>
        /// The time the game has started in Coordinated Universal Time.
        /// </summary>
        [JsonPropertyName("game_start_time_utc")]
        public required string GameStartTimeUtc { get; init; }
        /// <summary>
        /// The current game version.
        /// </summary>
        [JsonPropertyName("game_version")]
        public required string GameVersion { get; init; }
        /// <summary>
        /// The players participating in game.
        /// </summary>
        public List<PlayerDto> Players { get; init; } = [];
        /// <summary>
        /// The total turns taken by both players.
        /// </summary>
        [JsonPropertyName("total_turn_count")]
        public int TotalTurnCount { get; init; }
    }
}
