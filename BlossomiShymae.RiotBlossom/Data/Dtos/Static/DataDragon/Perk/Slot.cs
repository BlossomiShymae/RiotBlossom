using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Perk
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Slot : DataObject
    {
        public List<PerkRune> Runes { get; init; } = [];
    }
}
