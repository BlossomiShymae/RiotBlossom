﻿using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Rarities
    {
        public int? Rarity { get; init; }
        public string? Region { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
