﻿using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.DDragon.Champion
{
    public record Leveltip
    {
        public ImmutableList<string> Label { get; init; } = ImmutableList<string>.Empty;
        public ImmutableList<string> Effect { get; init; } = ImmutableList<string>.Empty;
    }
}