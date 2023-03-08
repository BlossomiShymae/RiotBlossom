using System.Collections.Immutable;

namespace Soraka.Dto.Match
{
	internal record PerksDto
	{
		public PerkStatsDto StatPerks { get; init; } = new();
		public ImmutableList<PerkStyleDto> Styles { get; init; } = ImmutableList<PerkStyleDto>.Empty;
	}
}
