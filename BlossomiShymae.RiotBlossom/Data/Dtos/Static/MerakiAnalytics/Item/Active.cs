namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Active : DataObject
    {
        public bool Unique { get; init; }
        public string? Name { get; init; }
        public string? Effects { get; init; }
        public int Range { get; init; }
        public float Cooldown { get; init; }
    }
}
