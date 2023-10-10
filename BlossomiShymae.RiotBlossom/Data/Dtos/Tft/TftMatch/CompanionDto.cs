using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Tft.TftMatch
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record CompanionDto : DataObject
    {
        [JsonPropertyName("skin_id")]
        public int SkinId { get; init; }
        [JsonPropertyName("content_id")]
        public string? ContentId { get; init; }
        public required string Species { get; init; }
    }
}
