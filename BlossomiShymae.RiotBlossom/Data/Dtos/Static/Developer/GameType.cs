using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.Developer
{
    public record GameType : DataObject
    {
        [JsonPropertyName("gameType")]
        public required string GameTypeValue { get; init; } 
        public required string Description { get; init; }
    }
}