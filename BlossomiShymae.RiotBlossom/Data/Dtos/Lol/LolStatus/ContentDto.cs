namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolStatus
{
    public record ContentDto : DataObject
    {
        /// <summary>
        /// The locale identifier for content e.g. ("en_US", "de_DE").
        /// </summary>
        public required string Locale { get; init; }
        /// <summary>
        /// The text content for incident.
        /// </summary>
        public required string Content { get; init; } 
    }
}
