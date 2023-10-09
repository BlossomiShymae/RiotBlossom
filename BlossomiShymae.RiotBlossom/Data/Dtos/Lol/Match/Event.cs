namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match
{
    public record Event : DataObject
    {
        public long RealTimestamp { get; init; }
        public long Timestamp { get; init; }
        public required string Type { get; init; } 
    }
}
