using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LorMatch
{
    public record MatchDto
    {
        /// <summary>
        /// The match metadata.
        /// </summary>
        public MetadataDto Metadata { get; init; } = new();
        /// <summary>
        /// The match info.
        /// </summary>
        public InfoDto Info { get; init; } = new();

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
