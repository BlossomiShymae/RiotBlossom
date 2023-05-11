using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Chroma
    {
        public string? Name { get; set; }
        public long Id { get; set; }
        public string? ChromaPath { get; set; }
        public ImmutableList<string> Colors { get; set; } = ImmutableList<string>.Empty;
        public ImmutableList<DescriptionDto> Descriptions { get; set; } = ImmutableList<DescriptionDto>.Empty;
        public ImmutableList<Rarities> Rarities { get; set; } = ImmutableList<Rarities>.Empty;
    }
}
