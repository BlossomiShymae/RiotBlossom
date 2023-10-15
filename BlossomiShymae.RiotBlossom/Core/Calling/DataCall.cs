using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Data.Constants.Types;

namespace BlossomiShymae.RiotBlossom.Core.Calling
{
    public class DataCall
    {
        public Shard? Shard { get; set; }
        public string? Url { get; set; }
        public required string Endpoint { get; set; }
        public required string Method { get; set; }
        public IDictionary<string, string> Params { get; set; } = new Dictionary<string, string>();
        public IDictionary<string, string> Queries { get; set; } = new Dictionary<string, string>();
        public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
    }
}