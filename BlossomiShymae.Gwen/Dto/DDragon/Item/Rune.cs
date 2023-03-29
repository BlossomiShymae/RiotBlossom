namespace BlossomiShymae.Gwen.Dto.DDragon.Item
{
    public record Rune
    {
        public bool IsRune { get; init; }
        public int Tier { get; init; }
        public string Type { get; init; } = default!;
    }
}
