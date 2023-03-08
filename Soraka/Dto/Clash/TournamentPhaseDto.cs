namespace Soraka.Dto.Clash
{
	internal record TournamentPhaseDto
	{
		public int Id { get; init; }
		public long RegistrationTime { get; init; }
		public long StartTime { get; init; }
		public bool Cancelled { get; init; }
	}
}
