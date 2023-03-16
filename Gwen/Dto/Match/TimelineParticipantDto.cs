namespace Gwen.Dto.Match
{
	public record TimelineParticipantDto
	{
		public int ParticipantId { get; init; }
		public string Puuid { get; init; } = default!;
	}
}
