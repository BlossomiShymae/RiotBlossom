using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.DataDragon.Perk
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record PerkStyle
    {
        public int Id { get; init; }
        public string Key { get; init; } = default!;
        public string Icon { get; init; } = default!;
        public string Name { get; init; } = default!;
        public ImmutableList<Slot> Slots { get; init; } = ImmutableList<Slot>.Empty;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
