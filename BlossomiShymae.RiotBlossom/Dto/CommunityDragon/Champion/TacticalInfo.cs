﻿namespace BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record TacticalInfo : DataObject
    {
        public int Style { get; init; }
        public int Difficulty { get; init; }
        public string DamageType { get; init; } = default!;
    }
}
