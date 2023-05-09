# Tutorial: Making requests to CommunityDragon in RiotBlossom

CommunityDragon is an open-source organization that provides scraped data from 
the League of Legends game client and the League Client Update (LCU). Developers 
often prefer using CommunityDragon over DataDragon either due to the lack of 
information provided or inaccuracies present in the game data for the latter.

You will learn how to:
- Fetch a champion meta info
- Fetch a perk meta info
- Fetch an item meta info

## Prerequisites
- Tutorials Overview

## Fetch a champion meta info

Champions in League of Legends have an identifier that is used for associating 
information such as their name, statistics, lore, etc.

Taliyah has the champion ID of `163`. Let us try to find out more about her:

```csharp
var champion = await client.CommunityDragon.GetChampionByIdAsync(163);
Console.WriteLine(champion);
```

The following should be displayed within the console:

```json
Champion {
  "Id": 163,
  "Name": "Taliyah",
  "Alias": "Taliyah",
  "Title": "the Stoneweaver",
  "ShortBio": "Taliyah is a nomadic mage from Shurima, torn between teenage wonder and adult responsibility. She has crossed nearly all of Valoran on a journey to learn the true nature of her growing powers, though more recently she has returned to 
protect her tribe. Some have mistaken her compassion for weakness and paid the ultimate price—for beneath Taliyah's youthful demeanor is a will strong enough to move mountains, and a spirit fierce enough to make the earth itself tremble.",
  "TacticalInfo": {
    "Style": 10,
    "Difficulty": 2,
    "DamageType": "kMagic"
  },
  "PlaystyleInfo": {
    "Damage": 3,
    "Durability": 1,
    "CrowdControl": 2,
    "Mobility": 1,
    "Utility": 3
  },
  ...
}
```

Unlike DataDragon, CommunityDragon does not provide a hash map for champion 
information.

## Fetch a perk meta info

League of Legends runes are also called perks.

Summon Aery has a perk ID of `8214`. Knowing that, we can do the following:

```csharp
var perk = await client.CommunityDragon.GetPerkRuneByIdAsync(8214);
Console.WriteLine(perk);
```

The following should be shown within your console:

```json
PerkRune {
  "Id": 8214,
  "Name": "Summon Aery",
  "MajorChangePatchVersion": "",
  "Tooltip": "Damaging enemy champions with basic attacks or abilities sends Aery to them, dealing <font color='#FFFFFF'>@f5@</font> (+<scaleAP>@f6@</scaleAP>) (+<scaleAD>@f7@</scaleAD>).<br><br>Empower or protecting allies with abilities sends Aery to them, shielding them for <font color='#FFFFFF'>@f8@</font> (+<scaleAP>@f9@</scaleAP>) (+<scaleAD>@f10@</scaleAD>).<br><br>Aery cannot be sent out again until she returns to you.<br><br><hr><br>Aery has attacked enemies <font color='#FFFFFF'>@f1@</font> times for a total of <font color='#FFFFFF'>@f3@</font> damage.<br>Aery has helped allies <font color='#FFFFFF'>@f2@</font> times, shielding a total of <font color='#FFFFFF'>@f4@</font> damage.",
  "ShortDesc": "Your attacks and abilities send Aery to a target, damaging enemies or shielding allies.",
  "LongDesc": "Damaging enemy champions with basic attacks or abilities sends Aery to them, dealing 10 - 40 based on level (+<scaleAP>0.1 AP</scaleAP>) (+<scaleAD>0.15 bonus AD</scaleAD>).<br><br>Empower or protecting allies with abilities sends Aery to them, shielding them for 30 - 75 based on level (+<scaleAP>0.22 AP</scaleAP>) (+<scaleAD>0.35 bonus AD</scaleAD>).<br><br>Aery cannot be sent out again until she returns to you.",
  "RecommendationDescriptor": "Poke Damage",
  "IconPath": "/lol-game-data/assets/v1/perk-images/Styles/Sorcery/SummonAery/SummonAery.png",
  "EndOfGameStatDescs": [
    "Damage Dealt: @eogvar1@",
    "Damage Shielded: @eogvar2@"
  ],
  "RecommendationDescriptorAttributes": {}
}
```

Caching the perks hash map would be totes amazing instead of having to request it 
each time we need to get perk information:

```csharp
var perkDictionary = await client.CommunityDragon.GetPerkRuneDictionaryAsync();
var perk = perkDictionary[8214];
```

## Fetch an item meta info

League of Legends shop items are simply called items.

Archangel's Staff has an item ID of `3003`. Let us try do to the following:

```csharp
var item = await client.CommunityDragon.GetItemByIdAsync(3003);
Console.WriteLine(item);
```

The console should display the following infosies:

```json
Item {
  "Id": 3003,
  "Name": "Archangel's Staff",
  "Description": "<mainText><stats><attention> 70</attention> Ability Power<br><attention> 500</attention> Mana<br><attention> 200</attention> Health<br><attention> 10</attention> Ability Haste</stats><br><li><passive>Awe:</passive> Gain Ability Power equal to bonus Mana.<li><passive>Mana Charge:</passive> Strike a target with an Ability to consume a charge and gain 3 bonus Mana, doubled if the target is a champion. Grants a maximum of 360 Mana at which point this item transforms into <rarityLegendary>Seraph's Embrace</rarityLegendary>.<br><br><rules>Gain a new <passive>Mana Charge</passive> every 8 seconds (max 4).</rules></mainText><br>",
  "Active": false,
  "InStore": true,
  "From": [
    3070,
    3067,
    1058
  ],
  ...
}
```

As always, caching is the totes better practice~*

```csharp
var itemDictionary = await client.CommunityDragon.GetItemDictionaryAsync();
var item = itemDictionary[3003];
```

Yay! Thank you for completing this tutorial!

![love-ya](/img/tutorials-cd-love-ya.png)