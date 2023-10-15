namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record EconomyDto : DataObject
    {
        public int LoadoutValue { get; init; }
        public required string Weapon { get; init; } 
        public required string Armor { get; init; }
        public int Remaining { get; init; }
        public int Spent { get; init; }
    }
}
