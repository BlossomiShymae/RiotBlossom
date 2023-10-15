namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Skin : DataObject
    {
        public required string Id { get; init; } 
        public int Num { get; init; }
        public required string Name { get; init; } 
        public bool Chromas { get; init; }
    }
}
