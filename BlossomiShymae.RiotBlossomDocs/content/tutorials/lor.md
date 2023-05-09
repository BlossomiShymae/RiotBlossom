# Tutorial: Making requests to the Legends of Runeterra APIs in RiotBlossom

This awesome tutorial will cover common requests to the Legends of Runeterra APIs with 
RiotBlossom!

You will learn how to:
- Fetch an account
- Fetch match identifiers and matches

## Prerequisites
- [Legends of Runeterra Official Documentation](https://developer.riotgames.com/docs/lor)
- Tutorials Overview

## Fetch an account

Let us try getting an account from the Riot API! Type and save the following 
code below:

```csharp
var account = await client.Riot.Account
    .GetAccountByRiotIdAsync(Region.Americas, "ToxicMacaroni", "na1");
Console.WriteLine(account);
```

The following output should be displayed within your console:

```json
AccountDto {
  "Puuid": "hYAy0wsvDJ6XLoAjpk5-pHp2AEpW1AXFbvRhenm2DlZ_j7K58vcWr7CmZeQ5anN_pWgEISrHxcCBaw",
  "GameName": "ToxicMacaroni",
  "TagLine": "NA1"
}
```

> Do note that `GameName` and `TagLine` are nullable! Not every player has them 
> set for the game.

The preceding string in the console is generated with the `PrettyPrinter` class 
provided by `RiotBlossom.Core`. This makes it totes friendly and easier for reading 
data objects from the console!

## Fetch match identifiers and matches

Now that we have an account, we can go ahead and look up their most recent match:

```csharp

var matchIds = await client.Riot.
    LorMatch.ListIdsByPuuidAsync(LorRegion.Americas, account.Puuid);
var match = await client.Riot.LorMatch.GetByIdAsync(LorRegion.Americas, matchIds.First());
Console.WriteLine(match);
```

This should generate the following output:

```json
MatchDto {
  "Metadata": {
    "data_version": "2",
    "match_id": "9293ad4d-1bf1-4252-baab-e484ee988c93",
    "Participants": [
      "hYAy0wsvDJ6XLoAjpk5-pHp2AEpW1AXFbvRhenm2DlZ_j7K58vcWr7CmZeQ5anN_pWgEISrHxcCBaw"
    ]
  },
  "Info": {
    "game_mode": "ThePathOfChampions",
    "game_type": "",
    "game_start_time_utc": "2022-06-11T00:08:50.1895727+00:00",
    "game_version": "live-green-3-08-27",
    "Players": [
      {
        "Puuid": "hYAy0wsvDJ6XLoAjpk5-pHp2AEpW1AXFbvRhenm2DlZ_j7K58vcWr7CmZeQ5anN_pWgEISrHxcCBaw",
        "deck_id": "",
        "deck_code": "",
        "Factions": [
          "faction_Piltover_Name"
        ],
        "game_outcome": "win",
        "order_of_play": 1
      }
    ],
    "total_turn_count": 10
  }
}
```