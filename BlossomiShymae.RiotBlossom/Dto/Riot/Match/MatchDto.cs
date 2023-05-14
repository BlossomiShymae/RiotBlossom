namespace BlossomiShymae.RiotBlossom.Dto.Riot.Match
{
    public record MatchDto : DataObject<MatchDto>
    {
        /// <summary>
        /// The metadata of match.
        /// </summary>
        public MetadataDto Metadata { get; init; } = new();
        /// <summary>
        /// The info of match. The yummy part that most developers want. :eyes:
        /// </summary>
        public InfoDto Info { get; init; } = new();
    }
}
