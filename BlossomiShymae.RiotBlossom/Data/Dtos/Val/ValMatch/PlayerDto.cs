namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record PlayerDto : DataObject
    {
        public required string Puuid { get; init; } 
        public required string GameName { get; init; } 
        public required string TagLine { get; init; }
        public required string TeamId { get; init; } 
        public required string PartyId { get; init; } 
        public required string CharacterId { get; init; } 
        public PlayerStatsDto Stats { get; init; } = new();
        public int CompetitiveTier { get; init; }
        public required string PlayerCard { get; init; } 
        public required string PlayerTitle { get; init; }
    }
}
