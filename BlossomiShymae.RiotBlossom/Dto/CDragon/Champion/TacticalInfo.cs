namespace BlossomiShymae.RiotBlossom.Dto.CDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record TacticalInfo
    {
        public int Style { get; init; }
        public int Difficulty { get; init; }
        public string DamageType { get; init; } = default!;
    }
}
