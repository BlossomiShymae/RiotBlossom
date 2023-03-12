using System.Collections.Immutable;

namespace Gwen.Dto.Spectator
{
    internal record FeaturedGames
    {
        public ImmutableList<FeaturedGameInfo> GameList { get; init; } = ImmutableList<FeaturedGameInfo>.Empty;
        public long ClientRefreshInterval { get; init; }
    }
}
