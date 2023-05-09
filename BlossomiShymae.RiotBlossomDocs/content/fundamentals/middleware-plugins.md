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