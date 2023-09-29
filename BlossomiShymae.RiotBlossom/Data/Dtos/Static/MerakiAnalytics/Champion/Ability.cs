using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Ability : DataObject
    {
        public string? Name { get; init; }
        public string? Icon { get; init; }
        public ImmutableList<Effect> Effects { get; init; } = ImmutableList<Effect>.Empty;
        public Cost Cost { get; init; } = new();
        public Cooldown Cooldown { get; init; } = new();
        public string? Targeting { get; init; }
        public string? Affects { get; init; }
        public string? Spellshieldable { get; init; }
        public string? Resource { get; init; }
        public string? DamageType { get; init; }
        public string? SpellEffects { get; init; }
        public string? Projectile { get; init; }
        public string? OnHitEffects { get; init; }
        public string? Occurrence { get; init; }
        public string? Notes { get; init; }
        public string? Blurb { get; init; }
        public string? MissileSpeed { get; init; }
        public ImmutableList<double> RechargeRate { get; init; } = ImmutableList<double>.Empty;
        public string? CollisionRadius { get; init; }
        public string? TetherRadius { get; init; }
        public string? OnTargetCdStatic { get; init; }
        public string? InnerRadius { get; init; }
        public string? Speed { get; init; }
        public string? Width { get; init; }
        public string? Angle { get; init; }
        public string? CastTime { get; init; }
        public string? EffectRadius { get; init; }
        public string? TargetRange { get; init; }
    }
}
