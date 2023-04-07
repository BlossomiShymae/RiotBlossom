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

IRiotBlossomClient client = RiotBlossomCore.CreateClient(
	new RiotBlossomCore.Settings
	{
		RiotApiKey = "RGAPI-a0a0a0a0-aa0a-0a00-a00a-a0a000a0a000"
	}
);
```

`RiotMiddlewareStack` and `DataMiddlewareStack` are dedicated middleware stacks. The default implementation is shown below:
- Riot API => `RiotMiddlewareStack` => (`InMemoryCache`, `AlgorithmicLimiter`, `Retryer`)
- DataDragon, CommunityDragon API => `DataMiddlewareStack` => (`InMemoryCache`, `Retryer`)

We can use a dependency injected `HttpClient` or set own middleware implementation if needed:
```csharp
using BlossomiShymae.RiotBlossom;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Middleware;

// NOT INCLUDED
// Custom cache middleware using Redis
RedisCache riotCache = new();
RedisCache dataCache = new();

// Other middleware
AlgorithmicLimiter limiter = new();

RiotBlossomCore.Settings settings = new()
{
	RiotApiKey = "RGAPI-a0a0a0a0-aa0a-0a00-a00a-a0a000a0a000",
	HttpClient = httpClient,
	RiotMiddlewareStack = new()
	{
		RequestSeries = ImmutableArray.Create(new IRequestMiddleware[] { riotCache, limiter }),
		ResponseSeries = ImmutableArray.Create(new IResponseMiddleware[] { riotCache, limiter }),
		Retry = new Retryer()
	},
	DataMiddlewareStack = new()
	{
		RequestSeries = ImmutableArray.Create(new IRequestMiddleware[] { dataCache }),
		ResponseSeries = ImmutableArray.Create(new IResponseMiddleware[] { dataCache }),
		Retry = new Retryer()
	}
};

IRiotBlossomClient client = RiotBlossomCore.CreateClient(settings);
```

## With Riot API
Retrieving a `SummonerDto`
```csharp
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Type;

SummonerDto summoner = await client.Riot.Summoner.GetByNameAsync(PlatformRoute.NorthAmerica, "uwuie time");
Console.WriteLine(summoner);
```

Getting a `MatchDto`
```csharp
using BlossomiShymae.RiotBlossom.Dto.Riot.Match;
using BlossomiShymae.RiotBlossom.Type;

ImmutableList<string> ids = await client.Riot.Match.ListIdsByPuuidAsync(RegionalRoute.Americas, summoner.Puuid);
// Or alternatively with a PlaformRoute enum
ids = await client.Riot.Match.ListIdsByPuuidAsync(PlatformRoute.NorthAmerica, summoner.Puuid);

MatchDto match = await client.Riot.Match.GetByIdAsync(RegionalRoute.Americas, ids.First());
```

## With CommunityDragon API
Fetch a `CDragon.Champion` for Gwen's numerical ID of `887`.
```csharp
using BlossomiShymae.RiotBlossom.Dto.CDragon.Champion;

Champion champion = await client.CDragon.GetChampionByIdAsync(887);
// => "The Hallowed Seamstress"
Console.WriteLine(champion.Title);
```

## With DataDragon API
Get a dictionary of all items from latest game version.
```csharp
using BlossomiShymae.RiotBlossom.Dto.DDragon.Item;

string gameVersion = await client.DDragon.GetLatestVersion();
ImmutableDictionary<int, Item> itemDictionary = await client.DDragon.GetItemDictionaryAsync(gameVersion);
```

# Contributing


# License
This library is under the MIT license.

# Disclaimer
RiotBlossom isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
