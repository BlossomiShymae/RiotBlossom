namespace BlossomiShymae.Gwen.Dto.CDragon.Champion
{
    public record PlaystyleInfo
    {
        public int Damage { get; init; }
        public int Durability { get; init; }
        public int CrowdControl { get; init; }
        public int Mobility { get; init; }
        public int Utility { get; init; }
    }
}
