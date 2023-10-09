using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match
{
    public record PerkStyleDto : DataObject
    {
        /// <summary>
        /// The description of perk style.
        /// </summary>
        public required string Description { get; init; } 
        /// <summary>
        /// The selected perk styles.
        /// </summary>
        public List<PerkStyleSelectionDto> Selections { get; init; } = [];
        /// <summary>
        /// The style ID.
        /// </summary>
        public int Style { get; init; }
    }
}
