namespace BlossomiShymae.RiotBlossom.Dto.DDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Passive
    {
        public string Name { get; init; } = default!;
        public string Description { get; init; } = default!;
        public Image Image { get; init; } = new();
    }
}
