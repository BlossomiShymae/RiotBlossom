namespace BlossomiShymae.RiotBlossom.Dto.Riot.LolStatus
{
    public record ContentDto
    {
        /// <summary>
        /// The locale identifier for content e.g. ("en_US", "de_DE").
        /// </summary>
        public string Locale { get; init; } = default!;
        /// <summary>
        /// The text content for incident.
        /// </summary>
        public string Content { get; init; } = default!;
    }
}
