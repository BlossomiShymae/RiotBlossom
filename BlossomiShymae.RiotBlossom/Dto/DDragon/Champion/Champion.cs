using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.DDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Champion
    {
        public string Id { get; init; } = default!;
        public string Key { get; init; } = default!;
        public string Name { get; init; } = default!;
        public string Title { get; init; } = default!;
        public Image Image { get; init; } = new();
        public ImmutableList<Skin> Skins { get; init; } = ImmutableList<Skin>.Empty;
        public string Lore { get; init; } = default!;
        public string Blurb { get; init; } = default!;
        public ImmutableList<string> Allytips { get; init; } = ImmutableList<string>.Empty;
        public ImmutableList<string> Enemytips { get; init; } = ImmutableList<string>.Empty;
        public ImmutableList<string> Tags { get; init; } = ImmutableList<string>.Empty;
        public string Partype { get; init; } = default!;
        public Info Info { get; init; } = new();
        public Stats Stats { get; init; } = new();
        public ImmutableList<Spell> Spells { get; init; } = ImmutableList<Spell>.Empty;
        public Passive Passive { get; init; } = new();
        public object? Recommended { get; init; }
    }
}
