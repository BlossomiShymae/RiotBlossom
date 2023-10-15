namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match
{
    public record MatchDto : DataObject
    {
        /// <summary>
        /// The metadata of match.
        /// </summary>
        public required MetadataDto Metadata { get; init; }
        /// <summary>
        /// The info of match. The yummy part that most developers want. :eyes:
        /// </summary>
        public required InfoDto Info { get; init; }
    }
}
