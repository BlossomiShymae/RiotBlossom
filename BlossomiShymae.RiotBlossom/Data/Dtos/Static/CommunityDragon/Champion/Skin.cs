using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Skin : DataObject
    {
        public int Id { get; init; }
        public bool IsBase { get; init; }
        public required string Name { get; init; }
        public required string SplashPath { get; init; }
        public required string UncenteredSplashPath { get; init; } 
        public required string TilePath { get; init; } 
        public required string LoadScreenPath { get; init; } 
        public required string SkinType { get; init; } 
        public required string Rarity { get; init; } 
        public bool IsLegacy { get; init; }
        public string? SplashVideoPath { get; init; }
        public string? CollectionSplashVideoPath { get; init; }
        public string? FeaturesText { get; init; }
        public string? ChromaPath { get; init; }
        public List<Chroma>? Chromas { get; init; }
        public int RegionRarityId { get; init; }
        public string? RarityGemPath { get; init; }
        public List<SkinLine>? SkinLines { get; init; }
        public required string Description { get; init; }
    }
}
