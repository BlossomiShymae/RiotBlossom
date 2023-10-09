namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lor.LorMatch
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
