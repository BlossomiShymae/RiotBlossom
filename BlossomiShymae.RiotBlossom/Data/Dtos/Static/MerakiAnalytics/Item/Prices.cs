namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Prices : DataObject
    {
        public int Total { get; init; }
        public int Combined { get; init; }
        public int Sell { get; init; }
    }
}
