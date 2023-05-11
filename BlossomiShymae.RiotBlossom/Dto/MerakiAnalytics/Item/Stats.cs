using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Common;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Stats
    {
        public Stat AbilityPower { get; set; } = new();
        public Stat Armor { get; set; } = new();
        public Stat ArmorPenetration { get; set; } = new();
        public Stat AttackDamage { get; set; } = new();
        public Stat AttackSpeed { get; set; } = new();
        public Stat CooldownReduction { get; set; } = new();
        public Stat CriticalStrikeChance { get; set; } = new();
        public Stat GoldPer10 { get; set; } = new();
        public Stat HealAndShieldPower { get; set; } = new();
        public Stat Health { get; set; } = new();
        public Stat HealthRegen { get; set; } = new();
        public Stat Lethality { get; set; } = new();
        public Stat Lifesteal { get; set; } = new();
        public Stat MagicPenetration { get; set; } = new();
        public Stat MagicResistance { get; set; } = new();
        public Stat Mana { get; set; } = new();
        public Stat ManaRegen { get; set; } = new();
        public Stat Movespeed { get; set; } = new();
        public Stat AbilityHaste { get; set; } = new();
        public Stat Omnivamp { get; set; } = new();
        public Stat Tenacity { get; set; } = new();

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
