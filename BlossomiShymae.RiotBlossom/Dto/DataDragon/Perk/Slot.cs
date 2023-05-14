using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.DataDragon.Perk
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Slot : DataObject<Slot>
    {
        public ImmutableList<PerkRune> Runes { get; init; } = ImmutableList<PerkRune>.Empty;
    }
}
