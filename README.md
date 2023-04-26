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
15. [Appendix](#appendix)

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
Let us try getting a summoner from the Riot API!
```csharp
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Type;

SummonerDto summoner = await client.Riot.Summoner
    .GetByNameAsync(Platform.NorthAmerica, "uwuie time");
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
- `TftLeagueQueue`
- `Platform`
- `Region`
- `RiotHeader`

## ChallengeLevel
Represents the possible challenge levels for `lol-challenges-v1`.

## LeagueDivision
Represents League ranked divisions for `league-v4`.

## LeagueQueue
Represents League ranked queue types for `league-v4`.

## LeagueTier
Represents League ranks for `league-v4`.

## TftLeagueQueue
Represents Teamfight Tactics ranked queue types for `tft-league-v1`.

## Platform
Represents the available platform routing values used for the Riot API.

[Refer to Developer docs to better understand how routing values work.](https://developer.riotgames.com/docs/lol#routing-values) <3

## Region
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
- `TftLeagueQueueMapper`
- `PlatformMapper`
- `PlatformToRegionConverter`
- `RegionMapper`

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

