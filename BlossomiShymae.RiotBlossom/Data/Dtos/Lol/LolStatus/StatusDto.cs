using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolStatus
{
    public record StatusDto : DataObject
    {
        /// <summary>
        /// The status ID.
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// The maintenance status e.g. ("scheduled", "in_progress", "complete").
        /// </summary>
        public string? MaintenanceStatus { get; init; }
        /// <summary>
        /// The severity level of status incident e.g. "info", "warning", "critical".
        /// </summary>
        public required string IncidentSeverity { get; init; }
        /// <summary>
        /// The title text for status.
        /// </summary>
        public List<ContentDto> Titles { get; init; } = [];
        /// <summary>
        /// The content text for status.
        /// </summary>
        public List<UpdateDto> Updates { get; init; } = [];
        /// <summary>
        /// <para>Sorries I'll just be putting an example. ;w;</para>
        /// <example>2023-01-19T02:14:10.148483+00:00</example>
        /// </summary>
        public required string CreatedAt { get; init; }
        /// <summary>
        /// Pwease see <see cref="CreatedAt"/> and <see cref="UpdatedAt"/>.
        /// </summary>
        public string? ArchiveAt { get; init; }
        /// <summary>
        /// <para>Sorries I'll just be putting an example. ;w;</para>
        /// <example>2023-02-26T11:00:07.189038+00:00</example>
        /// </summary>
        public required string UpdatedAt { get; init; }
        /// <summary>
        /// The platform list affected by this incident e.g. "windows", "macos".
        /// </summary>
        public List<string> Platforms { get; init; } = [];
    }
}
