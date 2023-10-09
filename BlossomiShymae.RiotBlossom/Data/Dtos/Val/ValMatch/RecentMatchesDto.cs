using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record RecentMatchesDto : DataObject
    {
        public long CurrentTime { get; init; }
        public List<string> MatchIds { get; init; } = [];
    }
}
