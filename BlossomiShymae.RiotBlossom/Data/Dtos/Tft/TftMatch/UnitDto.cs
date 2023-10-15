using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Tft.TftMatch
{
    public record UnitDto : DataObject
    {
        /// <summary>
        /// The list of the unit's items.
        /// </summary>
        public List<int> Items { get; init; } = [];
        /// <summary>
        /// The ID of chosen character.
        /// </summary>
        [JsonPropertyName("character_id")]
        public required string CharacterId { get; init; }
        /// <summary>
        /// The chosen trait. Only included for Fates set.
        /// </summary>
        public string? Chosen { get; init; }
        /// <summary>
        /// The unit name.
        /// </summary>
        public required string Name { get; init; }
        /// <summary>
        /// The unit rarity.
        /// </summary>
        public int Rarity { get; init; }
        /// <summary>
        /// The unit tier.
        /// </summary>
        public int Tier { get; init; }
    }
}
