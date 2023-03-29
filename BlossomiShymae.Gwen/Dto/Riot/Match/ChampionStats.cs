namespace BlossomiShymae.Gwen.Dto.Riot.Match
{
    /// <summary>
    /// UNDOCUMENTED - this Dto type may change at any time. owo
    /// </summary>
    public record ChampionStats
    {
        public double AbilityHaste { get; init; }
        public double AbilityPower { get; init; }
        public double Armor { get; init; }
        public double ArmorPen { get; init; }
        public double ArmorPenPercent { get; init; }
        public double AttackDamage { get; init; }
        public double AttackSpeed { get; init; }
        public double BonusArmorPenPercent { get; init; }
        public double BonusMagicPenPercent { get; init; }
        public double CCReduction { get; init; }
        public double CooldownReduction { get; init; }
        public double Health { get; init; }
        public double HealthMax { get; init; }
        public double HealthRegen { get; init; }
        public double Lifesteal { get; init; }
        public double MagicPen { get; init; }
        public double MagicPenPercent { get; init; }
        public double MagicResist { get; init; }
        public double MovementSpeed { get; init; }
        public double Omnivamp { get; init; }
        public double PhysicalVamp { get; init; }
        public double Power { get; init; }
        public double PowerMax { get; init; }
        public double PowerRegen { get; init; }
        public double SpellVamp { get; init; }
    }
}
