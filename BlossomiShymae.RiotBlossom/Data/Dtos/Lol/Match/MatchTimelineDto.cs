namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match
{
    public record MatchTimelineDto : DataObject
    {
        /// <summary>
        /// The metadata of match.
        /// </summary>
        public required MetadataDto Metadata { get; init; }
        /// <summary>
        /// The timeline info of match.
        /// </summary>
        public required TimelineInfoDto Info { get; init; }
    }
}
