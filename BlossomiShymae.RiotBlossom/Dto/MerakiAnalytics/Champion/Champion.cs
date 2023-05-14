using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Champion : DataObject<Champion>
    {
        public int Id { get; init; }
        public string? Key { get; init; }
        public string? Name { get; init; }
        public string? Title { get; init; }
        public string? FullName { get; init; }
        public string? Icon { get; init; }
        public string? Resource { get; init; }
        public string? AttackType { get; init; }
        public string? DamageType { get; init; }
        public Stats Stats { get; init; } = new();
        public ImmutableList<string> Roles { get; init; } = ImmutableList<string>.Empty;
        public AttributeRatings AttributeRatings { get; init; } = new();
        public ImmutableDictionary<string, ImmutableList<Ability>> Abilities { get; init; } = ImmutableDictionary<string, ImmutableList<Ability>>.Empty;
        public string? ReleaseDate { get; init; }
        public string? ReleasePatch { get; init; }
        public string? PatchLastChanged { get; init; }
        public Price Price { get; init; } = new();
        public string? Lore { get; init; }
        public string? Faction { get; init; }
        public ImmutableList<Skin> Skins { get; init; } = ImmutableList<Skin>.Empty;
    }
}
