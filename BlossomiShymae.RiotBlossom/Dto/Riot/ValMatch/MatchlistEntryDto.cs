namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record MatchlistEntryDto : DataObject<MatchlistEntryDto>
    {
        public string MatchId { get; init; } = default!;
        public long GameStartTimeMillis { get; init; }
        public string QueueId { get; init; } = default!;
    }
}
