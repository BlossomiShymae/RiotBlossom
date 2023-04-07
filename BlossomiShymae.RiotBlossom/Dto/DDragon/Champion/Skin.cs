namespace BlossomiShymae.RiotBlossom.Dto.DDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Skin
    {
        public string Id { get; init; } = default!;
        public int Num { get; init; }
        public string Name { get; init; } = default!;
        public bool Chromas { get; init; }
    }
}
