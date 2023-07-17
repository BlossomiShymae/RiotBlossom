namespace BlossomiShymae.RiotBlossom.Dto.Riot.LolChallenges
{
    public record LocalizedName : DataObject
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
