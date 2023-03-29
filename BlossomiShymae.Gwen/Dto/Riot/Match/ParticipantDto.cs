namespace BlossomiShymae.Gwen.Dto.Riot.Match
{
    public record ParticipantDto
    {
        /// <summary>
        /// The player assists.
        /// </summary>
        public int Assists { get; init; }
        /// <summary>
        /// The amount of times the player killed Baron Nashor.
        /// </summary>
        public int BaronKills { get; init; }
        /// <summary>
        /// The level that is dependent on the number of consecutive kills (champions or creep score) or deaths
        /// </summary>
        public int BountyLevel { get; init; }
        /// <summary>
        /// The champion experience acquired through out a match.
        /// </summary>
        public int ChampExperience { get; init; }
        /// <summary>
        /// The highest champion level achieved.
        /// </summary>
        public int ChampLevel { get; init; }
        /// <summary>
        /// The played champion ID. May be invalid before patch 11.4.
        /// </summary>
        public int ChampionId { get; init; }
        /// <summary>
        /// The played champion name.
        /// </summary>
        public string ChampionName { get; init; } = default!;
        /// <summary>
        /// The transformation value of a champion currently used for Kayn.
        /// <list type="bullet">
        /// <item>
        /// <term>0</term><description>None</description>
        /// </item>
        /// <item>
        /// <term>1</term><description>Slayer, Rhaast, Red Kayn</description>
        /// </item>
        /// <item>
        /// <term>2</term><description>Assassin, Shadow Assassin, Blue Kayn </description>
        /// </item>
        /// </list>
        /// </summary>
        public int ChampionTransform { get; init; }
        /// <summary>
        /// The amount of consumables purchased.
        /// </summary>
        public int ConsumablesPurchased { get; init; }
        /// <summary>
        /// The total amount of damage dealt to buildings.
        /// </summary>
        public int DamageDealtToBuildings { get; init; }
        /// <summary>
        /// The total amount of damage dealt to objectives.
        /// </summary>
        public int DamageDealtToObjectives { get; init; }
        /// <summary>
        /// The total amount of damage dealt to turrets.
        /// </summary>
        public int DamageDealtToTurrets { get; init; }
        /// <summary>
        /// The total amount of self mitigated damage, reduced or blocked through abilities or shields.
        /// </summary>
        public int DamageSelfMitigated { get; init; }
        /// <summary>
        /// The player deaths.
        /// </summary>
        public int Deaths { get; init; }
        /// <summary>
        /// The amount of Control Wards placed.
        /// </summary>
        public int DetectorWardsPlaced { get; init; }
        /// <summary>
        /// The amount of double kills.
        /// </summary>
        public int DoubleKills { get; init; }
        /// <summary>
        /// The amount of drakes killed.
        /// </summary>
        public int DragonKills { get; init; }
        /// <summary>
        /// Whether the player has achieved an assist in the first kill of the match.
        /// </summary>
        public bool FirstBloodAssist { get; init; }
        /// <summary>
        /// Whether the player has achieved the first kill of the match.
        /// </summary>
        public bool FirstBloodKill { get; init; }
        /// <summary>
        /// Whether the player has achieved an assist in bringing down the first tower.
        /// </summary>
        public bool FirstTowerAssist { get; init; }
        /// <summary>
        /// Whether the player has achieved in bringing down the first tower.
        /// </summary>
        public bool FirstTowerKill { get; init; }
        /// <summary>
        /// Whether the game has ended in a early surrender. Mutually exclusive with <see cref="GameEndedInSurrender"/>.
        /// </summary>
        public bool GameEndedInEarlySurrender { get; init; }
        /// <summary>
        /// Whether the game has ended in a surrender. Mutually exclusive with <see cref="GameEndedInEarlySurrender"/>.
        /// </summary>
        public bool GameEndedInSurrender { get; init; }
        /// <summary>
        /// The total gold a player has earned.
        /// </summary>
        public int GoldEarned { get; init; }
        /// <summary>
        /// The total gold a player has spent.
        /// </summary>
        public int GoldSpent { get; init; }
        /// <summary>
        /// The player's individual position that is computed by the game server. Recommended to use
        /// <see cref="TeamPosition"/> in general.
        /// </summary>
        public string IndividualPosition { get; init; } = default!;
        /// <summary>
        /// The amount of inhibitors destroyed.
        /// </summary>
        public int InhibitorKills { get; init; }
        /// <summary>
        /// The amount of inhibitors assisted in destroying.
        /// </summary>
        public int InhibitorTakedowns { get; init; }
        /// <summary>
        /// The amount of inhibitors lost.
        /// </summary>
        public int InhibitorsLost { get; init; }
        /// <summary>
        /// The item ID in slot 0.
        /// </summary>
        public int Item0 { get; init; }
        /// <summary>
        /// The item ID in slot 1.
        /// </summary>
        public int Item1 { get; init; }
        /// <summary>
        /// The item ID in slot 2.
        /// </summary>
        public int Item2 { get; init; }
        /// <summary>
        /// The item ID in slot 3.
        /// </summary>
        public int Item3 { get; init; }
        /// <summary>
        /// The item ID in slot 4.
        /// </summary>
        public int Item4 { get; init; }
        /// <summary>
        /// The item ID in slot 5.
        /// </summary>
        public int Item5 { get; init; }
        /// <summary>
        /// The item ID in slot 6.
        /// </summary>
        public int Item6 { get; init; }
        /// <summary>
        /// The total items purchased in a match.
        /// </summary>
        public int ItemsPurchased { get; init; }
        /// <summary>
        /// The amount of killing sprees a player has achieved.
        /// </summary>
        public int KillingSprees { get; init; }
        /// <summary>
        /// The player kills.
        /// </summary>
        public int Kills { get; init; }
        /// <summary>
        /// The lane position a player has played in. Made obsolete by <see cref="IndividualPosition"/> and <see cref="TeamPosition"/>.
        /// </summary>
        public string Lane { get; init; } = default!;
        /// <summary>
        /// The largest critical strike damage dealt.
        /// </summary>
        public int LargestCriticalStrike { get; init; }
        /// <summary>
        /// The largest amount of consecutive kills accomplished.
        /// </summary>
        public int LargestKillingSpree { get; init; }
        /// <summary>
        /// The largest multiple kills accomplished.
        /// </summary>
        public int LargestMultiKill { get; init; }
        /// <summary>
        /// The longest time a player has managed to survive without dying.
        /// </summary>
        public int LongestTimeSpentLiving { get; init; }
        /// <summary>
        /// The total magic damage dealt.
        /// </summary>
        public int MagicDamageDealt { get; init; }
        /// <summary>
        /// The total magic damage dealt to champions.
        /// </summary>
        public int MagicDamageDealtToChampions { get; init; }
        /// <summary>
        /// The total magic damage taken.
        /// </summary>
        public int MagicDamageTaken { get; init; }
        /// <summary>
        /// The total amount of neutral minions killed e.g. jungle monsters.
        /// </summary>
        public int NeutralMinionsKilled { get; init; }
        /// <summary>
        /// The amount of nexus killed.
        /// </summary>
        public int NexusKills { get; init; }
        /// <summary>
        /// The amount of nexus taken down.
        /// </summary>
        public int NexusTakedowns { get; init; }
        /// <summary>
        /// The amount of nexus lost.
        /// </summary>
        public int NexusLost { get; init; }
        /// <summary>
        /// The total objectives that the player managed to steal away from the enemy team.
        /// </summary>
        public int ObjectivesStolen { get; init; }
        /// <summary>
        /// The total objectives the player assisted in stealing away from the enemy team.
        /// </summary>
        public int ObjectivesStolenAssists { get; init; }
        /// <summary>
        /// The participant ID.
        /// </summary>
        public int ParticipantId { get; init; }
        /// <summary>
        /// The amount of pentakills.
        /// </summary>
        public int PentaKills { get; init; }
        /// <summary>
        /// The player's selected perks for the match.
        /// </summary>
        public PerksDto Perks { get; init; } = new();
        /// <summary>
        /// The total physical damage dealt.
        /// </summary>
        public int PhysicalDamageDealt { get; init; }
        /// <summary>
        /// The total physical damage dealt to champions.
        /// </summary>
        public int PhysicalDamageDealtToChampions { get; init; }
        /// <summary>
        /// The total physical damage taken.
        /// </summary>
        public int PhysicalDamageTaken { get; init; }
        /// <summary>
        /// The equipped profile icon ID of player for the match.
        /// </summary>
        public int ProfileIcon { get; init; }
        /// <summary>
        /// The encrypted PUUID of player.
        /// </summary>
        public string Puuid { get; init; } = default!;
        /// <summary>
        /// The amount of quadrakills.
        /// </summary>
        public int QuadraKills { get; init; }
        /// <summary>
        /// The Riot ID name of player. May not be set.
        /// </summary>
        public string RiotIdName { get; init; } = default!;
        /// <summary>
        /// The Riot ID tag line of player. May not be set.
        /// </summary>
        public string RiotIdTagline { get; init; } = default!;
        /// <summary>
        /// The role position of player. Made obsolote by <see cref="TeamPosition"/> and <see cref="IndividualPosition"/>.
        /// </summary>
        public string Role { get; init; } = default!;
        /// <summary>
        /// The total amount of wards purchased in a match.
        /// </summary>
        public int SightWardsBoughtInGame { get; init; }
        /// <summary>
        /// The amount of times spell 1 has been casted. Normally Q.
        /// </summary>
        public int Spell1Casts { get; init; }
        /// <summary>
        /// The amount of times spell 2 has been casted. Normally W.
        /// </summary>
        public int Spell2Casts { get; init; }
        /// <summary>
        /// The amount of times spell 3 has been casted. Normally E.
        /// </summary>
        public int Spell3Casts { get; init; }
        /// <summary>
        /// The amount of times spell 4 has been casted. Normally R.
        /// </summary>
        public int Spell4Casts { get; init; }
        /// <summary>
        /// The amount of times the first equipped summoner spell has been casted.
        /// </summary>
        public int Summoner1Casts { get; init; }
        /// <summary>
        /// The first equipped summoner ID.
        /// </summary>
        public int Summoner1Id { get; init; }
        /// <summary>
        /// The amount of times the second equipped summoner spell has been casted.
        /// </summary>
        public int Summoner2Casts { get; init; }
        /// <summary>
        /// The second equipped summoner ID.
        /// </summary>
        public int Summoner2Id { get; init; }
        /// <summary>
        /// The encrypted summoner ID of player.
        /// </summary>
        public string SummonerId { get; init; } = default!;
        /// <summary>
        /// The summoner level of player at the time of the match.
        /// </summary>
        public int SummonerLevel { get; init; }
        /// <summary>
        /// The summoner name of player at the time of the match.
        /// </summary>
        public string SummonerName { get; init; } = default!;
        /// <summary>
        /// Whether the team of player has early surrendered.
        /// </summary>
        public bool TeamEarlySurrendered { get; init; }
        /// <summary>
        /// The team ID of player.
        /// </summary>
        public int TeamId { get; init; }
        /// <summary>
        /// The computed position the player has actually played knowing there is one top, one middle, etc.
        /// </summary>
        public string TeamPosition { get; init; } = default!;
        /// <summary>
        /// The amount of time the player has used crowd control on others.
        /// </summary>
        public int TimeCCingOthers { get; init; }
        /// <summary>
        /// The total time played.
        /// </summary>
        public int TimePlayed { get; init; }
        /// <summary>
        /// The total damage dealt.
        /// </summary>
        public int TotalDamageDealt { get; init; }
        /// <summary>
        /// The total damage dealt to champions.
        /// </summary>
        public int TotalDamageDealtToChampions { get; init; }
        /// <summary>
        /// The total damage mitigated by shields placed on teammates.
        /// </summary>
        public int TotalDamageShieldedOnTeammates { get; init; }
        /// <summary>
        /// The total damage taken.
        /// </summary>
        public int TotalDamageTaken { get; init; }
        /// <summary>
        /// The total heals.
        /// </summary>
        public int TotalHeal { get; init; }
        /// <summary>
        /// The total heals applied to teammates.
        /// </summary>
        public int TotalHealsOnTeammates { get; init; }
        /// <summary>
        /// The total amount of minions killed.
        /// </summary>
        public int TotalMinionsKilled { get; init; }
        /// <summary>
        /// The total crowd control time dealt.
        /// </summary>
        public int TotalTimeCCDealt { get; init; }
        /// <summary>
        /// The total time spent dead (grey screen simulator, hehe).
        /// </summary>
        public int TotalTimeSpentDead { get; init; }
        /// <summary>
        /// The total units healed.
        /// </summary>
        public int TotalUnitsHealed { get; init; }
        /// <summary>
        /// The amount of triple kills.
        /// </summary>
        public int TripleKills { get; init; }
        /// <summary>
        /// The total true damage dealt.
        /// </summary>
        public int TrueDamageDealt { get; init; }
        /// <summary>
        /// The total true damage dealt to champions.
        /// </summary>
        public int TrueDamageDealtToChampions { get; init; }
        /// <summary>
        /// The total true damage taken.
        /// </summary>
        public int TrueDamageTaken { get; init; }
        /// <summary>
        /// The amount of turrets destroyed.
        /// </summary>
        public int TurretKills { get; init; }
        /// <summary>
        /// The amount of turrets successfully helped in destroying. 
        /// </summary>
        public int TurretTakedowns { get; init; }
        /// <summary>
        /// The amount of turrets lost.
        /// </summary>
        public int TurretsLost { get; init; }
        /// <summary>
        /// The amount of unreal kills (legendary kill or hexakill).
        /// </summary>
        public int UnrealKills { get; init; }
        /// <summary>
        /// The score calculated by how effective the player was in controlling vision (placing wards, killing wards, 
        /// the amount of enemies spotted by a ward alone).
        /// </summary>
        public int VisionScore { get; init; }
        /// <summary>
        /// The total amount of vision wards purchased in a match.
        /// </summary>
        public int VisionWardsBoughtInGame { get; init; }
        /// <summary>
        /// The wards killed.
        /// </summary>
        public int WardsKilled { get; init; }
        /// <summary>
        /// The wards placed.
        /// </summary>
        public int WardsPlaced { get; init; }
        /// <summary>
        /// Whether the player has won the match.
        /// </summary>
        public bool Win { get; init; }
    }
}
