namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Active
    {
        public bool Unique { get; set; }
        public string? Name { get; set; }
        public string? Effects { get; set; }
        public int Range { get; set; }
        public float Cooldown { get; set; }
    }
}
