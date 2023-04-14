# RiotBlossom
 
An asynchronous, extensible, and magical Riot Games API wrapper library for C#. ☆*:.｡.o(≧▽≦)o.｡.:*☆

This library helps to make things totes' easier! Goodies include naive cache, rate limiter, and retryer middleware plugins 
out of the box. Other services such as DataDragon and CommunityDragon are also supported! ＼(＾▽＾)／

This library is currently compatible with .NET 6 and higher.

# Table of Contents
1. [Features](#features)
2. [Installation](#installation)
3. [Endpoints](#endpoints)
4. [Quickstart](#quickstart)
5. [API Interfaces](#api-interfaces)
6. [Middleware Plugins](#middleware-plugins)
7. [Exceptions](#exceptions-oh-noes)
8. [Types](#types)
9. [Utilities](#utilities)
10. [Data transfer objects](#data-transfer-objects-dto)
11. [Dependent packages](#dependent-packages)
12. [Contributing](#contributing)
13. [License](#license)
14. [Disclaimer](#disclaimer)

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

# Quickstart
The API client is accessed by using the static constructor in `RiotBlossomCore`. By default, `RiotBlossomCore.Settings` will create 
a new instance of `HttpClient`, `RiotMiddlewareStack`, and `DataMiddlewareStack`.
```csharp
using BlossomiShymae.RiotBlossom.Core;

// You can hard-code your API key in if you like as an alternative.
string riotApiKey = Environment.GetEnvironmentVariable("RIOT_API_KEY") 
    ?? throw new NullReferenceException();
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

## Fetching some data with the Riot API
Let us try getting a summoner from the Riot API!
```csharp
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Type;

SummonerDto summoner = await client.Riot.Summoner
    .GetByNameAsync(PlatformRoute.NorthAmerica, "uwuie time");
Console.WriteLine(summoner);
```

Output:
```
SummonerDto { AccountId = 0WvZHECxpBFNlntYzcCNyDkGeaqA6vthcLsklngrPVYofWE, ProfileIconId = 5367,
RevisionDate = 1675651090000, Name = uwuie time,
Id = Ao5ffQ2dOV-99YKs_iB0g2EGzGD159jXIk2Z5MjvMafLwbQ,
Puuid = Bd1zj7cFt3MlCZl2GI-5N94D2PHRsfpsjl-6ZM9LjXIm90Bz4JAdwR6Kw4fzbSPFfLoQI5p9hGIhfA,
SummonerLevel = 936 }
```

If we're commonly making requests to the same API, we can store an API reference to make requests with instead!

Now how about getting some fresh matches with the summoner we received? >w<
```csharp
using BlossomiShymae.RiotBlossom.Api;
using BlossomiShymae.RiotBlossom.Dto.Riot.Match;

IRiotApi riot = client.Riot;

ImmutableList<string> ids = 
    await riot.Match.ListIdsByPuuidAsync(PlatformRoute.NorthAmerica, summoner.Puuid);
List<MatchDto> matches = new();
foreach (string id in ids)
    matches.Add(await riot.Match.GetByIdAsync(PlatformRoute.NorthAmerica, id));

matches
    .First()
    .Info.Participants
    .ForEach(p => Console
        .WriteLine($"{p.SummonerName}, {p.ChampionName}, {p.Kills}/{p.Deaths}/{p.Assists}"));
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

## CommunityDragon!?
RiotBlossom supports CommunityDragon as well! 💚💜

We know that Gwen's numerical ID is `887`. Let us find out more about her using CommunityDragon!
```csharp
using BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion;

Champion champion = await client.CommunityDragon.GetChampionByIdAsync(887);
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

# API Interfaces

RiotBlossom currently serves three major API interfaces:
- Riot Games, [`IRiotApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/RiotApi.cs) --> `Riot`
- CommunityDragon, [`ICommunityDragonApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/CommunityDragonApi.cs) --> `CommunityDragon`
- DataDragon, [`IDataDragonApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/DataDragonApi.cs) --> `DataDragon`

All API interfaces are meant for consumption, not for implementation. ⚠️

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

Following this lifecycle, `MiddlewareStack` is the system composition of `IRequestMiddleware[]`, `IRetryMiddleware`, and `IResponseMiddleware[]`. 
A middleware stack is encapsulated to the APIs it is assigned to. RiotBlossom settings currently accept the following:
- `RiotMiddlewareStack` - Riot APIs
- `DataMiddlewareStack` - CommunityDragon and DataDragon APIs

Each request processed under `RiotMiddlewareStack` is asynchronously locked per routing value to maintain data synchronization.

Having separate middleware systems offers more user configuration and flexibility in doing thingies. As an example, `RiotMiddlewareStack` is 
created with a `AlgorithmicLimiter` where `DataMiddlewareStack` does not.


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
    Expiration = 24,
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
- `PlatformRoute`
- `RegionalRoute`
- `RiotHeader`

## ChallengeLevel
Represents the possible challenge levels for `lol-challenges-v1`.

## LeagueDivision
Represents League ranked divisions for `league-v4`.

## LeagueQueue
Represents League ranked queue types for `league-v4`.

## LeagueTier
Represents League ranks for `league-v4`.

## PlatformRoute
Represents the available platform routing values used for the Riot API.

[Refer to Developer docs to better understand how routing values work.](https://developer.riotgames.com/docs/lol#routing-values) <3

## RegionalRoute
Represents the available regional routing values used for the Riot API.

[Refer to Developer docs to better understand how routing values work.](https://developer.riotgames.com/docs/lol#routing-values) <3

## RiotHeader
A structure of string constants used for [Riot rate limiting headers](https://hextechdocs.dev/rate-limiting/).

# Utilities
Mappers and converters are also included to get the raw or converted values of the aformentioned types. 
These are used internally for projecting values when making requests to the Riot APIs.
- `LeagueDivisionMapper`
- `LeagueQueueMapper`
- `LeagueTierMapper`
- `PlatformRouteMapper`
- `PlatformToRegionConverter`
- `RegionRouteMapper`

# Data transfer objects (DTO)
RiotBlossom uses simple objects with no behavior for JSON deserialization. These objects are strongly typed and are 
close to 1-to-1 as possible for property names of the original data transfer objects received.

Data objects that have been commented as `UNDOCUMENTED` do not have an official schema and are likely unstable between any versions. Use at your own risk. ⚠️

[The complete directory of objects used can be found here under the `Dto` namespace.](https://github.com/BlossomiShymae/RiotBlossom/tree/master/BlossomiShymae.RiotBlossom/Dto)

# Dependent packages
- AsyncKeyedLock
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
