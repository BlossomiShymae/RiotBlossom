namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Image : DataObject
    {
        public required string Full { get; init; }
        public required string Sprite { get; init; } 
        public required string Group { get; init; } 
        public int X { get; init; }
        public int Y { get; init; }
        public int W { get; init; }
        public int H { get; init; }
    }
}
