using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Active
    {
        public bool Unique { get; init; }
        public string? Name { get; init; }
        public string? Effects { get; init; }
        public int Range { get; init; }
        public float Cooldown { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
