using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record RecentMatchesDto : DataObject
    {
        public long CurrentTime { get; init; }
        public ImmutableList<string> MatchIds { get; init; } = ImmutableList<string>.Empty;
    }
}
