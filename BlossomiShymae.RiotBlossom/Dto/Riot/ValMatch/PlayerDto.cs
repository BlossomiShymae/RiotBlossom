namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record PlayerDto
    {
        public string Puuid { get; init; } = default!;
        public string GameName { get; init; } = default!;
        public string TagLine { get; init; } = default!;
        public string TeamId { get; init; } = default!;
        public string PartyId { get; init; } = default!;
        public string CharacterId { get; init; } = default!;
        public PlayerStatsDto Stats { get; init; } = new();
        public int CompetitiveTier { get; init; }
        public string PlayerCard { get; init; } = default!;
        public string PlayerTitle { get; init; } = default!;
    }
}
