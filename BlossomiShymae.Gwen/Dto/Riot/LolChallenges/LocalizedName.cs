namespace BlossomiShymae.Gwen.Dto.Riot.LolChallenges
{
    public record LocalizedName
    {
        /// <summary>
        /// The localized description of challenge.
        /// </summary>
        public string Description { get; init; } = default!;
        /// <summary>
        /// The localized challenge name.
        /// </summary>
        public string Name { get; init; } = default!;
        /// <summary>
        /// The localized brief description of challenge.
        /// </summary>
        public string ShortDescription { get; init; } = default!;
    }
}
