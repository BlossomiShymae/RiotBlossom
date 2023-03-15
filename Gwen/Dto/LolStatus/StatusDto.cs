using System.Collections.Immutable;

namespace Gwen.Dto.LolStatus
{
    public record StatusDto
    {
        /// <summary>
        /// The status ID.
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// The maintenance status e.g. ("scheduled", "in_progress", "complete").
        /// </summary>
        public string? MaintenanceStatus { get; init; } = default!;
        /// <summary>
        /// The severity level of status incident e.g. "info", "warning", "critical".
        /// </summary>
        public string IncidentSeverity { get; init; } = default!;
        /// <summary>
        /// The title text for status.
        /// </summary>
        public ImmutableList<ContentDto> Titles { get; init; } = ImmutableList<ContentDto>.Empty;
        /// <summary>
        /// The content text for status.
        /// </summary>
        public ImmutableList<UpdateDto> Updates { get; init; } = ImmutableList<UpdateDto>.Empty;
        /// <summary>
        /// <para>Sorries I'll just be putting an example. ;w;</para>
        /// <example>2023-01-19T02:14:10.148483+00:00</example>
        /// </summary>
        public string CreatedAt { get; init; } = default!;
        /// <summary>
        /// Pwease see <see cref="CreatedAt"/> and <see cref="UpdatedAt"/>.
        /// </summary>
        public string? ArchiveAt { get; init; } = default!;
        /// <summary>
        /// <para>Sorries I'll just be putting an example. ;w;</para>
        /// <example>2023-02-26T11:00:07.189038+00:00</example>
        /// </summary>
        public string UpdatedAt { get; init; } = default!;
        /// <summary>
        /// The platform list affected by this incident e.g. "windows", "macos".
        /// </summary>
        public ImmutableList<string> Platforms { get; init; } = ImmutableList<string>.Empty;
    }
}
