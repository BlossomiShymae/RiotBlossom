using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Item
{
    internal record ItemJson
    {
        public required Dictionary<int, Item> Data { get; init;}
    }
}