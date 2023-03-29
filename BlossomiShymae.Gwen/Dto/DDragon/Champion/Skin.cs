namespace BlossomiShymae.Gwen.Dto.DDragon.Champion
{
    public record Skin
    {
        public string Id { get; init; } = default!;
        public int Num { get; init; }
        public string Name { get; init; } = default!;
        public bool Chromas { get; init; }
    }
}
