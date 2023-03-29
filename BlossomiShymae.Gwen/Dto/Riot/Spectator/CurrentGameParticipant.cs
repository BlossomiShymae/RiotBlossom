using System.Collections.Immutable;

namespace BlossomiShymae.Gwen.Dto.Riot.Spectator
{
    public record CurrentGameParticipant
    {
        /// <summary>
        /// The played champion ID.
        /// </summary>
        public long ChampionId { get; init; }
        /// <summary>
        /// The equipped perks/runes information of Runes Reforged.
        /// </summary>
        public Perks Perks { get; init; } = new();
        /// <summary>
        /// The profile icon ID of participant.
        /// </summary>
        public long ProfileIconId { get; init; }
        /// <summary>
        /// Whether the participant is a bot.
        /// </summary>
        public bool Bot { get; init; }
        /// <summary>
        /// The participant's team ID.
        /// </summary>
        public long TeamId { get; init; }
        /// <summary>
        /// The summoner name of participant.
        /// </summary>
        public string SummonerName { get; init; } = default!;
        /// <summary>
        /// The encrypted summoner ID of participant.
        /// </summary>
        public string SummonerId { get; init; } = default!;
        /// <summary>
        /// The first equipped summoner spell ID.
        /// </summary>
        public long Spell1Id { get; init; }
        /// <summary>
        /// The second equipped summoner spell ID.
        /// </summary>
        public long Spell2Id { get; init; }
        /// <summary>
        /// The list of Game Customization objects.
        /// </summary>
        public ImmutableList<GameCustomizationObject> GameCustomizationObjects { get; init; } = ImmutableList<GameCustomizationObject>.Empty;
    }
}
