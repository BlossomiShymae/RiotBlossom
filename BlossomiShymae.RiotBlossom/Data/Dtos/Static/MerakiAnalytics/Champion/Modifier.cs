using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Modifier : DataObject
    {
        public List<double> Values { get; init; } = [];
        public List<string> Units { get; init; } = [];
    }
}
