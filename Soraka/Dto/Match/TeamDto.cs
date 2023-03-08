using System.Collections.Immutable;

namespace Soraka.Dto.Match
{
	internal record TeamDto
	{
		public ImmutableList<BanDto> Bans { get; init; } = ImmutableList<BanDto>.Empty;
		public ObjectivesDto Objectives { get; init; } = new();
		public int TeamId { get; init; }
		public bool Win { get; init; }
	}
}
