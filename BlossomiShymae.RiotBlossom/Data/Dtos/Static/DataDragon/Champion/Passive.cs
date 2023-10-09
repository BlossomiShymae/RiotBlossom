namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Passive : DataObject
    {
        public required string Name { get; init; } 
        public required string Description { get; init; }
        public required Image Image { get; init; }
    }
}
