namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Price : DataObject
    {
        public int BlueEssence { get; init; }
        public int Rp { get; init; }
        public int SaleRp { get; init; }
    }
}
