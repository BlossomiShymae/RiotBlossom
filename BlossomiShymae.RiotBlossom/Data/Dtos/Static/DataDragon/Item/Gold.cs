namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Gold : DataObject
    {
        public int Base { get; init; }
        public int Total { get; init; }
        public int Sell { get; init; }
        public bool Purchasable { get; init; }
    }
}
