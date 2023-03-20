namespace Gwen.Dto.Riot.Match
{
    public record Event
    {
        public long RealTimestamp { get; init; }
        public long Timestamp { get; init; }
        public string Type { get; init; } = default!;
    }
}
