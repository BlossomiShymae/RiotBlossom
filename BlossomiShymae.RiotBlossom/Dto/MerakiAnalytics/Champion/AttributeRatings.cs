using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record AttributeRatings
    {
        public int Damage { get; init; }
        public int Toughness { get; init; }
        public int Control { get; init; }
        public int Mobility { get; init; }
        public int Utility { get; init; }
        public int AbilityReliance { get; init; }
        public int Attack { get; init; }
        public int Defense { get; init; }
        public int Magic { get; init; }
        public int Difficulty { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
