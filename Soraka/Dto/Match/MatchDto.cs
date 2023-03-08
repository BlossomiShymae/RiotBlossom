namespace Soraka.Dto.Match
{
	internal record MatchDto
	{
		public MetadataDto Metadata { get; init; } = new();
		public InfoDto Info { get; init; } = new();
	}
}
