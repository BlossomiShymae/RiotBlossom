using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Ability
    {
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public ImmutableList<Effect> Effects { get; set; } = ImmutableList<Effect>.Empty;
        public Cost Cost { get; set; } = new();
        public Cooldown Cooldown { get; set; } = new();
        public string? Targeting { get; set; }
        public string? Affects { get; set; }
        public string? Spellshieldable { get; set; }
        public string? Resource { get; set; }
        public string? DamageType { get; set; }
        public string? SpellEffects { get; set; }
        public string? Projectile { get; set; }
        public string? OnHitEffects { get; set; }
        public string? Occurrence { get; set; }
        public string? Notes { get; set; }
        public string? Blurb { get; set; }
        public string? MissileSpeed { get; set; }
        public string? RechargeRate { get; set; }
        public string? CollisionRadius { get; set; }
        public string? TetherRadius { get; set; }
        public string? OnTargetCdStatic { get; set; }
        public string? InnerRadius { get; set; }
        public string? Speed { get; set; }
        public string? Width { get; set; }
        public string? Angle { get; set; }
        public string? CastTime { get; set; }
        public string? EffectRadius { get; set; }
        public string? TargetRange { get; set; }
    }
}
