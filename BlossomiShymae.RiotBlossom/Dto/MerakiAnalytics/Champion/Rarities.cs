using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Rarities
    {
        public int Rarity { get; set; }
        public string? Region { get; set; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
