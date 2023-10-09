namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Clash
{
    public record PlayerDto : DataObject
    {
        /// <summary>
        /// The encrypted summoner ID of player.
        /// </summary>
        public required string SummonerId { get; init; }
        /// <summary>
        /// The associated team ID of player.
        /// </summary>
        public required string TeamId { get; init; }
        /// <summary>
        /// The assigned position ('UNSELECTED', 'FILL', 'TOP', 'JUNGLE', 'MIDDLE', 'BOTTOM', 'UTILITY').
        /// </summary>
        public required string Position { get; init; }
        /// <summary>
        /// The assigned role ('CAPTAIN', 'MEMBER').
        /// </summary>
        public required string Role { get; init; }
    }
}
