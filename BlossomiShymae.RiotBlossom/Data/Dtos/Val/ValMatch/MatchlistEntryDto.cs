namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record MatchlistEntryDto : DataObject
    {
        public required string MatchId { get; init; } 
        public long GameStartTimeMillis { get; init; }
        public required string QueueId { get; init; }
    }
}
