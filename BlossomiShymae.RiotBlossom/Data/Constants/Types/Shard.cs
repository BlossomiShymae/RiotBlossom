using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlossomiShymae.RiotBlossom.Data.Constants.Types
{
    public abstract record Shard
    {
        public string Value { get; }
        public string Realm { get; }
        public string PrettyName { get; }
        public string DefaultLocale { get; }

        public Shard(string value, string realm, string prettyName, string defaultLocale)
        {
            Value = value;
            Realm = realm;
            PrettyName = prettyName;
            DefaultLocale = defaultLocale;
        }
    }
}