namespace BlossomiShymae.RiotBlossom.Dto.DDragon.Champion
{
    public record Passive
    {
        public string Name { get; init; } = default!;
        public string Description { get; init; } = default!;
        public Image Image { get; init; } = new();
    }
}
