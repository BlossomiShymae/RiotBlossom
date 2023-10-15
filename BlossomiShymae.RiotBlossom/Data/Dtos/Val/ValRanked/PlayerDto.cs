namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValRanked
{
    public record PlayerDto : DataObject
    {
        /// <summary>
        /// The player UUID. May be omitted if player is anonymized.
        /// </summary>
        public string? Puuid { get; init; }
        /// <summary>
        /// The game name of player. May be omitted if player is anonymized.
        /// </summary>
        public string? GameName { get; init; }
        /// <summary>
        /// The tag line of player. May be omitted if player is anonymized.
        /// </summary>
        public string? TagLine { get; init; }
        public long LeaderboardRank { get; init; }
        public long RankedRating { get; init; }
        public long NumberOfWins { get; init; }
    }
}
