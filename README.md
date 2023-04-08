# RiotBlossom
 
An asynchronous, extensible, and magical Riot Games API wrapper library for C#. ☆*:.｡.o(≧▽≦)o.｡.:*☆

This library helps to make things totes' easier! Goodies include naive cache, rate limiter, and retryer middleware plugins 
out of the box. Other services such as DataDragon and CommunityDragon are also supported! ＼(＾▽＾)／

# Features
- Asynchronous and immutable API.
- Extensible HTTP middleware system (express.js inspired).
- In-memory caching, burst rate limiting, and automatic retrying by default.
- League of Legends API support.
- Magic. (੭ु ›ω‹ )੭ु⁾⁾♡

# Installation
Install via NuGet, `BlossomiShymae.RiotBlossom`.
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
- ❌ League-Exp-v4 (will not support as this is an experimental endpoint)
- ✅ League-v4
- ✅ Lol-Challenges-v1
- ✅ Lol-Status-v4
- ✅ Match-v5
- ✅ Spectator-v4
- ✅ Summoner-v4
- ❌ Tournament-Stub-v4 (endpoint that is associated with being unreliable)
- ❌ Tournament-v4 (will not support)

### Teamfight Tactics
- ➖ Tft-League-v1
- ➖ Tft-Match-v1
- ➖ Tft-Status-v1
- ➖ Tft-Summoner-v1

### Legends of Runeterra
- ➖ Lor-Deck-v1
- ➖ Lor-Inventory-v1
- ➖ Lor-Match-v1
- ➖ Lor-Ranked-v1
- ➖ Lor-Status-v1

### Valorant
- ➖ Val-Content-v1
- ➖ Val-Match-v1
- ➖ Val-Ranked-v1
- ➖ Val-Status-v1

## DataDragon
- ✅ Champions (`championFull.json`)
- ✅ Items (`item.json`)
- ✅ Perks (`runesReforged.json`)

## CommunityDragon
- ✅ Champions ([rcp-be-lol-game-data/global/default/v1/champions](https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/champions/))
- ✅ Items (`items.json`)
- ✅ Perks (`perks.json`)

# Usage
The API client is accessed by using the static constructor in `RiotBlossomCore`. By default, `RiotBlossomCore.Settings` will create 
a new instance of `HttpClient`, `RiotMiddlewareStack`, and `DataMiddlewareStack`.
```csharp
using BlossomiShymae.RiotBlossom.Core;

IRiotBlossomClient client = RiotBlossomCore.CreateClient(new()
{
    RiotApiKey = riotApiKey
});
```

`RiotMiddlewareStack` and `DataMiddlewareStack` are dedicated middleware stacks. The default implementation is shown below:
- Riot API => `RiotMiddlewareStack` => (`InMemoryCache`, `AlgorithmicLimiter`, `Retryer`)
- DataDragon, CommunityDragon API => `DataMiddlewareStack` => (`InMemoryCache`, `Retryer`)

We can use a dependency injected `HttpClient` or set own middleware implementation if needed:
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
    Expiration = 24,
    Size = 10000
};

AlgorithmicLimiter limiter = new()
{
    CanThrowOn429 = true,
    ShaperType = LimiterShaper.Burst
};

Retryer retryer = new()
{
    CanThrowOn429 = true,
    RetryCount = 10,
    RetryDelay = TimeSpan.FromSeconds(10d)
};

RiotBlossomCore.Settings settings = new()
{
    HttpClient = httpClient,
    RiotApiKey = riotApiKey,
    RiotMiddlewareStack = new()
    {
        RequestSeries = ImmutableArray.Create(new IRequestMiddleware[] { riotCache, limiter }),
        ResponseSeries = ImmutableArray.Create(new IResponseMiddleware[] { riotCache, limiter }),
        Retry = retryer
    },
    DataMiddlewareStack = new()
    {
        RequestSeries = ImmutableArray.Create(new IRequestMiddleware[] { dataCache }),
        ResponseSeries = ImmutableArray.Create(new IResponseMiddleware[] { dataCache }),
        Retry = retryer
    }
};

IRiotBlossomClient client = RiotBlossomCore.CreateClient(settings);
```

## With Riot API
Let us try getting a summoner from the Riot API!
```csharp
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Type;

SummonerDto summoner = await client.Riot.Summoner.GetByNameAsync(PlatformRoute.NorthAmerica, "uwuie time");
Console.WriteLine(summoner);
```

Output:
```
SummonerDto { AccountId = 0WvZHECxpBFNlntYzcCNyDkGeaqA6vthcLsklngrPVYofWE, ProfileIconId = 5367,
RevisionDate = 1675651090000, Name = uwuie time, Id = Ao5ffQ2dOV-99YKs_iB0g2EGzGD159jXIk2Z5MjvMafLwbQ,
Puuid = Bd1zj7cFt3MlCZl2GI-5N94D2PHRsfpsjl-6ZM9LjXIm90Bz4JAdwR6Kw4fzbSPFfLoQI5p9hGIhfA, SummonerLevel = 936 }
```

If we're commonly making requests to the same API, we can store an API reference to make requests with instead!

Now how about getting some fresh matches with the summoner we received? >w<
```csharp
using BlossomiShymae.RiotBlossom.Api;
using BlossomiShymae.RiotBlossom.Dto.Riot.Match;

IRiotApi riot = client.Riot;

ImmutableList<string> ids = await riot.Match.ListIdsByPuuidAsync(PlatformRoute.NorthAmerica, summoner.Puuid);
List<MatchDto> matches = new();
foreach (string id in ids)
    matches.Add(await riot.Match.GetByIdAsync(PlatformRoute.NorthAmerica, id));

matches
    .First()
    .Info.Participants
    .ForEach(p => Console.WriteLine($"{p.SummonerName}, {p.ChampionName}, {p.Kills}/{p.Deaths}/{p.Assists}"));
```

Output:
```
Aears, Camille, 5/8/1
BIG MONEY 1, Belveth, 5/4/3
The Iranian, Kassadin, 3/2/4
Lotûs, Ashe, 2/5/5
Gairennedyl, Amumu, 2/9/5
AIppano, Karthus, 5/7/13
FZ Shion, Nidalee, 8/1/11
LintRemover8000, Xerath, 2/3/9
Zaxer, Jinx, 11/5/9
uwuie time, Soraka, 2/1/17 
```

## With DataDragon API
RiotBlossom supports DataDragon. How about we totes get all of the League of Legends items!?! *most sane suggestion*
```csharp
using BlossomiShymae.RiotBlossom.Dto.DDragon.Item;

string gameVersion = await client.DDragon.GetLatestVersionAsync();
ImmutableDictionary<int, Item> itemDictionary = await client.DDragon.GetItemDictionaryAsync(gameVersion);

itemDictionary
    .ToList()
    .ForEach(kvp => Console.WriteLine($"{kvp.Key}: {kvp.Value.Name}"));
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

## With CommunityDragon API
RiotBlossom supports CommunityDragon as well! 💚💜

We know that Gwen's numerical ID is `887`. Let us find out more about her using CommunityDragon!
```csharp
using BlossomiShymae.RiotBlossom.Dto.CDragon.Champion;

Champion champion = await client.CDragon.GetChampionByIdAsync(887);
Console.WriteLine(champion);
```

```
Champion { Id = 887, Name = Gwen, Alias = Gwen, Title = The Hallowed Seamstress,
ShortBio = A former doll transformed and brought to life by magic, Gwen wields the very tools that
once created her. She carries the weight of her maker's love with every step, taking nothing for
granted. At her command is the Hallowed Mist, an ancient and protective magic that has blessed
Gwen's scissors, needles, and sewing thread. So much is new to her, but Gwen remains joyfully
determined to fight for the good that survives in a broken world.,  ...}
```

# License
This library is under the MIT license.

# Disclaimer
RiotBlossom isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
