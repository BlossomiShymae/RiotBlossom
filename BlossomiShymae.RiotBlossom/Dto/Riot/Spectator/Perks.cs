using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.Spectator
{
    public record Perks
    {
        /// <summary>
        /// The list of equipped perk/runes IDs.
        /// </summary>
        public ImmutableList<long> PerkIds { get; init; } = ImmutableList<long>.Empty;
        /// <summary>
        /// The primary runes path.
        /// </summary>
        public long PerkStyle { get; init; }
        /// <summary>
        /// The secondary runes path.
        /// </summary>
        public long PerkSubStyle { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
