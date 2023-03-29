using System.Collections.Immutable;

namespace BlossomiShymae.Gwen.Dto.DDragon.Perk
{
    public record Slot
    {
        public ImmutableList<PerkRune> Runes { get; init; } = ImmutableList<PerkRune>.Empty;
    }
}
