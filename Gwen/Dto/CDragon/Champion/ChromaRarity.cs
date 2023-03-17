namespace Gwen.Dto.CDragon.Champion
{
    public record ChromaRarity
    {
        public string Region { get; init; } = default!;
        public int Rarity { get; init; }
    }
}
