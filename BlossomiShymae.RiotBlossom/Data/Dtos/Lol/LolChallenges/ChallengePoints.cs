namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolChallenges
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record ChallengePoints : DataObject
    {
        public required string Level { get; init; }
        public double Current { get; init; }
        public double Max { get; init; }
        public double Percentile { get; init; }
    }
}
