﻿using System.Collections.Immutable;

namespace Gwen.Dto.Match
{
    public record PerkStyleDto
    {
        /// <summary>
        /// The description of perk style.
        /// </summary>
        public string Description { get; init; } = default!;
        /// <summary>
        /// The selected perk styles.
        /// </summary>
        public ImmutableList<PerkStyleSelectionDto> Selections { get; init; } = ImmutableList<PerkStyleSelectionDto>.Empty;
        /// <summary>
        /// The style ID.
        /// </summary>
        public int Style { get; init; }
    }
}
