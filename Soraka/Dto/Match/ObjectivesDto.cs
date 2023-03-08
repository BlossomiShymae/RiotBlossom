namespace Soraka.Dto.Match
{
	internal record ObjectivesDto
	{
		public ObjectiveDto Baron { get; init; } = new();
		public ObjectiveDto Champion { get; init; } = new();
		public ObjectiveDto Dragon { get; init; } = new();
		public ObjectiveDto Inhibitor { get; init; } = new();
		public ObjectiveDto RiftHerald { get; init; } = new();
		public ObjectiveDto Tower { get; init; } = new();
	}
}
