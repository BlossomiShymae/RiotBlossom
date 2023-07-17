namespace BlossomiShymae.RiotBlossom.Dto.DataDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Skin : DataObject
    {
        public string Id { get; init; } = default!;
        public int Num { get; init; }
        public string Name { get; init; } = default!;
        public bool Chromas { get; init; }
    }
}
