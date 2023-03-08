using System.Collections.Immutable;

namespace Soraka.Dto.LolStatus
{
	internal record UpdateDto
	{
		public int Id { get; init; }
		public string Author { get; init; } = default!;
		public bool Publish { get; init; }
		public ImmutableList<string> PublishLocations { get; init; } = ImmutableList<string>.Empty;
		public string CreatedAt { get; init; } = default!;
		public string UpdatedAt { get; init; } = default!;
	}
}
