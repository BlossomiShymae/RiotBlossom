namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Info : DataObject
    {
        public int Attack { get; init; }
        public int Defense { get; init; }
        public int Magic { get; init; }
        public int Difficulty { get; init; }
    }
}
