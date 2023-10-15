namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record PlayerStatsDto : DataObject
    {
        public int Score { get; init; }
        public int RoundsPlayed { get; init; }
        public int Kills { get; init; }
        public int Deaths { get; init; }
        public int Assists { get; init; }
        public int PlaytimeMillis { get; init; }
        public AbilityCastsDto AbilityCasts { get; init; } = new();
    }
}
