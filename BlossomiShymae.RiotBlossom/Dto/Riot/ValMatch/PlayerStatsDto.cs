using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record PlayerStatsDto
    {
        public int Score { get; init; }
        public int RoundsPlayed { get; init; }
        public int Kills { get; init; }
        public int Deaths { get; init; }
        public int Assists { get; init; }
        public int PlaytimeMillis { get; init; }
        public AbilityCastsDto AbilityCasts { get; init; } = new();

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
