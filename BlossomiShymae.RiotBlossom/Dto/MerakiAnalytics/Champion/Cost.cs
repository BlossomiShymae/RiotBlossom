using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Cost : DataObject<Cost>
    {
        public ImmutableList<Modifier> Modifiers { get; init; } = ImmutableList<Modifier>.Empty;
    }
}
