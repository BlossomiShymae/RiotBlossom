# Types in RiotBlossom

RiotBlossom uses types to represent named values used for the Riot Games API.
- `ChallengeLevel`
- `LeagueDivision`
- `LeagueQueue`
- `LeagueTier`
- `LorRegion`
- `TftLeagueQueue`
- `Platform`
- `Region`
- `RiotHeader`
- `ValRegion`

## ChallengeLevel
Represents the possible challenge levels for `lol-challenges-v1`.

## LeagueDivision
Represents League ranked divisions for `league-v4`.

## LeagueQueue
Represents League ranked queue types for `league-v4`.

## LeagueTier
Represents League ranks for `league-v4`.

## LorRegion
Represents the available regional routing values used for Legends of Runeterra.

## TftLeagueQueue
Represents Teamfight Tactics ranked queue types for `tft-league-v1`.

## Platform
Represents the available platform routing values used for the Riot API (League of Legends).

[Refer to Developer docs to better understand how routing values work.](https://developer.riotgames.com/docs/lol#routing-values) <3

## Region
Represents the available regional routing values used for the Riot API (League of Legends).

[Refer to Developer docs to better understand how routing values work.](https://developer.riotgames.com/docs/lol#routing-values) <3

## RiotHeader
A structure of string constants is used for [Riot rate limiting headers](https://hextechdocs.dev/rate-limiting/).

## ValRegion
Represents the available regional routing values used for VALORANT.