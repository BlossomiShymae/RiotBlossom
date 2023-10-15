using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Chroma : DataObject
    {
        public string? Name { get; init; }
        public long Id { get; init; }
        public string? ChromaPath { get; init; }
        public List<string> Colors { get; init; } = [];
        public List<DescriptionDto> Descriptions { get; init; } = [];
        public List<Rarities> Rarities { get; init; } = [];
    }
}
