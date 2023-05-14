using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Common;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Stats
    {
        public Stat AbilityPower { get; init; } = new();
        public Stat Armor { get; init; } = new();
        public Stat ArmorPenetration { get; init; } = new();
        public Stat AttackDamage { get; init; } = new();
        public Stat AttackSpeed { get; init; } = new();
        public Stat CooldownReduction { get; init; } = new();
        public Stat CriticalStrikeChance { get; init; } = new();
        public Stat GoldPer10 { get; init; } = new();
        public Stat HealAndShieldPower { get; init; } = new();
        public Stat Health { get; init; } = new();
        public Stat HealthRegen { get; init; } = new();
        public Stat Lethality { get; init; } = new();
        public Stat Lifesteal { get; init; } = new();
        public Stat MagicPenetration { get; init; } = new();
        public Stat MagicResistance { get; init; } = new();
        public Stat Mana { get; init; } = new();
        public Stat ManaRegen { get; init; } = new();
        public Stat Movespeed { get; init; } = new();
        public Stat AbilityHaste { get; init; } = new();
        public Stat Omnivamp { get; init; } = new();
        public Stat Tenacity { get; init; } = new();

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
