namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record EconomyDto : DataObject
    {
        public int LoadoutValue { get; init; }
        public string Weapon { get; init; } = default!;
        public string Armor { get; init; } = default!;
        public int Remaining { get; init; }
        public int Spent { get; init; }
    }
}
