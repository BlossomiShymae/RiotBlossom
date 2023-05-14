namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record TeamDto : DataObject<TeamDto>
    {
        /// <summary>
        /// The arbitrary string, being Red and Blue in bomb modes, the PUUID of the player in deathmatch.
        /// </summary>
        public string TeamId { get; init; } = default!;
        /// <summary>
        /// Whether the team has won the game.
        /// </summary>
        public bool Won { get; init; }
        /// <summary>
        /// The amount of rounds played.
        /// </summary>
        public int RoundsPlayed { get; init; }
        /// <summary>
        /// The amount of rounds the team won.
        /// </summary>
        public int RoundsWon { get; init; }
        /// <summary>
        /// The team points scored. Number of kills in deathmatch.
        /// </summary>
        public int NumPoints { get; init; }
    }
}
