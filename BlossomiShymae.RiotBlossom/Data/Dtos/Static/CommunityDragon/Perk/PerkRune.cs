using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Perk
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record PerkRune : DataObject
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public required string MajorChangePatchVersion { get; init; } 
        public required string Tooltip { get; init; }
        public required string ShortDesc { get; init; } 
        public required string LongDesc { get; init; } 
        public required string RecommendationDescriptor { get; init; } 
        public required string IconPath { get; init; } 
        public List<string> EndOfGameStatDescs { get; init; } = [];
        public Dictionary<string, double> RecommendationDescriptorAttributes { get; init; } = [];
    }
}
