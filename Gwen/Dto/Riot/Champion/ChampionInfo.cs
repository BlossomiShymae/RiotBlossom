using System.Collections.Immutable;

namespace Gwen.Dto.Riot.Champion
{
    public record ChampionInfo
    {
        /// <summary>
        /// The maximum level the new player champion rotation is available before unlocking the 
        /// regular champion rotation.
        /// </summary>
        public int MaxNewPlayerLevel { get; init; }
        /// <summary>
        /// The current free champion rotation pool for new players. See <see cref="MaxNewPlayerLevel"/>.
        /// </summary>
        public ImmutableList<int> FreeChampionIdsForNewPlayers { get; init; } = ImmutableList<int>.Empty;
        /// <summary>
        /// The current free champion rotation pool.
        /// </summary>
        public ImmutableList<int> FreeChampionIds { get; init; } = ImmutableList<int>.Empty;
    }
}
