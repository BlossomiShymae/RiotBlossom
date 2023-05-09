# Tutorial: Setting up application configuration in RiotBlossom

This coolsies tutorial will show you the basics of creating a client with RiotBlossom 
using basic and advanced configuration!

## Prerequisites
- Get Started

> 
> 
> For both minimal and advanced configuration, you can pass an `string.Empty` or `""` for 
> the Riot API key if you're only going to use CommunityDragon or DataDragon APIs.
>
> Do note that without a key, a `MissingApiKeyException` will be thrown when sending
> a Riot related request! 

## Create a client using minimal configuration

To create a client with the least configuration possible:

```csharp
using BlossomiShymae.RiotBlossom.Core;

string key = Environment.GetEnvironmentVariable("RIOT_API_KEY")
    ?? throw new InvalidOperationException("RIOT_API_KEY must be set!");
var client = RiotBlossomCore.CreateClient(key);
```

Wowie, that was easy! 

![Wow](/img/tutorials-lol-wow.png)

By default, RiotBlossom will create a client instance with spread rate limiting, in-memory 
caching, and retrying enabled. An `HttpClient` will also be initialized interally 
for making web requests with.

## Create a client with advanced configuration

Creating a client with advanced configuration requires accessing the client builder 
interface. This interface allows to inject a `HttpClient` instance and configure 
the middleware plugin systems directly! :D

The following code showcases an example advanced configuration:

```csharp
using BlossomiShymae.RiotBlossom;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Middleware;

string key = Environment.GetEnvironmentVariable("RIOT_API_KEY")
    ?? throw new InvalidOperationException("RIOT_API_KEY must be set!");
HttpClient httpClient = new() 
{
  Timeout = TimeSpan.FromSeconds(5)
};

var client = RiotBlossomCore.CreateClientBuilder()
    .AddRiotApiKey(riotApiKey)
    .AddHttpClient(httpClient)
    .AddRiotMiddlewareStack(b =>
    {
        b.AddInMemoryCache(new("rb-riot-cache"));
        b.AddAlgorithmicLimiter(new(new() 
        {
          CanThrowOn429 = true,
          CanThrowOnLimit = true,
          ShaperType = LimiterShaper.Spread
        }));
        b.AddRetryer(new() {
          CanThrowOn429 = true,
          RetryCount = 3,
          RetryDelay = TimeSpan.FromSeconds(1d)
        });
        return b;
    })
    .AddDataMiddlewareStack(b =>
    {
        b.AddInMemoryCache(new("rb-data-cache") 
        {
          Expiration = TimeSpan.FromHours(24),
          Size = 10000
        });
        b.AddRetryer(new() 
        {
          CanThrowOn429 = true,
          RetryCount = 5,
          RetryDelay = TimeSpan.FromSeconds(1)
        });
        return b;
    })
    .Build();
```

