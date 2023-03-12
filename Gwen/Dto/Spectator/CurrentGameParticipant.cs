using System.Collections.Immutable;

namespace Gwen.Dto.Spectator
{
    internal class CurrentGameParticipant
    {
        public long ChampionId { get; init; }
        public Perks Perks { get; init; } = new();
        public long ProfileIconId { get; init; }
        public bool Bot { get; init; }
        public long TeamId { get; init; }
        public string SummonerName { get; init; } = default!;
        public string SummonerId { get; init; } = default!;
        public long Spell1Id { get; init; }
        public long Spell2Id { get; init; }
        public ImmutableList<GameCustomizationObject> GameCustomizationObjects { get; init; } = ImmutableList<GameCustomizationObject>.Empty;
    }
}
