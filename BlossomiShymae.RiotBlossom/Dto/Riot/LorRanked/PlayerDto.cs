namespace BlossomiShymae.RiotBlossom.Dto.Riot.LorRanked
{
    public record PlayerDto
    {
        /// <summary>
        /// The player name.
        /// </summary>
        public string Name { get; init; } = default!;
        /// <summary>
        /// The rank of player.
        /// </summary>
        public int Rank { get; init; }
        /// <summary>
        /// The League points of player.
        /// </summary>
        public int Lp { get; init; }
    }
}
