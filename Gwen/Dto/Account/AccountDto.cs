namespace Gwen.Dto.Account
{
    public record AccountDto
    {
        /// <summary>
        /// The player UUID associated with account.
        /// </summary>
        public string Puuid { get; init; } = default!;
        /// <summary>
        /// The Riot game name associated with account. May be excluded from response if account does not have it..
        /// </summary>
        public string GameName { get; init; } = default!;
        /// <summary>
        /// The Riot tag line associated with account. May be excluded from response if account does not have it.
        /// </summary>
        public string TagLine { get; init; } = default!;
    }
}
