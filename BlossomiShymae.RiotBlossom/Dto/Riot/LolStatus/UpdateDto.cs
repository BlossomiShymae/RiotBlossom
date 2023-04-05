using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LolStatus
{
    public record UpdateDto
    {
        /// <summary>
        /// The update ID.
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// The author of update e.g. "Riot Games".
        /// </summary>
        public string Author { get; init; } = default!;
        /// <summary>
        /// Whether the update is published to specified locations.
        /// </summary>
        public bool Publish { get; init; }
        /// <summary>
        /// Locations where the update can be published to e.g. ("game", "riotclient", "riotstatus").
        /// </summary>
        public ImmutableList<string> PublishLocations { get; init; } = ImmutableList<string>.Empty;
        /// <summary>
        /// The text translations for update content.
        /// </summary>
        public ImmutableList<ContentDto> Translations { get; init; } = ImmutableList<ContentDto>.Empty;
        /// <summary>
        /// <para>Oofie I don't know what the format is...have an example! :3</para>
        /// <example>2023-01-19T02:14:10.226109+00:00</example>
        /// </summary>
        public string CreatedAt { get; init; } = default!;
        /// <summary>
        /// <para>Oofie I don't know what the format is...have an example! :3</para>
        /// <example>2023-01-19T02:14:00+00:00</example>
        /// </summary>
        public string UpdatedAt { get; init; } = default!;
    }
}
