using System.Collections.Immutable;

namespace Soraka.Dto.Match
{
	internal record MetadataDto
	{
		public string DataVersion { get; init; } = default!;
		public string MatchId { get; init; } = default!;
		public ImmutableList<string> Participants { get; init; } = ImmutableList<string>.Empty;
	}
}
