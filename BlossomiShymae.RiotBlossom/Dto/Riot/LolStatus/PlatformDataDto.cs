using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LolStatus
{
    public record PlatformDataDto
    {
        /// <summary>
        /// The platform data ID e.g. "SG2".
        /// </summary>
        public string Id { get; init; } = default!;
        /// <summary>
        /// The platform name e.g. "Singapore".
        /// </summary>
        public string Name { get; init; } = default!;
        /// <summary>
        /// The locale identifiers that platform is associated with.
        /// </summary>
        public ImmutableList<string> Locales { get; init; } = ImmutableList<string>.Empty;
        /// <summary>
        /// The current maintenances for platform.
        /// </summary>
        public ImmutableList<StatusDto> Maintenances { get; init; } = ImmutableList<StatusDto>.Empty;
        /// <summary>
        /// The current incidents for platform.
        /// </summary>
        public ImmutableList<StatusDto> Incidents { get; init; } = ImmutableList<StatusDto>.Empty;
    }
}
