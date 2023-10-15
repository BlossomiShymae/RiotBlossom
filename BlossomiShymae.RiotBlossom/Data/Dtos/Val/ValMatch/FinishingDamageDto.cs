namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record FinishingDamageDto : DataObject
    {
        public required string DamageType { get; init; }
        public required string DamageItem { get; init; }
        public bool IsSecondaryFireMode { get; init; }
    }
}
