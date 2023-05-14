namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record LocationDto : DataObject<LocationDto>
    {
        public int X { get; init; }
        public int Y { get; init; }
    }
}
