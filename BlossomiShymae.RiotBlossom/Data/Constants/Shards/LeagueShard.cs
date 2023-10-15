using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Data.Constants.Types;

namespace BlossomiShymae.RiotBlossom.Data.Constants.Shards
{
    public sealed record LeagueShard : Shard
    {
        public static readonly LeagueShard Unknown = new("", "", "Unknown", "");
        public static readonly LeagueShard BR1 = new("BR1", "br", "Brazil", "pt_BR");
        public static readonly LeagueShard EUN1 = new("EUN1", "eune", "Europe Nordic & East", "en_GB");
        public static readonly LeagueShard EUW1 = new("EUW1", "euw", "Europe West", "en_GB");
        public static readonly LeagueShard JP1 = new("JP1", "jp", "Japan", "ja_JP");
        public static readonly LeagueShard KR = new("KR", "kr", "Republic of Korea", "ko_KR");
        public static readonly LeagueShard LA1 = new("LA1", "lan", "Latin America North", "es_MX");
        public static readonly LeagueShard LA2 = new("LA2", "las", "Latin America South", "es_AR");
        public static readonly LeagueShard NA1 = new("NA1", "na", "North America", "en_US");
        public static readonly LeagueShard OC1 = new("OC1", "oc", "Oceania", "en_AU");
        public static readonly LeagueShard TR1 = new("TR1", "tr", "Turkey", "tr_TR");
        public static readonly LeagueShard RU = new("RU", "ru", "Russia", "ru_RU");
        public static readonly LeagueShard PBE1 = new("PBE1", "pbe", "Public Beta Environment", "en_US");
        public static readonly LeagueShard SG2 = new("SG2", "sg", "Singapore, Malaysia, and Indonesia", "en_SG");
        public static readonly LeagueShard PH2 = new("PH2", "ph", "The Phillipines", "en_PH");
        public static readonly LeagueShard VN2 = new("VN2", "vn", "Vietnam", "vi_VN");
        public static readonly LeagueShard TH2 = new("TH2", "th", "Thailand", "th_TH");
        public static readonly LeagueShard TW2 = new("TW2", "tw", "Taiwan, Hong Kong, and Macao", "zn_TW");

        private LeagueShard(string value, string realm, string prettyName, string defaultLocale) : base(value, realm, prettyName, defaultLocale)
        {
        }

        public RegionShard GetRegionShard()
        {
            if (this == NA1 || this == BR1 || this == LA1 || this == LA2)
            {
                return RegionShard.Americas;
            } 
            else if (this == EUW1 || this == EUN1 || this == RU || this == TR1)
            {
                return RegionShard.Europe;
            }
            else if (this == JP1 || this == KR)
            {
                return RegionShard.Asia;
            }
            else if (this == OC1 || this == SG2 || this == PH2 || this == VN2 || this == TH2 || this == TW2)
            {
                return RegionShard.SEA;
            }
            else if (this == PBE1)
            {
                return RegionShard.PBE;
            }
            else if (this == Unknown)
            {
                return RegionShard.Unknown;
            }

            throw new InvalidOperationException();
        }

        public static LeagueShard GetFromValue(string value)
        {
            
            return value switch
            {
                "BR1" => BR1,
                "EUN1" => EUN1,
                "EUW1" => EUW1,
                "JP1" => JP1,
                "KR" => KR,
                "LA1" => LA1,
                "LA2" => LA2,
                "NA1" => NA1,
                "OC1" => OC1,
                "TR1" => TR1,
                "RU" => RU,
                "PBE1" => PBE1,
                "SG2" => SG2,
                "PH2" => PH2,
                "VN2" => VN2,
                "TH2" => TH2,
                "TW2" => TW2,
                _ => throw new InvalidOperationException()
            };
        }
    }
}