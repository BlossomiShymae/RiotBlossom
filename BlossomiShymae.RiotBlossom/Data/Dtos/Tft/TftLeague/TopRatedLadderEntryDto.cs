namespace BlossomiShymae.RiotBlossom.Data.Dtos.Tft.TftLeague
{
    public record TopRatedLadderEntryDto : DataObject
    {
        /// <summary>
        /// The encrypted summoner ID.
        /// </summary>
        public required string SummonerId { get; init; } 
        /// <summary>
        /// The summoner name.
        /// </summary>
        public required string SummonerName { get; init; } 
        /// <summary>
        /// (Legal values: ORANGE, PURPLE, BLUE, GREEN, GRAY)
        /// </summary>
        public required string RatedTier { get; init; }
        /// <summary>
        /// The rated rating.
        /// </summary>
        public int RatedRating { get; init; }
        /// <summary>
        /// The amount of wins.
        /// </summary>
        public int Wins { get; init; }
        public int PreviousUpdateLadderPosition { get; init; }
    }
}
