namespace BlossomiShymae.RiotBlossom.Data.Dtos.Val.ValMatch
{
    public record AbilityDto : DataObject
    {
        public required string GrenadeEffects { get; init; }
        public required string Ability1Effects { get; init; }
        public required string Ability2Effects { get; init; } 
        public required string UltimateEffects { get; init; }
    }
}
