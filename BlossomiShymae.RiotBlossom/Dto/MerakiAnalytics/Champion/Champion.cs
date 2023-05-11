using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Champion
    {
        public int Id { get; set; }
        public string? Key { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? FullName { get; set; }
        public string? Icon { get; set; }
        public string? Resource { get; set; }
        public string? AttackType { get; set; }
        public string? DamageType { get; set; }
        public Stats Stats { get; set; } = new();
        public ImmutableList<string> Roles { get; set; } = ImmutableList<string>.Empty;
        public AttributeRatings AttributeRatings { get; set; } = new();
        public ImmutableDictionary<string, ImmutableList<Ability>> Abilities { get; set; } = ImmutableDictionary<string, ImmutableList<Ability>>.Empty;
        public string? ReleaseDate { get; set; }
        public string? ReleasePatch { get; set; }
        public string? PatchLastChanged { get; set; }
        public Price Price { get; set; } = new();
        public string? Lore { get; set; }
        public string? Faction { get; set; }
        public ImmutableList<Skin> Skins { get; set; } = ImmutableList<Skin>.Empty;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
