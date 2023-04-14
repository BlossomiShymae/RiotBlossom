using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.DataDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Spell
    {
        public string Id { get; init; } = default!;
        public string Name { get; init; } = default!;
        public string Description { get; init; } = default!;
        public string Tooltip { get; init; } = default!;
        public Leveltip Leveltip { get; init; } = new();
        public int Maxrank { get; init; }
        public ImmutableList<double> Cooldown { get; init; } = ImmutableList<double>.Empty;
        public string CooldownBurn { get; init; } = default!;
        public ImmutableList<int> Cost { get; init; } = ImmutableList<int>.Empty;
        public string CostBurn { get; init; } = default!;
        public object? DataValues { get; init; }
        public object? Effect { get; init; }
        public object? EffectBurn { get; init; }
        public object? Vars { get; init; }
        public string CostType { get; init; } = default!;
        public string Maxammo { get; init; } = default!;
        public ImmutableList<int> Range { get; init; } = ImmutableList<int>.Empty;
        public string RangeBurn { get; init; } = default!;
        public Image Image { get; init; } = new();
        public string Resource { get; init; } = default!;
    }
}
