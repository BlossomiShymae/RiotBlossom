namespace BlossomiShymae.Gwen.Dto.Riot.Match
{
    public record MatchTimelineDto
    {
        /// <summary>
        /// The metadata of match.
        /// </summary>
        public MetadataDto Metadata { get; init; } = new();
        /// <summary>
        /// The timeline info of match.
        /// </summary>
        public TimelineInfoDto Info { get; init; } = new();
    }
}
