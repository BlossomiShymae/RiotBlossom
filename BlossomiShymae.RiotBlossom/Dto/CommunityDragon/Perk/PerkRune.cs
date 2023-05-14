using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Perk
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record PerkRune : DataObject<PerkRune>
    {
        public int Id { get; init; }
        public string Name { get; init; } = default!;
        public string MajorChangePatchVersion { get; init; } = default!;
        public string Tooltip { get; init; } = default!;
        public string ShortDesc { get; init; } = default!;
        public string LongDesc { get; init; } = default!;
        public string RecommendationDescriptor { get; init; } = default!;
        public string IconPath { get; init; } = default!;
        public ImmutableList<string> EndOfGameStatDescs { get; init; } = ImmutableList<string>.Empty;
        public ImmutableDictionary<string, double> RecommendationDescriptorAttributes { get; init; } = ImmutableDictionary<string, double>.Empty;
    }
}
