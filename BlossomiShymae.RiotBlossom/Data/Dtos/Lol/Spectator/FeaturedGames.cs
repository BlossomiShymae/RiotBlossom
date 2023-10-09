using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Spectator
{
    public record FeaturedGames : DataObject
    {
        /// <summary>
        /// The list of featured games.
        /// </summary>
        public List<FeaturedGameInfo> GameList { get; init; } = [];
        /// <summary>
        /// The suggested interval to wait before making another request for refreshing.
        /// </summary>
        public long ClientRefreshInterval { get; init; }
    }
}
