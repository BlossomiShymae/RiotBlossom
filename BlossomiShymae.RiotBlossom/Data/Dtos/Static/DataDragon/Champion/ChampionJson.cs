using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Champion
{
    internal record ChampionJson
    {
        public required Dictionary<string, Champion> Data { get; init; }
    }
}