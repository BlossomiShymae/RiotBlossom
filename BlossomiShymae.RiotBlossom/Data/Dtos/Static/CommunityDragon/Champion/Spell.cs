using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Spell : DataObject
    {
        public required string SpellKey { get; init; } 
        public required string Name { get; init; }
        public required string AbilityIconPath { get; init; } 
        public required string AbilityVideoPath { get; init; } 
        public required string Cost { get; init; } 
        public required string Cooldown { get; init; } 
        public required string Description { get; init; }
        public required string DynamicDescription { get; init; } 
        public List<double> Range { get; init; } = [];
        public List<double> CostCoefficients { get; init; } = [];
        public List<double> CooldownCoefficients { get; init; } = [];
        public int MaxLevel { get; init; }
    }
}
