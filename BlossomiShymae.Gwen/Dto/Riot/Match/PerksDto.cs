using System.Collections.Immutable;

namespace BlossomiShymae.Gwen.Dto.Riot.Match
{
    /// <summary>
    /// A game data object that represents selected options in Runes Reforged.
    /// See CommunityDragon <see href="https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/perks.json">perks.json</see>.
    /// </summary>
    public record PerksDto
    {
        /// <summary>
        /// The selected stat perks for a player.
        /// </summary>
        public PerkStatsDto StatPerks { get; init; } = new();
        /// <summary>
        /// The selected perk styles for a player.
        /// </summary>
        public ImmutableList<PerkStyleDto> Styles { get; init; } = ImmutableList<PerkStyleDto>.Empty;
    }
}
