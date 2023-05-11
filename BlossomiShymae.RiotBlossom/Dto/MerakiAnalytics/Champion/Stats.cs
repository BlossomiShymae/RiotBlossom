using BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Common;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Stats
    {
        public Stat Health { get; set; } = new();
        public Stat HealthRegen { get; set; } = new();
        public Stat Mana { get; set; } = new();
        public Stat ManaRegen { get; set; } = new();
        public Stat Armor { get; set; } = new();
        public Stat MagicResistance { get; set; } = new();
        public Stat AttackDamage { get; set; } = new();
        public Stat Movespeed { get; set; } = new();
        public Stat AcquisitionRadius { get; set; } = new();
        public Stat SelectionRadius { get; set; } = new();
        public Stat PathingRadius { get; set; } = new();
        public Stat GameplayRadius { get; set; } = new();
        public Stat CriticalStrikeDamage { get; set; } = new();
        public Stat CriticalStrikeDamageModifier { get; set; } = new();
        public Stat AttackSpeed { get; set; } = new();
        public Stat AttackSpeedRatio { get; set; } = new();
        public Stat AttackCastTime { get; set; } = new();
        public Stat AttackTotalTime { get; set; } = new();
        public Stat AttackDelayOffset { get; set; } = new();
        public Stat AttackRange { get; set; } = new();
        public Stat AramDamageTaken { get; set; } = new();
        public Stat AramDamageDealt { get; set; } = new();
        public Stat AramHealing { get; set; } = new();
        public Stat AramShielding { get; set; } = new();
        public Stat UrfDamageTaken { get; set; } = new();
        public Stat UrfDamageDealt { get; set; } = new();
        public Stat UrfHealing { get; set; } = new();
        public Stat UrfShielding { get; set; } = new();
    }
}
