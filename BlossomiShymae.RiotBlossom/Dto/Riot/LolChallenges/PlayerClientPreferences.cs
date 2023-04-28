using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LolChallenges
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record PlayerClientPreferences
    {
        public string BannerAccent { get; init; } = default!;
        public string Title { get; init; } = default!;
        public ImmutableList<int> ChallengeIds { get; init; } = ImmutableList<int>.Empty;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
