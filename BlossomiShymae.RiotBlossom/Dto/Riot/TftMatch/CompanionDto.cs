﻿using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.TftMatch
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record CompanionDto : DataObject
    {
        [JsonPropertyName("skin_id")]
        public int SkinId { get; init; }
        [JsonPropertyName("content_id")]
        public string ContentId { get; init; } = default!;
        public string Species { get; init; } = default!;
    }
}
