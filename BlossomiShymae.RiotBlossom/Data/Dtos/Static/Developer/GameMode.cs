using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.Developer
{
    public record GameMode : DataObject
    {
        [JsonPropertyName("gameMode")]
        public required string GameModeValue { get; init; }
        public required string Description { get; init; }
    }
}