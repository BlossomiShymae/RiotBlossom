namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record AttributeRatings : DataObject
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
    }
}
