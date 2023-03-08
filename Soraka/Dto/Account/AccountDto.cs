namespace Soraka.Dto.Account
{
    internal record AccountDto
    {
        public string Puuid { get; init; } = default!;
        public string GameName { get; init; } = default!;
        public string TagLine { get; init; } = default!;
    }
}
