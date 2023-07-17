using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.DataDragon.Perk
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Slot : DataObject
    {
        public ImmutableList<PerkRune> Runes { get; init; } = ImmutableList<PerkRune>.Empty;
    }
}
