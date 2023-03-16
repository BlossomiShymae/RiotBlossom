using System.Collections.Immutable;

namespace Gwen.Dto.Match
{
    public record MetadataDto
    {
        /// <summary>
        /// The data version of match.
        /// </summary>
        public string DataVersion { get; init; } = default!;
        /// <summary>
        /// The match ID.
        /// </summary>
        public string MatchId { get; init; } = default!;
        /// <summary>
        /// The list of encrypted PUUIDs for summoners that participated in the match.
        /// </summary>
        public ImmutableList<string> Participants { get; init; } = ImmutableList<string>.Empty;
    }
}
