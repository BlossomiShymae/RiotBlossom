namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolChallenges
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record ChallengeInfo : DataObject
    {
        public long ChallengeId { get; init; }
        public double Percentile { get; init; }
        public required string Level { get; init; }
        public double Value { get; init; }
        public long AchievedTime { get; init; }
    }
}
