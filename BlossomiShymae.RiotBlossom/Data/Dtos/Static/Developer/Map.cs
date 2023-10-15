using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.Developer
{
    public record Map : DataObject
    {
        public int MapId { get; init; }
        public required string MapName { get; init; } 
        public required string Notes { get; init; }
    }
}