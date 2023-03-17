using System.Collections.Immutable;

namespace Gwen.Dto.CDragon
{
	public record Skin
	{
		public int Id { get; init; }
		public bool IsBase { get; init; }
		public string Name { get; init; } = default!;
		public string SplashPath { get; init; } = default!;
		public string UncenteredSplashPath { get; init; } = default!;
		public string TilePath { get; init; } = default!;
		public string LoadScreenPath { get; init; } = default!;
		public string SkinType { get; init; } = default!;
		public string Rarity { get; init; } = default!;
		public bool IsLegacy { get; init; }
		public string? SplashVideoPath { get; init; }
		public string? CollectionSplashVideoPath { get; init; }
		public string? FeaturesText { get; init; }
		public string? ChromaPath { get; init; }
		public ImmutableList<Chroma>? Chromas { get; init; }
		public object? Emblems { get; init; }
		public int RegionRarityId { get; init; }
		public string? RarityGemPath { get; init; }
		public ImmutableList<SkinLine>? SkinLines { get; init; }
		public string Description { get; init; } = default!;
	}
}
