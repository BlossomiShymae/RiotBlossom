using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.Spectator
{
    public record FeaturedGames
    {
        /// <summary>
        /// The list of featured games.
        /// </summary>
        public ImmutableList<FeaturedGameInfo> GameList { get; init; } = ImmutableList<FeaturedGameInfo>.Empty;
        /// <summary>
        /// The suggested interval to wait before making another request for refreshing.
        /// </summary>
        public long ClientRefreshInterval { get; init; }
    }
}
