using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Chroma : DataObject
    {
        public string? Name { get; init; }
        public long Id { get; init; }
        public string? ChromaPath { get; init; }
        public ImmutableList<string> Colors { get; init; } = ImmutableList<string>.Empty;
        public ImmutableList<DescriptionDto> Descriptions { get; init; } = ImmutableList<DescriptionDto>.Empty;
        public ImmutableList<Rarities> Rarities { get; init; } = ImmutableList<Rarities>.Empty;
    }
}
