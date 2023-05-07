# Overview of RiotBlossom

RiotBlossom is an asynchronous, extensible, and magical Riot Games API wrapper library for C#. ☆*:.｡.o(≧▽≦)o.｡.:*☆

This library helps to make things totes' easier! Goodies include naive cache, rate limiter, and retryer middleware plugins out of the box. Other services such as DataDragon and CommunityDragon are also supported! ＼(＾▽＾)／

This library is currently compatible with .NET 6 and higher.

## Why use RiotBlossom?
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