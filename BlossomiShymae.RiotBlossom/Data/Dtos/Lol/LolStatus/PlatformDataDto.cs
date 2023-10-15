using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolStatus
{
    public record PlatformDataDto : DataObject
    {
        /// <summary>
        /// The platform data ID e.g. "SG2".
        /// </summary>
        public required string Id { get; init; } 
        /// <summary>
        /// The platform name e.g. "Singapore".
        /// </summary>
        public required string Name { get; init; }
        /// <summary>
        /// The locale identifiers that platform is associated with.
        /// </summary>
        public List<string> Locales { get; init; } = [];
        /// <summary>
        /// The current maintenances for platform.
        /// </summary>
        public List<StatusDto> Maintenances { get; init; } = [];
        /// <summary>
        /// The current incidents for platform.
        /// </summary>
        public List<StatusDto> Incidents { get; init; } = [];
    }
}
