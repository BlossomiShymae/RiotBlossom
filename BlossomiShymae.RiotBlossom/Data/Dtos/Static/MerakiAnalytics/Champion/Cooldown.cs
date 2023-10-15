using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Cooldown : DataObject
    {
        public List<Modifier> Modifiers { get; init; } = [];
        public bool AffectedByCdr { get; init; }
    }
}
