using System.Collections.Immutable;

namespace Soraka.Dto.LolStatus
{
	internal record PlatformDataDto
	{
		public string Id { get; init; } = default!;
		public string Name { get; init; } = default!;
		public ImmutableList<string> Locales { get; init; } = ImmutableList<string>.Empty;
		public ImmutableList<StatusDto> Maintenances { get; init; } = ImmutableList<StatusDto>.Empty;
		public ImmutableList<StatusDto> Incidents { get; init; } = ImmutableList<StatusDto>.Empty;
	}
}
