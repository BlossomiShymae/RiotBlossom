using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Chroma : DataObject
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public required string ChromaPath { get; init; } 
        public List<string> Colors { get; init; } = [];
        public List<ChromaDescription> Descriptions { get; init; } = [];
        public List<ChromaRarity> Rarities { get; init; } = [];
    }
}
