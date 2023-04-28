# RiotBlossom
 
[![NuGet Stable](https://img.shields.io/nuget/v/BlossomiShymae.RiotBlossom.svg?style=flat-square&logo=nuget&logoColor=black&labelColor=69ffbe&color=77077a)](https://www.nuget.org/packages/BlossomiShymae.RiotBlossom/) ![NuGet Downloads](https://img.shields.io/nuget/dt/BlossomiShymae.RiotBlossom?style=flat-square&logoColor=black&labelColor=69ffbe&color=77077a)

An asynchronous, extensible, and magical Riot Games API wrapper library for C#. ☆*:.｡.o(≧▽≦)o.｡.:*☆

This library helps to make things totes' easier! Goodies include naive cache, rate limiter, and retryer middleware plugins 
out of the box. Other services such as DataDragon and CommunityDragon are also supported! ＼(＾▽＾)／

This library is currently compatible with .NET 6 and higher.

### Contributor Flowerlets
<a href="https://github.com/BlossomiShymae/RiotBlossom/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=BlossomiShymae/RiotBlossom" />
</a>

---
- [AoshiW](https://github.com/AoshiW)

Made with [contrib.rocks](https://contrib.rocks).

# Table of Contents
1. [Features](#features)
2. [Installation](#installation)
3. [Endpoints](#endpoints)
4. [Quickstart](#quickstart)
5. [Using with ASP.NET Core](#using-with-asp.net-core)
6. [API Interfaces](#api-interfaces)
7. [Middleware Plugins](#middleware-plugins)
8. [Exceptions](#exceptions-oh-noes)
9. [Types](#types)
10. [Utilities](#utilities)
11. [Data transfer objects](#data-transfer-objects-dto)
12. [Dependent packages](#dependent-packages)
13. [Contributing](#contributing)
14. [License](#license)
15. [Disclaimer](#disclaimer)
16. [Appendix](#appendix)

# Features
- Asynchronous, immutable record, no-conversion API
    - API data comes as is from the source (Data transfer objects)
- In-memory caching, spread rate limiting, and automatic retrying out of the box
- Fluent client builder for advanced configuration
- A highly configurable HTTP middleware system
    - Allows implementing your own middleware (choosing database to cache with)
    - Extensible subsystems (one for Riot API, one for the rest)
- Reuseable data transfer objects, types, and exceptions
- Common utilities (mappers and converters)
- Riot Games API support (yep!)
    - League of Legends
    - Teamfight Tactics
    - Legends of Runeterra
    - VALORANT
- DataDragon support
- CommunityDragon support
- Love (੭ु ›ω‹ )੭ु⁾⁾♡

# Installation
Install via NuGet, [`BlossomiShymae.RiotBlossom`](https://www.nuget.org/packages/BlossomiShymae.RiotBlossom).
For package manager console:
```
Install-Package BlossomiShymae.RiotBlossom
```
Or the .NET CLI:
```
dotnet add package BlossomiShymae.RiotBlossom
```

# Endpoints
## Riot Api
- ⭕ Account-v1 (no RSO)

### League of Legends
- ✅ Champion-Mastery-v4
- ✅ Champion-v3
- ✅ Clash-v1
- ❌ League-Exp-v4 (will not support, experimental endpoint)
- ✅ League-v4
- ✅ Lol-Challenges-v1
- ✅ Lol-Status-v4
- ✅ Match-v5
- ✅ Spectator-v4
- ⭕ Summoner-v4 (no RSO)
- ❌ Tournament-Stub-v4 (will not support, endpoint that is associated with being unreliable)
- ❌ Tournament-v4 (will not support)

### Teamfight Tactics
- ✅ Tft-League-v1
- ✅ Tft-Match-v1
- ✅ Tft-Status-v1
- ⭕ Tft-Summoner-v1 (no RSO)

### Legends of Runeterra
- ⭕ Lor-Deck-v1 (no RSO, currently not supported)
- ⭕ Lor-Inventory-v1 (no RSO, currently not supported)
- ✅ Lor-Match-v1
- ✅ Lor-Ranked-v1
- ✅ Lor-Status-v1

### VALORANT
- ✅ Val-Content-v1
- ✅ Val-Match-v1 ("Unsure if this works as I do not have access to this endpoint for testing ˚‧º·(˚ ˃̣̣̥⌓˂̣̣̥ )‧º·˚" - BlossomiShymae)
- ✅ Val-Ranked-v1
- ✅ Val-Status-v1

## DataDragon
- ✅ Champions (`championFull.json`)
- ✅ Items (`item.json`)
- ✅ Perks (`runesReforged.json`)

## CommunityDragon
- ✅ Champions ([rcp-be-lol-game-data/global/default/v1/champions](https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/champions/))
- ✅ Items (`items.json`)
- ✅ Perks (`perks.json`)

# Quickstart
The simplest, easiest, and quickest way to start is by calling `CreateClient` with a Riot API key (or `string.Empty` for only Dragon APIs...)
```csharp
using BlossomiShymae.RiotBlossom.Core;

// You can hard-code your API key in if you like as an alternative.
string riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY") 
    ?? throw new NullReferenceException();
IRiotBlossomClient client = RiotBlossomCore.CreateClient(riotApiKey);
```

How about using our own `HttpClient` instance or other advanced configuration? An example setup is shown below:
```csharp
using BlossomiShymae.RiotBlossom;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Middleware;

HttpClient httpClient = new()
{
    Timeout = TimeSpan.FromSeconds(15d),
};

InMemoryCache riotCache = new("rb-riot-cache");
InMemoryCache dataCache = new("rb-data-cache")
{
    Expiration = TimeSpan.FromHours(24),
    Size = 10000
};

AlgorithmicLimiter limiter = new(new()
{
    CanThrowOn429 = true,
    CanThrowOnLimit = true,
    ShaperType = LimiterShaper.Spread
});

Retryer retryer = new()
{
    CanThrowOn429 = true,
    RetryCount = 10,
    RetryDelay = TimeSpan.FromSeconds(10d)
};

string riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY")
    ?? throw new NullReferenceException();
```

With that, a fluent client builder is greatly appreciated!

![9335-irys-woah](https://user-images.githubusercontent.com/87099578/232341781-976990f4-40b0-4319-9781-97f18c8fce05.png)
```csharp
using BlossomiShymae.RiotBlossom;
using BlossomiShymae.RiotBlossom.Core;

// Initialization setup shown above...

IRiotBlossomClient client = RiotBlossomCore.CreateClientBuilder()
    .AddRiotApiKey(riotApiKey)
    .AddHttpClient(httpClient)
    .AddRiotMiddlewareStack(b =>
    {
        b.AddInMemoryCache(riotCache);
        b.AddAlgorithmicLimiter(limiter);
        b.AddRetryer(retryer);
        return b;
    })
    .AddDataMiddlewareStack(b =>
    {
        b.AddInMemoryCache(dataCache);
        b.AddRetryer(retryer);
        return b;
    })
    .Build();
```

## Fetching some data with the Riot API

### League of Legends

This section will cover common requests to the League APIs using RiotBlossom. It
will be very helpful to read the official League documentation before continuing, okie dokie? (⁄ ⁄•⁄ω⁄•⁄ ⁄)⁄

https://developer.riotgames.com/docs/lol

Let us try getting a summoner from the Riot API!
```csharp
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Type;

SummonerDto summoner = await client.Riot.Summoner
    .GetByNameAsync(Platform.NorthAmerica, "uwuie time");
Console.WriteLine(summoner);
```

Output via `ToString`, which internally uses `PrettyPrinter.GetString`:
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

If we're commonly making requests to the same API, we can store an API reference to make requests with instead!

Now how about getting some fresh matches with the summoner we received? >w<
```csharp
using BlossomiShymae.RiotBlossom.Api;
using BlossomiShymae.RiotBlossom.Dto.Riot.Match;

IRiotApi riot = client.Riot;

ImmutableList<string> ids = 
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

Output:

![image](https://user-images.githubusercontent.com/87099578/232168413-19747394-a8f2-4af3-b601-d3bf849d08a7.png)

![7631-watame-smug](https://user-images.githubusercontent.com/87099578/232341935-deff581c-c47b-406c-b6fe-537f680d0632.png)

> B-but I also want to get the champion masteries of a summoner as well...

Not a problem, reader! We will also be using DataDragon to get associated data for champions.

```csharp
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.DataDragon.Champion;
using BlossomiShymae.RiotBlossom.Dto.Riot.ChampionMastery;
using System.Collections.Immutable;

ImmutableList<ChampionMasteryDto> masteries = await client.Riot.ChampionMastery
    .ListBySummonerIdAsync(Platform.NorthAmerica, summoner.Id);
// Get the latest championFull.json from the latest version of DataDragon
string version = await client.DataDragon.GetLatestVersionAsync();
ImmutableDictionary<int, Champion> championDictionary = await client.DataDragon
    .GetChampionDictionaryAsync(version);

// Print champion mastery leaderboard of summoner for champions that have the 'Support' role tag
foreach (ChampionMasteryDto mastery in masteries)
{
    championDictionary.TryGetValue((int)mastery.ChampionId, out Champion? champion);
    if (champion != null && champion.Tags.Contains("Support"))
        Console.WriteLine($"{champion.Name,-16} - {mastery.ChampionPoints,7}");
}
```

Output:
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

### Teamfight Tactics

This section covers basic requests to the Teamfight Tactics APIs. Reading the official documentiation will be helpful before 
continuing! 💚

https://developer.riotgames.com/docs/tft

Let us try to get a <sub><sup>totally cool</sup></sub> summoner using the Riot API. owo

```csharp
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Type;

SummonerDto summoner = await client.Riot.TftSummoner
    .GetByNameAsync(Platform.EuropeWest, "GGoE DarkIntaqt");
Console.WriteLine(summoner);
```

Output:
```json
SummonerDto {
  "AccountId": "pZAUf9KfQ1pSy_SPv6M9p311BBRqvme2XhpI45hDVQCXiF1vZxl__i80",
  "ProfileIconId": 5579,
  "RevisionDate": 1682540120000,
  "Name": "GGoE DarkIntaqt",
  "Id": "XBS4Jdc-iqkoIEvRemXbICjtT3eUK5EQVG9TVTHqr8pFpgFP",
  "Puuid": "5J_4rCSpXpqE1p04HotKp3xXpSp9hnQga-2nkReJLjJuG3QWlxQbQdd9Gk19BKMNTaMl7DNu5rKePQ",
  "SummonerLevel": 313
}
```

We should see what units this summoner had in their most recent match!

```csharp
using BlossomiShymae.RiotBlossom.Dto.Riot.TftMatch;
using System.Collections.Immutable;

ImmutableList<string> matchIds = await client.Riot.TftMatch
    .ListIdsByPuuidAsync(Platform.EuropeWest, summoner.Puuid);
MatchDto match = await client.Riot.TftMatch
    .GetByIdAsync(Platform.EuropeWest, matchIds.First());

match.Info.Participants
    .Find(p => p.Puuid == summoner.Puuid)?.Units
        .ForEach(unit => Console.WriteLine(unit));
```

Output:
```json
UnitDto {
  "Items": [
    3,
    2037,
    2200
  ],
  "character_id": "TFT6_Brand",
  "Chosen": null,
  "Name": "",
  "Rarity": 0,
  "Tier": 2
}
UnitDto {
  "Items": [
    25
  ],
  "character_id": "TFT6_Talon",
  "Chosen": null,
  "Name": "",
  "Rarity": 1,
  "Tier": 3
}
UnitDto {
  "Items": [
    47,
    2037
  ],
  "character_id": "TFT6_Syndra",
  "Chosen": null,
  "Name": "",
  "Rarity": 1,
  "Tier": 2
}
UnitDto {
  "Items": [
    77,
    56,
    55
  ],
  "character_id": "TFT6_Leona",
  "Chosen": null,
  "Name": "",
  "Rarity": 2,
  "Tier": 2
}
UnitDto {
  "Items": [
    29,
    9,
    35
  ],
  "character_id": "TFT6_Jhin",
  "Chosen": null,
  "Name": "",
  "Rarity": 3,
  "Tier": 2
}
UnitDto {
  "Items": [],
  "character_id": "TFT6_Orianna",
  "Chosen": null,
  "Name": "",
  "Rarity": 3,
  "Tier": 2
}
UnitDto {
  "Items": [
    16,
    9
  ],
  "character_id": "TFT6_Draven",
  "Chosen": null,
  "Name": "Draven",
  "Rarity": 3,
  "Tier": 2
}
```

### Legends of Runeterra

This section covers basic requests to the Legends of Runeterra APIs. As always, it is best to read the official documentation 
before continuing! It will make me totes happy. 💜

Unlike League of Legends and Teamfight Tactics, we need to get an account instead of a summoner for looking up. Let us try that!
```csharp
using BlossomiShymae.RiotBlossom.Dto.Riot.Account;
using BlossomiShymae.RiotBlossom.Type;

AccountDto account = await client.Riot.Account.GetAccountByRiotIdAsync(Region.Americas, "ToxicMacaroni", "na1");
Console.WriteLine(account);
```

Output:
```json
AccountDto {
  "Puuid": "hYAy0wsvDJ6XLoAjpk5-pHp2AEpW1AXFbvRhenm2DlZ_j7K58vcWr7CmZeQ5anN_pWgEISrHxcCBaw",
  "GameName": "ToxicMacaroni",
  "TagLine": "NA1"
}
```

Now that we have an account, we can go ahead and look up their most recent match!
```csharp
using BlossomiShymae.RiotBlossom.Dto.Riot.LorMatch;
using System.Collections.Immutable;

ImmutableList<string> matchIds = await client.Riot.LorMatch.ListIdsByPuuidAsync(LorRegion.Americas, account.Puuid);
MatchDto match = await client.Riot.LorMatch.GetByIdAsync(LorRegion.Americas, matchIds.First());
Console.WriteLine(match);
```

Output:
```json
MatchDto {
  "Metadata": {
    "data_version": "2",
    "match_id": "9293ad4d-1bf1-4252-baab-e484ee988c93",
    "Participants": [
      "hYAy0wsvDJ6XLoAjpk5-pHp2AEpW1AXFbvRhenm2DlZ_j7K58vcWr7CmZeQ5anN_pWgEISrHxcCBaw"
    ]
  },
  "Info": {
    "game_mode": "ThePathOfChampions",
    "game_type": "",
    "game_start_time_utc": "2022-06-11T00:08:50.1895727+00:00",
    "game_version": "live-green-3-08-27",
    "Players": [
      {
        "Puuid": "hYAy0wsvDJ6XLoAjpk5-pHp2AEpW1AXFbvRhenm2DlZ_j7K58vcWr7CmZeQ5anN_pWgEISrHxcCBaw",
        "deck_id": "",
        "deck_code": "",
        "Factions": [
          "faction_Piltover_Name"
        ],
        "game_outcome": "win",
        "order_of_play": 1
      }
    ],
    "total_turn_count": 10
  }
}
```

## What about DataDragon?
RiotBlossom supports DataDragon. How about we totes get all of the League of Legends items!?! <sub><sup>least cringe Shymae moment</sup></sub>
```csharp
using BlossomiShymae.RiotBlossom.Dto.DataDragon.Item;

string gameVersion = await client.DataDragon.GetLatestVersionAsync();
ImmutableDictionary<int, Item> itemDictionary = 
    await client.DataDragon.GetItemDictionaryAsync(gameVersion);

itemDictionary
    .ToList()
    .ForEach(kvp => Console.WriteLine($"{kvp.Key}: {kvp.Value.Name}"));

// Moonstone Renewer
Console.WriteLine(itemDictionary[6617]);
```

Output:
```
1001: Boots
1004: Faerie Charm
1006: Rejuvenation Bead
1011: Giant's Belt
1018: Cloak of Agility
...
```
```
Item {
  "Name": "Moonstone Renewer",
  "Rune": {
    "IsRune": false,
    "Tier": 0,
    "Type": null
  },
  "Gold": {
    "Base": 750,
    "Total": 2500,
    "Sell": 1750,
    "Purchasable": true
  },
...
}
```

## CommunityDragon!?
RiotBlossom supports CommunityDragon as well! 💚💜

We know that Gwen's numerical ID is `887`. Let us find out more about her using CommunityDragon!
```csharp
using BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion;

Champion champion = await client.CommunityDragon.GetChampionByIdAsync(887);
Console.WriteLine(champion);
```

Output:
```
Champion {
  "Id": 887,
  "Name": "Gwen",
  "Alias": "Gwen",
  "Title": "The Hallowed Seamstress",
  "ShortBio": "A former doll transformed and brought to life by magic...",
  "TacticalInfo": {
    "Style": 5,
    "Difficulty": 2,
    "DamageType": "kMagic"
  },
  "PlaystyleInfo": {
    "Damage": 3,
    "Durability": 2,
    "CrowdControl": 1,
    "Mobility": 3,
    "Utility": 1
  },
  "SquarePortraitPath": "/lol-game-data/assets/v1/champion-icons/887.png",
  "StingerSfxPath": "/lol-game-data/assets/v1/champion-sfx-audios/887.ogg",
  "ChooseVoPath": "/lol-game-data/assets/v1/champion-choose-vo/887.ogg",
  "BanVoPath": "/lol-game-data/assets/v1/champion-ban-vo/887.ogg",
  "Roles": [
    "fighter",
    "assassin"
  ],
  ...
 }
```

# Using with ASP.NET Core
RiotBlossom can be used with [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0), a cross-platform and open-source web framework.

One way of setting up is to create a service container class for dependency injection.

We can first add a `IHttpClientFactory` to the services collection.
```csharp
var builder = WebApplication.CreateBuilder(args);

// ASP.NET Core setup may differ based on your project selection e.g. Web App, MVC, Blazor
// This example is shortened for brevity

builder.Services.AddHttpClient();
```

Now we can create a service class in the `Services` namespace that will contain an instance of RiotBlossom. Note the use 
of the injected `IHttpClientFactory`. o.o
```csharp
public interface IRiotBlossomService
{
    IRiotBlossomClient Client { get; init; }
}

public class RiotBlossomService : IRiotBlossomService
{
    public IRiotBlossomClient Client { get; init; }

    public RiotBlossomService(IHttpClientFactory httpClientFactory)
    {
        HttpClient httpClient = httpClientFactory.CreateClient();
        httpClient.Timeout = TimeSpan.FromSeconds(15);

        Client = RiotBlossomCore.CreateClientBuilder()
            .AddRiotApiKey(Environment.GetEnvironmentVariable("RIOT_API_KEY") ?? throw new NullReferenceException())
            .AddHttpClient(httpClient)
            .AddRiotMiddlewareStack(b =>
            {
                b.AddAlgorithmicLimiter(new(new()
                {
                    CanThrowOn429 = true,
                    CanThrowOnLimit = true,
                    ShaperType = LimiterShaper.Spread
                }));
                b.AddInMemoryCache(new("rb-riot-cache")
                {
                    Expiration = TimeSpan.FromHours(2),
                    Size = 10000
                });
                return b;
            })
            .AddDataMiddlewareStack(b =>
            {
                b.AddInMemoryCache(new("rb-data-cache")
                {
                    Expiration = TimeSpan.FromHours(6),
                    Size = 20000
                });
                b.AddRetryer(new()
                {
                    CanThrowOn429 = true,
                    RetryCount = 10,
                    RetryDelay = TimeSpan.FromSeconds(5)
                });
                return b;
            })
            .Build();
    }
}
```

Now we can add our created a singleton service, ready for use! Yay!
```csharp
// Add as singleton to share a single instance!
builder.Services.AddSingleton<IRiotBlossomService>();
```

[Learn more on using dependency injection in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0).

# API Interfaces

RiotBlossom currently serves three major API interfaces:
- Riot Games, [`IRiotApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/RiotApi.cs) --> `Riot`
    - Account-v1, [`IAccountApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/AccountApi.cs) --> `Account`
    - Champion-Mastery-v4, [`IChampionMasteryApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ChampionMasteryApi.cs) --> `ChampionMastery`
    - Champion-v3, [`IChampionApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ChampionApi.cs) --> `Champion`
    - Clash-v1, [`IClashApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ClashApi.cs) --> `Clash`
    - League-v4, [`ILeagueApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/LeagueApi.cs) --> `League`
    - Lol-Challenges-v1, [`ILolChallengesApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/LolChallengesApi.cs) --> `LolChallenges`
    - Lol-Status-v4, [`ILolStatusApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/LolStatusApi.cs) --> `LolStatus`
    - Lor-Match-v1, [`ILorMatchApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/LorMatchApi.cs) --> `LorMatch`
    - Lor-Ranked-v1, [`ILorRankedApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/LorRankedApi.cs) --> `LorRanked`
    - Lor-Status-v1, [`ILorStatusApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/LorStatusApi.cs) --> `LorStatus`
    - Match-v5, [`IMatchApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/MatchApi.cs) --> `Match`
    - Spectator-v4, [`ISpectatorApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/SpectatorApi.cs) --> `Spectator`
    - Summoner-v4, [`ISummonerApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/SummonerApi.cs) --> `Summoner`
    - Tft-League-v1, [`ITftLeagueApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/TftLeagueApi.cs) --> `TftLeague`
    - Tft-Match-v1, [`ITftMatchApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/TftMatchApi.cs) --> `TftMatch`
    - Tft-Status-v1, [`ITftStatusApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/TftStatusApi.cs) --> `TftStatus`
    - Tft-Summoner-v1, [`ITftSummonerApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/TftSummonerApi.cs) --> `TftSummoner`
    - Val-Content-v1, [`IValContentApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ValContentApi.cs) --> `ValContent`
    - Val-Match-v1, [`IValMatchApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ValMatchApi.cs) --> `ValMatch`
    - Val-Ranked-v1, [`IValRankedApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ValRankedApi.cs) --> `ValRanked`
    - Val-Status-v1, [`IValStatusApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ValStatusApi.cs) --> `ValStatus`
- CommunityDragon, [`ICommunityDragonApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/CommunityDragonApi.cs) --> `CommunityDragon`
- DataDragon, [`IDataDragonApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/DataDragonApi.cs) --> `DataDragon`

All API interfaces are meant for consumption, not for implementation. ⚠️

## `IRiotApi`

```csharp
Task<T> GetAsync<T>(string route, string path)
```

If you like to make requests to an endpoint not supported by RiotBlossom, this method is available. This will still take full advantage of the Riot middleware plugin system features (limiting, caching, and retrying if you have them set). Just provide a type for JSON deserialization! 
( つ•̀ω•́)つ

```csharp
// With great power comes great responsibility... OwO
var summoner = await client.Riot
    .GetAsync<SummonerDto>("na1", "/lol/summoner/v4/summoners/by-name/uwuie time");
```

# Middleware Plugins

## Overview

RiotBlossom uses pluggable middlewares as part of the HTTP request-response cycle. Creating a middleware plugin requires 
implementing from any of the following interfaces:
- `IRequestMiddleware`
- `IResponseMiddleware`
- `IRetryMiddleware`

As part of the HTTP request-response lifecycle:
- Before request sent (request information goes through request middlewares `IRequestMiddleware[]`)
- On request (request function reference is passed to single retry middleware `IRetryMiddleware`)
- After response received (response information goes through response middlewares `IResponseMiddleware[]`)

Knowing this lifecycle, `MiddlewareStack` is the system composition of `IRequestMiddleware[]`, `IRetryMiddleware`, and `IResponseMiddleware[]`. 
A middleware stack is encapsulated to the APIs it is assigned to. 

RiotBlossom client builder currently does the following:
- `AddRiotMiddlewareStack` - the Riot middleware stack for Riot APIs
- `AddDataMiddlewareStack` - the Data middleware stack for CommunityDragon and DataDragon APIs

Each request processed under the Riot `MiddlewareStack` is asynchronously locked per routing value to maintain data synchronization.

Having separate middleware systems offers more user configuration and flexibility in doing thingies. As an example, Riot `MiddlewareStack` is 
created with a `AlgorithmicLimiter` where Data `MiddlewareStack` does not.

Hopefully the system design was straightforward to understand...

![anime-cirno](https://user-images.githubusercontent.com/87099578/232343424-3aabac5a-5e96-41d6-a1a4-3968952146f3.gif)

<sub><sup>if I had lost you, I am very sorry....</sup></sub>

## Request interface
```csharp
public interface IRequestMiddleware
{
    Task UseRequestAsync(ExecuteInfo info, HttpRequestMessage req, Action next, Action<byte[]> hit);
}
```

- `info`, routing information of request
- `req`, the raw HTTP request message
- `next`, action to invoke for continuing to the next request middleware. Not invoking will end the request middleware chain.
- `hit`, action to invoke for sending cached data

Example plugins:
- AlgorithmicLimiter
- InMemoryCache

## Response interface
```csharp
public interface IResponseMiddleware
{
    Task UseResponseAsync(ExecuteInfo info, HttpResponseMessage res, Action next);
}
```

- `info`, routing information of request
- `res`, the raw HTTP response message
- `next`, action to invoke for continuing to the next response middleware. Not invoking will end the response middleware chain.

Example plugins:
- AlgorithmicLimiter
- InMemoryCache

## Retry interface
```csharp
public interface IRetryMiddleware
{
    Task<HttpResponseMessage> UseRetryAsync(Func<Task<HttpResponseMessage>> resFunc);
}
```

- `resFunc`, function to invoke for receiving a HTTP response

Example plugins:
- Retryer

## Out of the box middleware goodies <3

### AlgorithmicLimiter
```csharp
AlgorithmicLimiter limiter = new(new()
{
    CanThrowOn429 = true,
    CanThrowOnLimit = true,
    ShaperType = LimiterShaper.Burst
});
```
More documentation can be found in the [AlgorithmicLimiter](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Middleware/AlgorithmicLimiter.cs)
class.

### InMemoryCache
```csharp
InMemoryCache riotCache = new("rb-riot-cache");
InMemoryCache dataCache = new("rb-data-cache")
{
    Expiration = TimeSpan.FromHours(24),
    Size = 10000
};
```
More documentation can be found in the [InMemoryCache](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Middleware/InMemoryCache.cs) class.

### Retryer
```csharp
Retryer retryer = new()
{
    CanThrowOn429 = true,
    RetryCount = 10,
    RetryDelay = TimeSpan.FromSeconds(10d)
};
```
More documentation can be found in the [Retryer](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Middleware/Retryer.cs) class.

# Exceptions, oh noes
RiotBlossom does have custom exceptions it uses, so keep these in mind when using the client! 💚
- `CorruptedMatchException`
- `ExhaustedRetryerException`
- `MissingApiKeyException`
- `TooManyRequestsException`
- `WarningLimiterException`

The `Retryer` when used will also throw standard exceptions that it cannot handle:
- `HttpRequestException` (400-499 except 429)
- `ArgumentNullException`
- `InvalidOperationException`
- `Exception`

## CorruptedMatchException
When crawling a large number of matches, it can happen on occassion to get a *bugged* match. RiotBlossom checks this 
for you upon fetching a match or match timeline. 

For more information, please see Riot Developer Relations [#642](https://github.com/RiotGames/developer-relations/issues/642).

## ExhaustedRetryerException
When all retries are used for a `Retryer`, this exception will be thrown.

## MissingApiKeyException
When attempting to make a call to the Riot APIs without having a Riot API key set. This is designed so the CommunityDragon or 
DataDragon APIs can be used without requiring an API key.

## TooManyRequestsException
When a `429 - Too Many Requests` was received in the HTTP request-response cycle for `AlgorithmicLimiter` or `Retryer` 
and `CanThrowOn429` is true.

## WarningLimiterException
When a rate limit was reached for `AlgorithmicLimiter` and `CanThrowOnLimit` is true. Not to be confused with 
the above exception where an actual `429` occurs.

# Types
RiotBlossom uses types to represent named values used for the Riot Games API.
- `ChallengeLevel`
- `LeagueDivision`
- `LeagueQueue`
- `LeagueTier`
- `LorRegion`
- `TftLeagueQueue`
- `Platform`
- `Region`
- `RiotHeader`
- `ValRegion`

## ChallengeLevel
Represents the possible challenge levels for `lol-challenges-v1`.

## LeagueDivision
Represents League ranked divisions for `league-v4`.

## LeagueQueue
Represents League ranked queue types for `league-v4`.

## LeagueTier
Represents League ranks for `league-v4`.

## LorRegion
Represents the available regional routing values used for Legends of Runeterra.

## TftLeagueQueue
Represents Teamfight Tactics ranked queue types for `tft-league-v1`.

## Platform
Represents the available platform routing values used for the Riot API (League of Legends).

[Refer to Developer docs to better understand how routing values work.](https://developer.riotgames.com/docs/lol#routing-values) <3

## Region
Represents the available regional routing values used for the Riot API (League of Legends).

[Refer to Developer docs to better understand how routing values work.](https://developer.riotgames.com/docs/lol#routing-values) <3

## RiotHeader
A structure of string constants used for [Riot rate limiting headers](https://hextechdocs.dev/rate-limiting/).

## ValRegion
Represents the available regional routing values used for VALORANT.

# Utilities
Mappers and converters are also included to get the raw or converted values of the aformentioned types. 
These are used internally for projecting values when making requests to the Riot APIs.
- `LeagueDivisionMapper`
- `LeagueQueueMapper`
- `LeagueTierMapper`
- `LorRegionMapper`
- `TftLeagueQueueMapper`
- `PlatformMapper`
- `PlatformToRegionConverter`
- `PrettyPrinter`
- `RegionMapper`
- `ValRegionMapper`

# Data transfer objects (DTO)
RiotBlossom uses simple objects with no behavior for JSON deserialization. These objects are strongly typed and are 
close to 1-to-1 as possible for property names of the original data transfer objects received.

Data objects that have been commented as `UNDOCUMENTED` do not have an official schema and are likely unstable between any versions. Use at your own risk. ⚠️

[The complete directory of objects used can be found here under the `Dto` namespace.](https://github.com/BlossomiShymae/RiotBlossom/tree/master/BlossomiShymae.RiotBlossom/Dto)

# Dependent packages
- [AsyncKeyedLock](https://github.com/MarkCiliaVincenti/AsyncKeyedLock)
- System.Runtime.Caching

# Contributing
Create an issue or submit a pull request! ˖⁺‧₊˚ ♡ ˚₊‧⁺˖

Before submitting a pull request, be sure to include unit tests if applicable. Unit tests use common objects from 
the [StubConfig file](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossomTests/StubConfig.cs). Be sure to include your Riot API key under the `RIOT_API_KEY` 
system environment variable.

# License
This library is under the MIT license.

# Disclaimer
RiotBlossom isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.

# Appendix
## Star History
[![Star History Chart](https://api.star-history.com/svg?repos=BlossomiShymae/RiotBlossom&type=Date)](https://star-history.com/#BlossomiShymae/RiotBlossom&Date)

## Inspiration

TheDrone7. *shieldbow,* GitHub, [https://github.com/TheDrone7/shieldbow](https://github.com/TheDrone7/shieldbow)

Samuel, Mingwei. *Camille,* GitHub, [https://github.com/MingweiSamuel/Camille](https://github.com/MingweiSamuel/Camille)

Rua, Rob and Maldonis, Jason J. *Orianna,* GitHub, [https://github.com/meraki-analytics/orianna](https://github.com/meraki-analytics/orianna)

## Resources

Ray and Riot Games. *Rate Limiting,* Hextechdocs, [https://hextechdocs.dev/rate-limiting/](https://hextechdocs.dev/rate-limiting/)

[https://developer.riotgames.com/](https://developer.riotgames.com/)

[https://discord.com/invite/riotgamesdevrel](https://discord.com/invite/riotgamesdevrel) (Note: Searching in this Discord contains aggregated information not found elsewhere)

## Conventions

[https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)

[https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model)

