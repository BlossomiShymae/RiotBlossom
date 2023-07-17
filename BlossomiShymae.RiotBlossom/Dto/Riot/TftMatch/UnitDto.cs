using System.Collections.Immutable;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.TftMatch
{
    public record UnitDto : DataObject
    {
        /// <summary>
        /// The list of the unit's items.
        /// </summary>
        public ImmutableList<int> Items { get; init; } = ImmutableList<int>.Empty;
        /// <summary>
        /// The ID of chosen character.
        /// </summary>
        [JsonPropertyName("character_id")]
        public string CharacterId { get; init; } = default!;
        /// <summary>
        /// The chosen trait. Only included for Fates set.
        /// </summary>
        public string? Chosen { get; init; } = default!;
        /// <summary>
        /// The unit name.
        /// </summary>
        public string Name { get; init; } = default!;
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
