namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Spectator
{
    public record GameCustomizationObject : DataObject
    {
        /// <summary>
        /// The category ID for Game Customization.
        /// </summary>
        public required string Category { get; init; }
        /// <summary>
        /// The content for Game Customization.
        /// </summary>
        public required string Content { get; init; }
    }
}
