using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Modifier : DataObject
    {
        public ImmutableList<double> Values { get; init; } = ImmutableList<double>.Empty;
        public ImmutableList<string> Units { get; init; } = ImmutableList<string>.Empty;
    }
}
