namespace BlossomiShymae.RiotBlossom.Dto.Riot.Spectator
{
    public record Participant : DataObject<Participant>
    {
        /// <summary>
        /// Whether this participant is a bot.
        /// </summary>
        public bool Bot { get; init; }
        /// <summary>
        /// The second equipped summoner spell ID.
        /// </summary>
        public long Spell2Id { get; init; }
        /// <summary>
        /// The profile icon ID of participant.
        /// </summary>
        public long ProfileIconId { get; init; }
        /// <summary>
        /// The summoner name of participant.
        /// </summary>
        public string SummonerName { get; init; } = default!;
        /// <summary>
        /// The played champion ID.
        /// </summary>
        public long ChampionId { get; init; }
        /// <summary>
        /// The participant's team ID.
        /// </summary>
        public long TeamId { get; init; }
        /// <summary>
        /// The first equipped summoner spell ID.
        /// </summary>
        public long Spell1Id { get; init; }
    }
}
