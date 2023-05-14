namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record PlayerLocationsDto : DataObject<PlayerLocationsDto>
    {
        public string Puuid { get; init; } = default!;
        public float ViewRadians { get; init; }
        public LocationDto Location { get; init; } = new();
    }
}
