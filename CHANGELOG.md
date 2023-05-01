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
