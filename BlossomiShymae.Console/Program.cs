using BlossomiShymae.RiotBlossom.Client;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Core.Cache;
using BlossomiShymae.RiotBlossom.Core.Limiting;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using Microsoft.Extensions.Logging;

// RIOT_API_KEY environment variable is automatically used!
// var client = RiotBlossomClient.Create();
var client = RiotBlossomClient.Create(new ApiConfiguration()
{
  Key = Environment.GetEnvironmentVariable("RIOT_API_KEY"),
  Cache = CacheFactory.Create(CacheProvider.Memory),
  Limiter = LimiterFactory.Create(LimiterProvider.Burst),
  Http = new(),
  Logger = LoggerFactory.Create(configure =>
  {
    configure.AddConsole();
  }).CreateLogger("RiotBlossom")
});

var summoner = await client.SummonerV4.GetByNameAsync(LeagueShard.NA1, "uwuie time");

Console.WriteLine(summoner);