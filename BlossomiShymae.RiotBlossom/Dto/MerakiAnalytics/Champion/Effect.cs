using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Effect : DataObject<Effect>
    {
        public string? Description { get; init; }
        public ImmutableList<Leveling> Leveling { get; init; } = ImmutableList<Leveling>.Empty;
    }
}
