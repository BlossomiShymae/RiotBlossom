using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lol.LolStatus
{
    public record UpdateDto : DataObject
    {
        /// <summary>
        /// The update ID.
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// The author of update e.g. "Riot Games".
        /// </summary>
        public required string Author { get; init; } 
        /// <summary>
        /// Whether the update is published to specified locations.
        /// </summary>
        public bool Publish { get; init; }
        /// <summary>
        /// Locations where the update can be published to e.g. ("game", "riotclient", "riotstatus").
        /// </summary>
        public List<string> PublishLocations { get; init; } = [];
        /// <summary>
        /// The text translations for update content.
        /// </summary>
        public List<ContentDto> Translations { get; init; } = [];
        /// <summary>
        /// <para>Oofie I don't know what the format is...have an example! :3</para>
        /// <example>2023-01-19T02:14:10.226109+00:00</example>
        /// </summary>
        public string? CreatedAt { get; init; }
        /// <summary>
        /// <para>Oofie I don't know what the format is...have an example! :3</para>
        /// <example>2023-01-19T02:14:00+00:00</example>
        /// </summary>
        public string? UpdatedAt { get; init; }
    }
}
