namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolChallenges
{
    public record LocalizedName : DataObject
    {
        /// <summary>
        /// The localized description of challenge.
        /// </summary>
        public required string Description { get; init; } 
        /// <summary>
        /// The localized challenge name.
        /// </summary>
        public required string Name { get; init; }
        /// <summary>
        /// The localized brief description of challenge.
        /// </summary>
        public required string ShortDescription { get; init; } 
    }
}
