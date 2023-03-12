using System.Collections.Immutable;

namespace Gwen.Dto.Match
{
    internal record PerkStyleDto
    {
        public string Description { get; init; } = default!;
        public ImmutableList<PerkStyleSelectionDto> Selections { get; init; } = ImmutableList<PerkStyleSelectionDto>.Empty;
        public int Style { get; init; }
    }
}
