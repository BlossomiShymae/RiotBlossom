# API Interfaces

RiotBlossom currently serves three major API interfaces:
- Riot Games, [`IRiotApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/RiotApi.cs) --> `Riot`
    - Account-v1, [`IAccountApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/AccountApi.cs) --> `Account`
    - Champion-Mastery-v4, [`IChampionMasteryApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ChampionMasteryApi.cs) --> `ChampionMastery`
    - Champion-v3, [`IChampionApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ChampionApi.cs) --> `Champion`
    - Clash-v1, [`IClashApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ClashApi.cs) --> `Clash`
    - League-v4, [`ILeagueApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/LeagueApi.cs) --> `League`
    - Lol-Challenges-v1, [`ILolChallengesApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/LolChallengesApi.cs) --> `LolChallenges`
    - Lol-Status-v4, [`ILolStatusApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/LolStatusApi.cs) --> `LolStatus`
    - Lor-Match-v1, [`ILorMatchApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/LorMatchApi.cs) --> `LorMatch`
    - Lor-Ranked-v1, [`ILorRankedApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/LorRankedApi.cs) --> `LorRanked`
    - Lor-Status-v1, [`ILorStatusApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/LorStatusApi.cs) --> `LorStatus`
    - Match-v5, [`IMatchApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/MatchApi.cs) --> `Match`
    - Spectator-v4, [`ISpectatorApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/SpectatorApi.cs) --> `Spectator`
    - Summoner-v4, [`ISummonerApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/SummonerApi.cs) --> `Summoner`
    - Tft-League-v1, [`ITftLeagueApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/TftLeagueApi.cs) --> `TftLeague`
    - Tft-Match-v1, [`ITftMatchApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/TftMatchApi.cs) --> `TftMatch`
    - Tft-Status-v1, [`ITftStatusApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/TftStatusApi.cs) --> `TftStatus`
    - Tft-Summoner-v1, [`ITftSummonerApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/TftSummonerApi.cs) --> `TftSummoner`
    - Val-Content-v1, [`IValContentApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ValContentApi.cs) --> `ValContent`
    - Val-Match-v1, [`IValMatchApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ValMatchApi.cs) --> `ValMatch`
    - Val-Ranked-v1, [`IValRankedApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ValRankedApi.cs) --> `ValRanked`
    - Val-Status-v1, [`IValStatusApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/Riot/ValStatusApi.cs) --> `ValStatus`
- CommunityDragon, [`ICommunityDragonApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/CommunityDragonApi.cs) --> `CommunityDragon`
- DataDragon, [`IDataDragonApi`](https://github.com/BlossomiShymae/RiotBlossom/blob/master/BlossomiShymae.RiotBlossom/Api/DataDragonApi.cs) --> `DataDragon`

All API interfaces are meant for consumption, not for implementation. ⚠️

## `IRiotApi`

```csharp
Task<T> GetAsync<T>(string route, string path)
```

If you like to make requests to an endpoint not supported by RiotBlossom, this method is available. This will still take full advantage of the Riot middleware plugin system features (limiting, caching, and retrying if you have them set). Just provide a type for JSON deserialization! 
( つ•̀ω•́)つ

```csharp
// With great power comes great responsibility... OwO
var summoner = await client.Riot
    .GetAsync<SummonerDto>("na1", "/lol/summoner/v4/summoners/by-name/uwuie time");
```