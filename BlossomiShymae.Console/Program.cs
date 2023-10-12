using BlossomiShymae.RiotBlossom.Client;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;

// RIOT_API_KEY environment variable is automatically used!
var client = RiotBlossomClient.Create();

var summoner = await client.SummonerV4.GetByNameAsync(LeagueShard.NA1, "uwuie time");

Console.WriteLine(summoner);