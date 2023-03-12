using System.Collections.Immutable;

namespace Gwen.Dto.Spectator
{
    internal record Perks
    {
        public ImmutableList<long> PerkIds { get; init; } = ImmutableList<long>.Empty;
        public long PerkStyle { get; init; }
        public long PerkSubStyle { get; init; }
    }
}
