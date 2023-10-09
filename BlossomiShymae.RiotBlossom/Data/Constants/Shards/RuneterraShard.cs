using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Data.Constants.Types;

namespace BlossomiShymae.RiotBlossom.Data.Constants.Shards
{
    public sealed record RuneterraShard : Shard
    {
        public static readonly RuneterraShard Unknown = new("", "", "Unknown", "");
        public static readonly RuneterraShard Americas = new("AMERICAS", "americas", "Americas", "");
        public static readonly RuneterraShard Europe = new("EUROPE", "europe", "Europe", "");
        public static readonly RuneterraShard SEA = new("SEA", "sea", "Southeast Asia", "");

        private RuneterraShard(string value, string realm, string prettyName, string defaultLocale) : base(value, realm, prettyName, defaultLocale)
        {
        }
    }
}