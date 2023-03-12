using System.Collections.Immutable;

namespace Gwen.Dto.Champion
{
    internal record ChampionInfo
    {
        public int MaxNewPlayerLevel { get; init; }
        public ImmutableList<int> FreeChampionIdsForNewPlayers { get; init; } = ImmutableList<int>.Empty;
        public ImmutableList<int> FreeChampionIds { get; init; } = ImmutableList<int>.Empty;
    }
}
