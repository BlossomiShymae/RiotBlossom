namespace BlossomiShymae.RiotBlossom.Dto.Riot.Clash
{
    public record PlayerDto
    {
        /// <summary>
        /// The encrypted summoner ID of player.
        /// </summary>
        public string SummonerId { get; init; } = default!;
        /// <summary>
        /// The associated team ID of player.
        /// </summary>
        public string TeamId { get; init; } = default!;
        /// <summary>
        /// The assigned position ('UNSELECTED', 'FILL', 'TOP', 'JUNGLE', 'MIDDLE', 'BOTTOM', 'UTILITY').
        /// </summary>
        public string Position { get; init; } = default!;
        /// <summary>
        /// The assigned role ('CAPTAIN', 'MEMBER').
        /// </summary>
        public string Role { get; init; } = default!;
    }
}
