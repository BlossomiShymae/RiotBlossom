namespace BlossomiShymae.RiotBlossom.Dto.Riot.Match
{
    public record Event : DataObject
    {
        public long RealTimestamp { get; init; }
        public long Timestamp { get; init; }
        public string Type { get; init; } = default!;
    }
}
