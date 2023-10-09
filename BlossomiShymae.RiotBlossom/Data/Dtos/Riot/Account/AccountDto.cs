namespace BlossomiShymae.RiotBlossom.Data.Dtos.Riot.Account
{
    public record AccountDto : DataObject
    {
        /// <summary>
        /// The player UUID associated with account.
        /// </summary>
        public required string Puuid { get; init; }
        /// <summary>
        /// The Riot game name associated with account. May be excluded from response if account does not have it.
        /// </summary>
        public string? GameName { get; init; }
        /// <summary>
        /// The Riot tag line associated with account. May be excluded from response if account does not have it.
        /// </summary>
        public string? TagLine { get; init; }
    }
}
