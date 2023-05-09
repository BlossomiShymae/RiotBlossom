# Tutorial: Making requests to the League of Legends APIs in RiotBlossom

This radical tutorial will cover common requests to the League of Legends APIs with 
RiotBlossom!

You will learn how to:
- Fetch a summoner
- Fetch match identifiers and matches
- Fetch champion masteries

## Prerequisites
- [League of Legends Offical Documentation](https://developer.riotgames.com/docs/lol)
- Tutorials Overview

## Fetch a summoner

Let us try getting a summoner from the Riot API! Type and save the following 
code below:

```csharp
using BlossomiShymae.RiotBlossom.Type;

var summoner = await client.Riot.Summoner
    .GetByNameAsync(Platform.NorthAmerica, "uwuie time");
Console.WriteLine(summoner);
```

The following output should be displayed within your console:

```json
SummonerDto {
  "AccountId": "0WvZHECxpBFNlntYzcCNyDkGeaqA6vthcLsklngrPVYofWE",
  "ProfileIconId": 5367,
  "RevisionDate": 1675651090000,
  "Name": "uwuie time",
  "Id": "Ao5ffQ2dOV-99YKs_iB0g2EGzGD159jXIk2Z5MjvMafLwbQ",
  "Puuid": "Bd1zj7cFt3MlCZl2GI-5N94D2PHRsfpsjl-6ZM9LjXIm90Bz4JAdwR6Kw4fzbSPFfLoQI5p9hGIhfA",
  "SummonerLevel": 936
}
```

The preceding string is generated with the `PrettyPrinter` class provided by `RiotBlossom.Core`. This makes it totes friendly and easier for reading data objects from the 
console!

If we're commonly making requests to the same API, we can store an API reference to make requests with instead!

## Fetch match identifiers and matches

Now how about getting some fresh matches with the summoner we received? >w<

Go ahead and save the following code below:

```csharp
using BlossomiShymae.RiotBlossom.Api;
using BlossomiShymae.RiotBlossom.Dto.Riot.Match;

IRiotApi riot = client.Riot;

var ids = 
    await riot.Match.ListIdsByPuuidAsync(Platform.NorthAmerica, summoner.Puuid);
List<MatchDto> matches = new();
foreach (string id in ids)
    matches.Add(await riot.Match.GetByIdAsync(Platform.NorthAmerica, id));

matches
    .Select(m => m.Info.Participants
        .Where(p => p.SummonerId == summoner.Id)
        .First())
    .ToList()
    .ForEach(p => Console
        .WriteLine($"{p.ChampionName,-16}{$"{p.Kills}/{p.Deaths}/{p.Assists}",16}"));
```

This should generate the following output:

![image](https://user-images.githubusercontent.com/87099578/232168413-19747394-a8f2-4af3-b601-d3bf849d08a7.png)

![smug](/img/tutorials-lol-smug.png)

## Fetch champion masteries

Getting champion masteries is not a problem! Since the masteries themselves only 
provide champion identifiers, we will also be using DataDragon to fetch metadata 
for champions.

Try and run the following code below:

```csharp
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.DataDragon.Champion;
using BlossomiShymae.RiotBlossom.Dto.Riot.ChampionMastery;

var masteries = await client.Riot.ChampionMastery
    .ListBySummonerIdAsync(Platform.NorthAmerica, summoner.Id);
// Get the latest championFull.json from the latest version of DataDragon
string version = await client.DataDragon.GetLatestVersionAsync();
var championDictionary = await client.DataDragon
    .GetChampionDictionaryAsync(version);

// Print champion mastery leaderboard of summoner for champions that have the 'Support' role tag
foreach (ChampionMasteryDto mastery in masteries)
{
    championDictionary.TryGetValue((int)mastery.ChampionId, out Champion? champion);
    if (champion != null && champion.Tags.Contains("Support"))
        Console.WriteLine($"{champion.Name,-16} - {mastery.ChampionPoints,7}");
}
```

The preceding code should output a mastery high score light filtered by the 
support role:

```
Sona             -  720634
Soraka           -  508076
Janna            -  238814
Nami             -  181987
Lulu             -  144284
Yuumi            -  142785
Orianna          -  134359
Seraphine        -  131645
...
```

Now we're flying off, hehe!

![fly](/img/tutorials-lol-fly.png)