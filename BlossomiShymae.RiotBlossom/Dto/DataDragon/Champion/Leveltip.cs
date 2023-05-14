using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.DataDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Leveltip : DataObject<Leveltip>
    {
        public ImmutableList<string> Label { get; init; } = ImmutableList<string>.Empty;
        public ImmutableList<string> Effect { get; init; } = ImmutableList<string>.Empty;
    }
}
