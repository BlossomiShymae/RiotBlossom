﻿namespace BlossomiShymae.RiotBlossom.Dto.Riot.ValMatch
{
    public record FinishingDamageDto : DataObject
    {
        public string DamageType { get; init; } = default!;
        public string DamageItem { get; init; } = default!;
        public bool IsSecondaryFireMode { get; init; }
    }
}
