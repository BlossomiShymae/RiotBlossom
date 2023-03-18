using System.Collections.Immutable;

namespace Gwen.Dto.DDragon.Perk
{
	public record Slot
	{
		public ImmutableList<PerkRune> Runes { get; init; } = ImmutableList<PerkRune>.Empty;
	}
}
