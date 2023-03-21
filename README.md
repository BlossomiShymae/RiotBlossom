# Gwen
 
![gwen_api_banner](https://user-images.githubusercontent.com/87099578/226517556-7d1b70bc-3ecb-4fbc-b04d-e4062c49353b.png)

An asynchronous, extensible, and magical Riot Games API wrapper library for C#. ☆*:.｡.o(≧▽≦)o.｡.:*☆

Our magical doll helps to make things totes' easier! This library includes naive cache, rate limter, and retryer middleware plugins 
out of the box. Other services such as DataDragon and CommunityDragon are also supported! ＼(＾▽＾)／

# Features
- Asynchronous and immutable API.
- Extensible HTTP middleware (express.js inspired).
- Caching, rate limiting, and request retrying by default.
- League of Legends API support.
- Gwen. (੭ु ›ω‹ )੭ु⁾⁾♡

# Installation
Install via NuGet, `BlossomiShymae.Gwen`.
For package manager console:
```
Install-Package BlossomiShymae.Gwen
```
Or the .NET CLI:
```
dotnet add package BlossomiShymae.Gwen
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
The API client is accessed by using the static constructor in `GwenCore`. By default, `GwenCore.Settings` will create 
a new instance of `HttpClient` and `XMiddlewares`. `XMiddlewares` will use the default implementation (`XLimiter`, `XRetryer`, and `XMemoryCache`).
```csharp
using BlossomiShymae.Gwen.Core;

IGwenClient gwen = GwenCore.CreateClient(
	new GwenCore.Settings
	{
		RiotApiKey = "RGAPI-snippy-snip"
	}
);
```

We can use a dependency injected `HttpClient` or add our own middleware implementation if needed:
```csharp
using BlossomiShymae.Gwen;
using BlossomiShymae.Gwen.Core;
using BlossomiShymae.Gwen.XMiddleware;

// Custom middleware initialization
var xRedisCache = new XRedisCache();

GwenCore.Settings settings = new()
{
	RiotApiKey = "RGAPI-snippy-snip",
	HttpClient = httpClient,
	XMiddlewares = new()
	{
		XRequests = ImmutableArray.Create(new IRequestMiddleware[]
		{
			// Passing the middleware instance assuming it implements IRequestMiddleware
			xRedisCache,
			XLimiter.Default
		}),
		XResponses = ImmutableArray.Create(new IResponseMiddleware[]
		{
			// Passing the middleware instance assuming it implements IResponseMiddleware
			xRedisCache,
			XLimiter.Default
		}),
		XRetry = XMiddleware.XRetryer.Default
	}
};

IGwenClient gwen = GwenCore.CreateClient(settings);
```

## With Riot API
Retrieving a `SummonerDto`
```csharp
using BlossomiShymae.Gwen.Dto.Riot.Summoner;
using BlossomiShymae.Gwen.Type;

SummonerDto summoner = await gwen.Riot.Summoner.GetByNameAsync(PlatformRoute.NorthAmerica, "uwuie time");
Console.WriteLine(summoner.SummonerLevel);
```

Getting a `MatchDto`
```csharp
using BlossomiShymae.Gwen.Dto.Riot.Match;
using BlossomiShymae.Gwen.Type;

ImmutableList<string> ids = await gwen.Riot.Match.ListIdsByPuuidAsync(RegionalRoute.Americas, summoner.Puuid);
MatchDto match = await gwen.Riot.Match.GetByIdAsync(RegionalRoute.Americas, ids.First());
```

## With CommunityDragon API
Fetch `Champion` for Gwen's ID of `887`.
```csharp
using BlossomiShymae.Gwen.Dto.CDragon.Champion;

Champion champion = await gwen.CDragon.GetChampionByIdAsync(887);
// => "The Hallowed Seamstress"
Console.WriteLine(champion.Title);
```

## With DataDragon API
Get a dictionary of all items from latest game version.
```csharp
using BlossomiShymae.Gwen.Dto.DDragon.Item;

string gameVersion = await gwen.DDragon.GetLatestVersion();
ImmutableDictionary<int, Item> itemDictionary = await gwen.DDragon.GetItemDictionaryAsync(gameVersion);
```

# Contributing


# License
This library is under the MIT license.

# Disclaimer
Gwen isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
