﻿namespace BlossomiShymae.RiotBlossom.Dto.DataDragon.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Gold
    {
        public int Base { get; init; }
        public int Total { get; init; }
        public int Sell { get; init; }
        public bool Purchasable { get; init; }
    }
}