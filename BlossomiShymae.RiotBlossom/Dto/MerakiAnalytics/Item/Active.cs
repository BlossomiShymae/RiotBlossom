using BlossomiShymae.RiotBlossom.Core;

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

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
