namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record PlayerLocationsDto : DataObject
    {
        public required string Puuid { get; init; } 
        public float ViewRadians { get; init; }
        public LocationDto Location { get; init; } = new();
    }
}
