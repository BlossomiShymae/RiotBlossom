namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record TimelineParticipant : DataObject
    {
        public int ParticipantId { get; init; }
        public required string Puuid { get; init; }
    }
}
