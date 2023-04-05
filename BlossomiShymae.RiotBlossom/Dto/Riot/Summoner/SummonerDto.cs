namespace BlossomiShymae.RiotBlossom.Dto.Riot.Summoner
{
    public record SummonerDto
    {
        /// <summary>
        /// The encrypted account ID.
        /// </summary>
        public string AccountId { get; init; } = default!;
        /// <summary>
        /// The ID of the summoner icon associated with the summoner.
        /// </summary>
        public int ProfileIconId { get; init; }
        /// <summary>
        /// The last modified date of summoner in Unix epoch (Unix timestamp, POSIX time) milliseconds.
        /// </summary>
        public long RevisionDate { get; init; }
        /// <summary>
        /// The name of summoner.
        /// </summary>
        public string Name { get; init; } = default!;
        /// <summary>
        /// The encrypted summoner ID.
        /// </summary>
        public string Id { get; init; } = default!;
        /// <summary>
        /// The encrypted PUUID.
        /// </summary>
        public string Puuid { get; init; } = default!;
        /// <summary>
        /// The summoner level associated with summoner.
        /// </summary>
        public long SummonerLevel { get; init; }
    }
}
