using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Leveling : DataObject
    {
        public string? Attribute { get; init; }
        public List<Modifier> Modifiers { get; init; } = [];
    }
}
