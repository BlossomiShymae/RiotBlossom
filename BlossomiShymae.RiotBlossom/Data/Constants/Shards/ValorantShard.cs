using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Data.Constants.Types;

namespace BlossomiShymae.RiotBlossom.Data.Constants.Shards
{
    public sealed record ValorantShard : Shard
    {
        public static readonly ValorantShard Unknown = new("", "", "Unknown", "");
        public static readonly ValorantShard NA = new("NA", "na", "North America", "");
        public static readonly ValorantShard PBE1 = new("PBE1", "pbe1", "Public Beta Environment", "");
        public static readonly ValorantShard EU = new("EU", "eu", "Europe", "");
        public static readonly ValorantShard BR = new("BR", "br", "Brazil", "");
        public static readonly ValorantShard KR = new("KR", "kr", "Korea", "");
        public static readonly ValorantShard LATAM = new("LATAM", "latam", "Latin America", "");
        public static readonly ValorantShard AP = new("AP", "ap", "Asia Pacific", "");
        public static readonly ValorantShard Esports = new("ESPORTS", "esports", "Esports", "");

        private ValorantShard(string value, string realm, string prettyName, string defaultLocale) : base(value, realm, prettyName, defaultLocale)
        {
        }

        public static ValorantShard GetFromValue(string value)
        {
            return value switch
            {
                "" => Unknown,
                "NA" => NA,
                "PBE1" => PBE1,
                "EU" => EU,
                "BR" => BR,
                "KR" => KR,
                "LATAM" => LATAM,
                "AP" => AP,
                "ESPORTS" => Esports,
                _ => throw new InvalidOperationException()
            };
        }
    }
}