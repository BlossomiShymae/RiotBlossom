using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Modifier
    {
        public ImmutableList<double> Values { get; set; } = ImmutableList<double>.Empty;
        public ImmutableList<string> Units { get; set; } = ImmutableList<string>.Empty;
    }
}
