using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record AttributeRatings
    {
        public int Damage { get; set; }
        public int Toughness { get; set; }
        public int Control { get; set; }
        public int Mobility { get; set; }
        public int Utility { get; set; }
        public int AbilityReliance { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }
        public int Difficulty { get; set; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
