﻿using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Leveling
    {
        public string? Attribute { get; set; }
        public ImmutableList<Modifier> Modifiers { get; set; } = ImmutableList<Modifier>.Empty;
    }
}