using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.Developer
{
    public record Queue : DataObject
    {
        public int QueueId { get; init; }
        public required string Map { get; init; }
        public string? Description { get; init; } 
        public string? Notes { get; init; }
    }
}