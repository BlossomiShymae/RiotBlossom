using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Spectator
{
    public record Perks : DataObject
    {
        /// <summary>
        /// The list of equipped perk/runes IDs.
        /// </summary>
        public List<long> PerkIds { get; init; } = [];
        /// <summary>
        /// The primary runes path.
        /// </summary>
        public long PerkStyle { get; init; }
        /// <summary>
        /// The secondary runes path.
        /// </summary>
        public long PerkSubStyle { get; init; }
    }
}
