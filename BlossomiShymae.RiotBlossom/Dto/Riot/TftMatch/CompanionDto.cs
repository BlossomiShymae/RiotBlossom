using BlossomiShymae.RiotBlossom.Core;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.TftMatch
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record CompanionDto
    {
        [JsonPropertyName("skin_id")]
        public int SkinId { get; init; }
        [JsonPropertyName("content_id")]
        public string ContentId { get; init; } = default!;
        public string Species { get; init; } = default!;

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
