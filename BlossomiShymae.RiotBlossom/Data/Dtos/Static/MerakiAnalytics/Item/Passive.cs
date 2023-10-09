﻿using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Core.Converters;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Item
{
    /// <summary>
    /// UNDOCUMENTED
    /// </summary>
    public record Passive : DataObject
    {
        public bool Unique { get; init; }
        public bool Mythic { get; init; }
        public string? Name { get; init; }
        public string? Effects { get; init; }
        public int? Range { get; init; }
        [JsonConverter(typeof(StringJsonConverter))]
        public string? Cooldown { get; init; }
        public Stats Stats { get; init; } = new();
    }
}
