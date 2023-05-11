namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Passive
    {
        public bool Unique { get; set; }
        public bool Mythic { get; set; }
        public string? Name { get; set; }
        public string? Effects { get; set; }
        public int Range { get; set; }
        public string? Cooldown { get; set; }
        public Stats Stats { get; set; } = new();
    }
}
