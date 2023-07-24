namespace BlossomiShymae.RiotBlossom.Dto.Riot.ChampionMastery
{
    public record ChampionMasteryDto : DataObject
    {
        /// <summary>
        /// The encrypted Player Universal Unique Identifier associated with the champion mastery.
        /// This field was added to the API in July 2023.
        /// <para><see href="https://github.com/RiotGames/developer-relations/issues/767"/></para>
        /// </summary>
        public string? Puuid { get; init; }
        /// <summary>
        /// The number of points needed to achieve next mastery level. Zero when player has reached
        /// the maximum level.
        /// </summary>
        public long ChampionPointsUntilNextLevel { get; init; } = default!;
        /// <summary>
        /// If hextech chest was earned in the current patch season.
        /// </summary>
        public bool ChestGranted { get; init; }
        /// <summary>
        /// The associated champion ID for mastery.
        /// </summary>
        public long ChampionId { get; init; }
        /// <summary>
        /// The last time in Unix epoch milliseconds the champion was played for associated summoner.
        /// </summary>
        public long LastPlayTime { get; init; }
        /// <summary>
        /// The champion level for player and champion combination.
        /// </summary>
        public int ChampionLevel { get; init; }
        /// <summary>
        ///  The associated summoner ID.
        /// </summary>
        public string SummonerId { get; init; } = default!;
        /// <summary>
        /// The total number of champion points for player and champion combination.
        /// </summary>
        public int ChampionPoints { get; init; }
        /// <summary>
        /// The number of points earned since achieved current level.
        /// </summary>
        public long ChampionPointsSinceLastLevel { get; init; }
        /// <summary>
        /// The tokens earned for champion at current level. Resets to zero when <see cref="ChampionLevel"/> advances.
        /// </summary>
        public int TokensEarned { get; init; }
    }
}
