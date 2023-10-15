namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record MatchInfoDto : DataObject
    {
        public required string MatchId { get; init; } 
        public required string MapId { get; init; } 
        public int GameLengthMillis { get; init; }
        public long GameStartMillis { get; init; }
        public required string ProvisioningFlowId { get; init; } 
        public bool IsCompleted { get; init; }
        public required string CustomGameName { get; init; } 
        public required string QueueId { get; init; } 
        public required string GameMode { get; init; }
        public bool IsRanked { get; init; }
        public required string SeasonId { get; init; } 
    }
}
