using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Client;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Match;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Summoner;
using BlossomiShymae.RiotBlossom.Data.Dtos.Riot.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlossomiShymae.RiotBlossomTests
{
    [TestClass()]
    public static class Shared
    {
        public static readonly IRiotBlossomClient Client = new RiotBlossomClient(new()
        {
            Key = Environment.GetEnvironmentVariable("RIOT_API_KEY")!
        });

        public static SummonerDto Summoner = default!;
        public static AccountDto Account = default!;
        public static RuneterraShard RuneterraShard = RuneterraShard.Americas;
        public static LeagueShard LeagueShard = LeagueShard.EUW1;

        [AssemblyInitialize]
        public static async Task AssemblyInitAsync(TestContext context)
        {   
            Summoner = await Client.SummonerV4.GetByNameAsync(LeagueShard.EUW1, "TheDrone7");
            Account = await Client.AccountV1.GetAccountByRiotIdAsync(RegionShard.Americas, "ToxicMacaroni", "NA1");
        }
    }
}