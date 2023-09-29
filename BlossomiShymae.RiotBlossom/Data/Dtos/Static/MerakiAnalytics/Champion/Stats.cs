using BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Common;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Stats : DataObject
    {
        public Stat Health { get; init; } = new();
        public Stat HealthRegen { get; init; } = new();
        public Stat Mana { get; init; } = new();
        public Stat ManaRegen { get; init; } = new();
        public Stat Armor { get; init; } = new();
        public Stat MagicResistance { get; init; } = new();
        public Stat AttackDamage { get; init; } = new();
        public Stat Movespeed { get; init; } = new();
        public Stat AcquisitionRadius { get; init; } = new();
        public Stat SelectionRadius { get; init; } = new();
        public Stat PathingRadius { get; init; } = new();
        public Stat GameplayRadius { get; init; } = new();
        public Stat CriticalStrikeDamage { get; init; } = new();
        public Stat CriticalStrikeDamageModifier { get; init; } = new();
        public Stat AttackSpeed { get; init; } = new();
        public Stat AttackSpeedRatio { get; init; } = new();
        public Stat AttackCastTime { get; init; } = new();
        public Stat AttackTotalTime { get; init; } = new();
        public Stat AttackDelayOffset { get; init; } = new();
        public Stat AttackRange { get; init; } = new();
        public Stat AramDamageTaken { get; init; } = new();
        public Stat AramDamageDealt { get; init; } = new();
        public Stat AramHealing { get; init; } = new();
        public Stat AramShielding { get; init; } = new();
        public Stat UrfDamageTaken { get; init; } = new();
        public Stat UrfDamageDealt { get; init; } = new();
        public Stat UrfHealing { get; init; } = new();
        public Stat UrfShielding { get; init; } = new();
    }
}
