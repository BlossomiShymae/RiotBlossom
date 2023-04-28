using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.TftLeague
{
    public record TopRatedLadderEntryDto
    {
        /// <summary>
        /// The encrypted summoner ID.
        /// </summary>
        public string SummonerId { get; init; } = default!;
        /// <summary>
        /// The summoner name.
        /// </summary>
        public string SummonerName { get; init; } = default!;
        /// <summary>
        /// (Legal values: ORANGE, PURPLE, BLUE, GREEN, GRAY)
        /// </summary>
        public string RatedTier { get; init; } = default!;
        /// <summary>
        /// The rated rating.
        /// </summary>
        public int RatedRating { get; init; }
        /// <summary>
        /// The amount of wins.
        /// </summary>
        public int Wins { get; init; }
        public int PreviousUpdateLadderPosition { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
