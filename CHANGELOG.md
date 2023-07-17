# RiotBlossom 1.2.0 - WOW

A quality-of-life release with added support for Meraki Analytics! 💜

## Meraki Analytics support (17e889f)
- **Api.MerakiAnalytics**: Add API interface
- **Dto.MerakiAnalytics**: **NEW**
    - `Champion`
        - `Ability`
        - `AttributeRatings`
        - `Champion`
        - `Chroma`
        - `Cooldown`
        - `Cost`
        - `DescriptionDto`
        - `Effect`
        - `Leveling`
        - `Modifier`
        - `Price`
        - `Rarities`
        - `Skin`
        - `Stats`
    - `Common`
        - `Stat`
    - `Item`
        - `Active`
        - `Item`
        - `Passive`
        - `Prices`
        - `Shop`
        - `Stats`

## Extensions support (a4daa4f)
Available enums have been turbo-charged with extensions! No need to deal with converters/mappers anymore.

Example excerpt from the documentation:
```csharp
// => "na1"
Platform.NorthAmerica.GetId();
```

```csharp
// => "americas"
Platform.Brazil.GetRegionId();
```

```csharp
// => "ja_JP"
Platform.Japan.GetDefaultLocale();
```

Affected enums:
- `LeagueDivision`
- `LeagueQueue`
- `LeagueTier`
- `LorRegion`
- `Platform`
- `Region`
- `TftLeague`
- `ValRegion`

More information and examples can be found in the documentation under **Fundamentals > Extensions**! :3

## Features
- **Api.Riot**: Add `GetAsync` overload that allows passing HTTP headers (f11c14c36f094eb5e63c063029ab8061b1f5741e)
  - This should make it possible to use the RSO endpoints manually~*
- **Api.CommunityDragon**: Add `GetAsync` method for low-level requests (4262f72a249bd29d7037bbb0d7c9f63b3db03724)
- **Core.PrettyPrinter**: Add overload method `GetPrettyString` for manually setting the class name
- **Dto**: Add abstract `DataObject` superclass for namespace (b8d1286)
  - All objects under the namespace now inherit from the above record class
- **Type.LeagueTier**: Add `Emerald` tier (ee41d9b)

# Minor breaking changes
- **MatchlistEntryDto**: Replace `TeamId` with `QueueId` (823ce8a0be08e2d623f3a14cc3fa12a1f6175bc6)
  - Another bug fix cause yeah :3

# RiotBlossom 1.1.0 - Bee Happy 🐝

This is a quite chubby release. The most notable features include **Legends of Runeterra** and **VALORANT** support! 💚

## Legends of Runeterra support (236c8ba)
- **Api.Riot**: Add `lor-match-v1` endpoint via `ILorMatch`, `LorMatch`
- **Api.Riot** Add `lor-ranked-v1` endpoint via `ILorRanked`, `LorRanked`
- **Api.Riot**: Add `lor-status-v1` endpoint via `ILorStatus`, `LorStatus`
- **Type**: Add `LorRegion` enum
- **Core**: Add `LorRegionMapper` mapper
- **Dto.Riot**: Additions
  - `LorRanked.PlayerDto`
  - `LorRanked.LeaderboardDto`
  - `LorMatch.InfoDto`
  - `LorMatch.MatchDto`
  - `LorMatch.MetadataDto`
  - `LorMatch.PlayerDto`

## VALORANT support (2159da9)

- **Api.Riot**: Add `val-content-v1` endpoint via `IValContent`, `ValContent`
- **Api.Riot**: Add `val-match-v1` endpoint via `IValMatch`, `ValMatch`
- **Api.Riot**: Add `val-ranked-v1` endpoint via `IValRanked`, `ValRanked`
- **Api.Riot**: Add `val-status-v1` endpoint via `IValStatus`, `ValStatus`
- **Type**: Add `ValRegion` enum
- **Core**: Add `ValRegionMapper` mapper
- **Dto.Riot**: Additions
  - `ValContent`
    - `ActDto`
    - `ContentDto`
    - `ContentItemDto`
    - `LocalizedNamesDto`
  - `ValMatch`
    - `AbilityCastsDto`
    - `AbilityDto`
    - `CoachDto`
    - `DamageDto`
    - `EconomyDto`
    - `FinishingDamageDto`
    - `KillDto`
    - `LocationDto`
    - `MatchDto`
    - `MatchInfoDto`
    - `MatchlistDto`
    - `MatchlistEntryDto`
    - `PlayerDto`
    - `PlayerLocationsDto`
    - `PlayerRoundStatsDto`
    - `PlayerStatsDto`
    - `RecentMatchesDto`
    - `RoundResultDto`
    - `TeamDto`
  - `ValRanked`
    - `LeaderboardDto`
    - `PlayerDto`

## Features
- **Core**: Add `PrettyPrinter` for getting pretty printed strings (b20d494)
    - Should be useful for printing `System.Collections` namespace objects in the console
- **Dto**: Update `ToString` to not use compiler-generated implementation, instead use `PrettyPrinter.ToString`
    - Should be an improvement for usability and debugging purposes
- **Api.Riot**: Add `GetAsync` method for "low-level" get requests (7d34814)

## Minor breaking changes
- **AccountDto**: Change `GameName` and `TagLine` property types to be nullable (cc1518b)
    - This is a bug fix to match the official schema but is included here as a heads up, (°▽°)

## Documentation
- Add champion mastery example for **League of Legends**
- Add data fetching walkthroughs for **Teamfight Tactics** and **Legends of Runeterra**
- Add sub-interfaces for the API interfaces section
- Add a section showing example usage with ASP.NET Core

# RiotBlossom 1.0.1
- Improve performance of `PropertiesToQueryConverter`. Thank you very much for your contribution, @AoshiW! <3

# RiotBlossom 1.0.0
- Initial totes release
