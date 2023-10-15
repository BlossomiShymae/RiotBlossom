namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Summoner
{
    public record SummonerDto : DataObject
    {
        /// <summary>
        /// The encrypted account ID.
        /// </summary>
        public required string AccountId { get; init; }
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
        public required string Name { get; init; }
        /// <summary>
        /// The encrypted summoner ID.
        /// </summary>
        public required string Id { get; init; }
        /// <summary>
        /// The encrypted PUUID.
        /// </summary>
        public required string Puuid { get; init; }
        /// <summary>
        /// The summoner level associated with summoner.
        /// </summary>
        public long SummonerLevel { get; init; }
    }
}
