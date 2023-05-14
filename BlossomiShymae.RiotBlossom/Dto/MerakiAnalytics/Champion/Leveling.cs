using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Leveling : DataObject<Leveling>
    {
        public string? Attribute { get; init; }
        public ImmutableList<Modifier> Modifiers { get; init; } = ImmutableList<Modifier>.Empty;
    }
}
