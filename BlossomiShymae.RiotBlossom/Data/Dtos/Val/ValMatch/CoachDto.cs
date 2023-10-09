namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record CoachDto : DataObject
    {
        public required string Puuid { get; init; }
        public required string TeamId { get; init; }
    }
}
