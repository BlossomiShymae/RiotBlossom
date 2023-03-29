using System.Collections.Immutable;

namespace BlossomiShymae.Gwen.Dto.Riot.LolChallenges
{
    public record PlayerClientPreferences
    {
        public string BannerAccent { get; init; } = default!;
        public string Title { get; init; } = default!;
        public ImmutableList<int> ChallengeIds { get; init; } = ImmutableList<int>.Empty;
    }
}
