namespace BlossomiShymae.Gwen.Dto.CDragon.Champion
{
    public record TacticalInfo
    {
        public int Style { get; init; }
        public int Difficulty { get; init; }
        public string DamageType { get; init; } = default!;
    }
}
