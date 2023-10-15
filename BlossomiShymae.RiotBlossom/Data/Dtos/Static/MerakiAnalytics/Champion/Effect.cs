using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Effect : DataObject
    {
        public string? Description { get; init; }
        public List<Leveling> Leveling { get; init; } = [];
    }
}
