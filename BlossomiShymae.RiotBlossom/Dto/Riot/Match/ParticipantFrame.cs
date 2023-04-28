using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.Match
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record ParticipantFrame
    {
        public ChampionStats ChampionStats { get; init; } = new();
        public long CurrentGold { get; init; }
        public DamageStats DamageStats { get; init; } = new();
        public int GoldPerSecond { get; init; }
        public long JungleMinionsKilled { get; init; }
        public int Level { get; init; }
        public long MinionsKilled { get; init; }
        public long ParticipantId { get; init; }
        public Position Position { get; init; } = new();
        public long TimeEnemySpentControlled { get; init; }
        public long TotalGold { get; init; }
        public long Xp { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
