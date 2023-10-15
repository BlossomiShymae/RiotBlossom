namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record TacticalInfo : DataObject
    {
        public int Style { get; init; }
        public int Difficulty { get; init; }
        public required string DamageType { get; init; }
    }
}
