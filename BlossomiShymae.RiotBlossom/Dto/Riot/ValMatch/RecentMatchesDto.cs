using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record RecentMatchesDto
    {
        public long CurrentTime { get; init; }
        public ImmutableList<string> MatchIds { get; init; } = ImmutableList<string>.Empty;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
