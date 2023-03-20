namespace Gwen.Dto.Riot.Match
{
    public record TimelineParticipant
    {
        public int ParticipantId { get; init; }
        public string Puuid { get; init; } = default!;
    }
}
