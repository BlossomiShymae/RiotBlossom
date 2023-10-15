using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lor.LorMatch
{
    public record PlayerDto : DataObject
    {
        /// <summary>
        /// The player UUID.
        /// </summary>
        public required string Puuid { get; init; }
        /// <summary>
        /// The ID for the deck played.
        /// </summary>
        [JsonPropertyName("deck_id")]
        public required string DeckId { get; init; } 
        /// <summary>
        /// The code for the deck played.
        /// </summary>
        [JsonPropertyName("deck_code")]
        public required string DeckCode { get; init; }
        public List<string> Factions { get; init; } = [];
        [JsonPropertyName("game_outcome")]
        public required string GameOutcome { get; init; }
        /// <summary>
        /// The order in which the players took turns.
        /// </summary>
        [JsonPropertyName("order_of_play")]
        public int OrderOfPlay { get; init; }
    }
}
