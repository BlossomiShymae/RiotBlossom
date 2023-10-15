namespace BlossomiShymae.RiotBlossom.Data.Dtos.Tft.TftMatch
{
    public record MatchDto : DataObject
    {
        /// <summary>
        /// The match metadata.
        /// </summary>
        public required MetadataDto Metadata { get; init; }
        /// <summary>
        /// The match info.
        /// </summary>
        public required InfoDto Info { get; init; }
    }
}
