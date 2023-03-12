namespace Gwen.Dto.Match
{
    internal record ParticipantDto
    {
        public int Assists { get; init; }
        public int BaronKills { get; init; }
        public int BountyLevel { get; init; }
        public int ChampExperience { get; init; }
        public int ChampLevel { get; init; }
        public int ChampionId { get; init; }
        public string ChampionName { get; init; } = default!;
        public int ChampionTransform { get; init; }
        public int ConsumablesPurchased { get; init; }
        public int DamageDealtToBuildings { get; init; }
        public int DamageDealtToObjectives { get; init; }
        public int DamageDealtToTurrets { get; init; }
        public int DamageSelfMitigated { get; init; }
        public int Deaths { get; init; }
        public int DetectorWardsPlaced { get; init; }
        public int DoubleKills { get; init; }
        public int DragonKills { get; init; }
        public bool FirstBloodAssist { get; init; }
        public bool FirstBloodKill { get; init; }
        public bool FirstTowerAsist { get; init; }
        public bool FirstTowerKill { get; init; }
        public bool GameEndedInEarlySurrender { get; init; }
        public bool GameEndedInSurrender { get; init; }
        public int GoldEarned { get; init; }
        public int GoldSpent { get; init; }
        public string IndividualPosition { get; init; } = default!;
        public int InhibitorKills { get; init; }
        public int InhibitorTakedowns { get; init; }
        public int InhibitorsLost { get; init; }
        public int Item0 { get; init; }
        public int Item1 { get; init; }
        public int Item2 { get; init; }
        public int Item3 { get; init; }
        public int Item4 { get; init; }
        public int Item5 { get; init; }
        public int Item6 { get; init; }
        public int ItemsPurchased { get; init; }
        public int KillingSprees { get; init; }
        public int Kills { get; init; }
        public string Lane { get; init; } = default!;
        public int LargestCriticalStrike { get; init; }
        public int LargestKillingSpree { get; init; }
        public int LargestMultiKill { get; init; }
        public int LongestTimeSpentLiving { get; init; }
        public int MagicDamageDealt { get; init; }
        public int MagicDamageDealtToChampions { get; init; }
        public int MagicDamageTaken { get; init; }
        public int NeutralMinionsKilled { get; init; }
        public int NexusKills { get; init; }
        public int NexusTakedowns { get; init; }
        public int NexusLost { get; init; }
        public int ObjectivesStolen { get; init; }
        public int ObjectivesStolenAssists { get; init; }
        public int ParticipantId { get; init; }
        public int PentaKills { get; init; }
        public PerksDto Perks { get; init; } = new();
        public int PhysicalDamageDealt { get; init; }
        public int PhysicalDamageDealtToChampions { get; init; }
        public int PhysicalDamageTaken { get; init; }
        public int ProfileIcon { get; init; }
        public string Puuid { get; init; } = default!;
        public int QuadraKills { get; init; }
        public string RiotIdName { get; init; } = default!;
        public string RiotIdTagline { get; init; } = default!;
        public string Role { get; init; } = default!;
        public int SightWardsBoughtInGame { get; init; }
        public int Spell1Casts { get; init; }
        public int Spell2Casts { get; init; }
        public int Spell3Casts { get; init; }
        public int Spell4Casts { get; init; }
        public int Summoner1Casts { get; init; }
        public int Summoner1Id { get; init; }
        public int Summoner2Casts { get; init; }
        public int Summoner2Id { get; init; }
        public string SummonerId { get; init; } = default!;
        public int SummonerLevel { get; init; }
        public string SummonerName { get; init; } = default!;
        public bool TeamEarlySurrendered { get; init; }
        public int TeamId { get; init; }
        public string TeamPosition { get; init; } = default!;
        public int TimeCCingOthers { get; init; }
        public int TimePlayed { get; init; }
        public int TotalDamageDealt { get; init; }
        public int TotalDamageDealtToChampions { get; init; }
        public int TotalDamageShieldedOnTeammates { get; init; }
        public int TotalDamageTaken { get; init; }
        public int TotalHeal { get; init; }
        public int TotalHealsOnTeammates { get; init; }
        public int TotalMinionsKilled { get; init; }
        public int TotalTimeCCDealt { get; init; }
        public int TotalTimeSpentDead { get; init; }
        public int TotalUnitsHealed { get; init; }
        public int TripleKills { get; init; }
        public int TrueDamageDealt { get; init; }
        public int TrueDamageDealtToChampions { get; init; }
        public int TrueDamageTaken { get; init; }
        public int TurretKills { get; init; }
        public int TurretTakedowns { get; init; }
        public int TurretsLost { get; init; }
        public int UnrealKills { get; init; }
        public int VisionScore { get; init; }
        public int VisionWardsBoughtInGame { get; init; }
        public int WardsKilled { get; init; }
        public int WardsPlaced { get; init; }
        public bool Win { get; init; }
    }
}
