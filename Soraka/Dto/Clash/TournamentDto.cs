using System.Collections.Immutable;

namespace Soraka.Dto.Clash
{
	internal record TournamentDto
	{
		public int Id { get; init; }
		public int ThemeId { get; init; }
		public string NameKey { get; init; } = default!;
		public string NameKeySecondary { get; init; } = default!;
		public ImmutableList<TournamentPhaseDto> Schedule { get; init; } = ImmutableList<TournamentPhaseDto>.Empty;
	}
}
