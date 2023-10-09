namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record PlaystyleInfo : DataObject
    {
        public int Damage { get; init; }
        public int Durability { get; init; }
        public int CrowdControl { get; init; }
        public int Mobility { get; init; }
        public int Utility { get; init; }
    }
}
