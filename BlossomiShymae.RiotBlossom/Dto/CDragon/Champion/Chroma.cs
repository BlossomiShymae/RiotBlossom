using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.CDragon.Champion
{
    public record Chroma
    {
        public int Id { get; init; }
        public string Name { get; init; } = default!;
        public string ChromaPath { get; init; } = default!;
        public ImmutableList<string> Colors { get; init; } = ImmutableList<string>.Empty;
        public ImmutableList<ChromaDescription> Descriptions { get; init; } = ImmutableList<ChromaDescription>.Empty;
        public ImmutableList<ChromaRarity> Rarities { get; init; } = ImmutableList<ChromaRarity>.Empty;
    }
}
