using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Cooldown : DataObject<Cooldown>
    {
        public ImmutableList<Modifier> Modifiers { get; init; } = ImmutableList<Modifier>.Empty;
        public bool AffectedByCdr { get; init; }
    }
}
