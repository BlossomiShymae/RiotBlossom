using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LorMatch
{
    public record PlayerDto
    {
        /// <summary>
        /// The player UUID.
        /// </summary>
        public string Puuid { get; init; } = default!;
        /// <summary>
        /// The ID for the deck played.
        /// </summary>
        [JsonPropertyName("deck_id")]
        public string DeckId { get; init; } = default!;
        /// <summary>
        /// The code for the deck played.
        /// </summary>
        [JsonPropertyName("deck_code")]
        public string DeckCode { get; init; } = default!;
        public ImmutableList<string> Factions { get; init; } = ImmutableList<string>.Empty;
        [JsonPropertyName("game_outcome")]
        public string GameOutcome { get; init; } = default!;
        /// <summary>
        /// The order in which the players took turns.
        /// </summary>
        [JsonPropertyName("order_of_play")]
        public int OrderOfPlayer { get; init; }
    }
}
