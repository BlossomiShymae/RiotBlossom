using System.Collections.Immutable;

namespace Soraka.Dto.LolStatus
{
	internal record StatusDto
	{
		public int Id { get; init; }
		public string MaintenanceStatus { get; init; } = default!;
		public string IncidentSeverity { get; init; } = default!;
		public ImmutableList<ContentDto> Titles { get; init; } = ImmutableList<ContentDto>.Empty;
		public ImmutableList<UpdateDto> Updates { get; init; } = ImmutableList<UpdateDto>.Empty;
		public string CreatedAt { get; init; } = default!;
		public string ArchiveAt { get; init; } = default!;
		public string UpdatedAt { get; init; } = default!;
		public ImmutableList<string> Platforms { get; init; } = ImmutableList<string>.Empty;
	}
}
