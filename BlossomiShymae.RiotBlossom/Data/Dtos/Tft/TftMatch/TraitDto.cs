using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Tft.TftMatch
{
    public record TraitDto : DataObject
    {
        /// <summary>
        /// The trait name.
        /// </summary>
        public required string Name { get; init; } 
        /// <summary>
        /// The number of units with this trait.
        /// </summary>
        [JsonPropertyName("num_units")]
        public int NumUnits { get; init; }
        /// <summary>
        /// The current style. (0 = No style, 1 = Bronze, 2 = Silver, 3 = Gold, 4 = Chromatic) 
        /// </summary>
        public int Style { get; init; }
        /// <summary>
        /// The current active tier.
        /// </summary>
        [JsonPropertyName("tier_current")]
        public int TierCurrent { get; init; }
        /// <summary>
        /// The total tiers.
        /// </summary>
        [JsonPropertyName("tier_total")]
        public int TierTotal { get; init; }
    }
}
