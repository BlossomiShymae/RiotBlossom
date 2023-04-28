using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LolChallenges
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record ChallengeInfo
    {
        public long ChallengeId { get; init; }
        public double Percentile { get; init; }
        public string Level { get; init; } = default!;
        public double Value { get; init; }
        public long AchievedTime { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
