namespace BlossomiShymae.RiotBlossom.Dto.Riot.Match
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record TimelineParticipant
    {
        public int ParticipantId { get; init; }
        public string Puuid { get; init; } = default!;
    }
}
