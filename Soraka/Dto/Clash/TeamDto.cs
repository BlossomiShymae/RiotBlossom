using System.Collections.Immutable;

namespace Soraka.Dto.Clash
{
	internal record TeamDto
	{
		public string Id { get; init; } = default!;
		public int Tournament { get; init; }
		public string Name { get; init; } = default!;
		public int IconId { get; init; }
		public int Tier { get; init; }
		public string Captain { get; init; } = default!;
		public string Abbreviation { get; init; } = default!;
		public ImmutableList<PlayerDto> Players { get; init; } = ImmutableList<PlayerDto>.Empty;
	}
}
