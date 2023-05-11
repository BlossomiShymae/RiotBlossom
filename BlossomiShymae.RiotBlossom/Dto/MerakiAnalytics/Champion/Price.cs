using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Price
    {
        public int BlueEssence { get; set; }
        public int Rp { get; set; }
        public int SaleRp { get; set; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
