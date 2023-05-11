﻿using BlossomiShymae.RiotBlossom.Core;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Cooldown
    {
        public ImmutableList<Modifier> Modifiers { get; set; } = ImmutableList<Modifier>.Empty;
        public bool AffectedByCdr { get; set; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
