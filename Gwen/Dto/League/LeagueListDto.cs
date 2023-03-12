using System.Collections.Immutable;

namespace Gwen.Dto.League
{
    internal record LeagueListDto
    {
        public string LeagueId { get; init; } = default!;
        public ImmutableList<LeagueItemDto> Entries { get; init; } = ImmutableList<LeagueItemDto>.Empty;
        public string Tier { get; init; } = default!;
        public string Name { get; init; } = default!;
        public string Queue { get; init; } = default!;
    }
}
