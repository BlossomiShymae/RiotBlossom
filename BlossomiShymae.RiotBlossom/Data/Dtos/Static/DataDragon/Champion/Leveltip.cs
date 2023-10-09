using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Leveltip : DataObject
    {
        public List<string> Label { get; init; } = [];
        public List<string> Effect { get; init; } = [];
    }
}
