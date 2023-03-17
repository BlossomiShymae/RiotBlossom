namespace Gwen.Dto.Riot.Match
{
    /// <summary>
    /// UNDOCUMENTED - this Dto type may change at any time. owo
    /// </summary>
    public record ChampionStatsDto
    {
        public int AbilityHaste { get; init; }
        public int AbilityPower { get; init; }
        public int Armor { get; init; }
        public int ArmorPen { get; init; }
        public int ArmorPenPercent { get; init; }
        public int AttackDamage { get; init; }
        public int AttackSpeed { get; init; }
        public int BonusArmorPenPercent { get; init; }
        public int BonusMagicPenPercent { get; init; }
        public int CCReduction { get; init; }
        public int CooldownReduction { get; init; }
        public int Health { get; init; }
        public int HealthMax { get; init; }
        public int HealthRegen { get; init; }
        public int Lifesteal { get; init; }
        public int MagicPen { get; init; }
        public int MagicPenPercent { get; init; }
        public int MagicResist { get; init; }
        public int MovementSpeed { get; init; }
        public int Omnivamp { get; init; }
        public int PhysicalVamp { get; init; }
        public int Power { get; init; }
        public int PowerMax { get; init; }
        public int PowerRegen { get; init; }
        public int SpellVamp { get; init; }
    }
}
