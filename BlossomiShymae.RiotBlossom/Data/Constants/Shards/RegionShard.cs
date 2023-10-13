using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Data.Constants.Types;

namespace BlossomiShymae.RiotBlossom.Data.Constants.Shards
{
    public sealed record RegionShard : Shard
    {
        public static readonly RegionShard Unknown = new("", "", "Unknown", "");
        public static readonly RegionShard Americas = new("AMERICAS", "americas", "Americas", "");
        public static readonly RegionShard Europe = new("EUROPE", "europe", "Europe", "");
        public static readonly RegionShard Asia = new("ASIA", "asia", "Asia", "");
        public static readonly RegionShard PBE = new("PBE", "pbe", "Public Beta Environment", "");
        public static readonly RegionShard Esports = new("ESPORTS", "esports", "Esports", "");
        public static readonly RegionShard SEA = new("SEA", "sea", "Southeast Asia", "");

        private RegionShard(string value, string realm, string prettyName, string defaultLocale) : base(value, realm, prettyName, defaultLocale)
        {
        }

        public static RegionShard GetFromValue(string value)
        {
            return value switch
            {
                "" => Unknown,
                "AMERICAS" => Americas,
                "EUROPE" => Europe,
                "ASIA" => Asia,
                "PBE" => PBE,
                "ESPORTS" => Esports,
                "SEA" => SEA,
                _ => throw new InvalidOperationException()
            };
        }
    }
}