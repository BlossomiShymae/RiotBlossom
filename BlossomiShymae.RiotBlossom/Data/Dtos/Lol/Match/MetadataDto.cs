using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match
{
    public record MetadataDto : DataObject
    {
        /// <summary>
        /// The data version of match.
        /// </summary>
        public required string DataVersion { get; init; }
        /// <summary>
        /// The match ID.
        /// </summary>
        public required string MatchId { get; init; }
        /// <summary>
        /// The list of encrypted PUUIDs for summoners that participated in the match.
        /// </summary>
        public List<string> Participants { get; init; } = [];
    }
}
