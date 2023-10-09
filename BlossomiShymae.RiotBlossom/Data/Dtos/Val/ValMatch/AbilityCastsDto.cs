namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record AbilityCastsDto : DataObject
    {
        public int GrenadeCasts { get; init; }
        public int Ability1Casts { get; init; }
        public int Ability2Casts { get; init; }
        public int UltimateCasts { get; init; }
    }
}
