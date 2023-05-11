using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Effect
    {
        public string? Description { get; set; }
        public ImmutableList<Leveling> Leveling { get; set; } = ImmutableList<Leveling>.Empty;
    }
}
