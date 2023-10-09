using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Spell : DataObject
    {
        public required string Id { get; init; } 
        public required string Name { get; init; } 
        public required string Description { get; init; } 
        public required string Tooltip { get; init; } 
        public Leveltip Leveltip { get; init; } = new();
        public int Maxrank { get; init; }
        public List<double> Cooldown { get; init; } = [];
        public required string CooldownBurn { get; init; } 
        public List<int> Cost { get; init; } = [];
        public required string CostBurn { get; init; }
        public required string CostType { get; init; }
        public required string Maxammo { get; init; } 
        public List<int> Range { get; init; } = [];
        public required string RangeBurn { get; init; }
        public required Image Image { get; init; }
        public required string Resource { get; init; } 
    }
}
