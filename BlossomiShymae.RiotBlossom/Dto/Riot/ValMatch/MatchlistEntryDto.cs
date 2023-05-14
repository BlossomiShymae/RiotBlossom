using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record MatchlistEntryDto
    {
        public string MatchId { get; init; } = default!;
        public long GameStartTimeMillis { get; init; }
        public string QueueId { get; init; } = default!;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
