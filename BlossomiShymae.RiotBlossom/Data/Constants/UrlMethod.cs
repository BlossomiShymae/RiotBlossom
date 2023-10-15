using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Data.Constants;

namespace BlossomiShymae.RiotBlossom.Data
{
    public static class UrlMethod
    {
        /// 
        /// PLACEHOLDERS
        /// 
        public static readonly string SummonerName = "{summonerName}";
        public static readonly string Puuid = "{puuid}";
        public static readonly string MatchId = "{matchId}";
        public static readonly string GameName = "{gameName}";
        public static readonly string TagLine = "{tagLine}";
        public static readonly string Game = "{game}";
        public static readonly string EncryptedPuuid = "{encryptedPUUID}";
        public static readonly string EncryptedSummonerId = "{encryptedSummonerId}";
        public static readonly string ChampionId = "{championId}";
        public static readonly string SummonerId = "{summonerId}";
        public static readonly string TeamId = "{teamId}";
        public static readonly string TournamentId = "{tournamentId}";
        public static readonly string Queue = "{queue}";
        public static readonly string Tier = "{tier}";
        public static readonly string Division = "{division}";
        public static readonly string LeagueId = "{leagueId}";
        public static readonly string ChallengeId = "{challengeId}";
        public static readonly string Level = "{level}";
        public static readonly string EncryptedAccountId = "{encryptedAccountId}";
        public static readonly string TournamentCode = "{tournamentCode}";
        public static readonly string ActId = "{actId}";


        ///
        /// STATIC PLACEHOLDERS
        ///
        public static readonly string Version = "{version}";
        public static readonly string Locale = "{locale}";
        public static readonly string ProfileIconId = "{profileIconId}";
        public static readonly string ItemId = "{itemId}";
        public static readonly string ChampionKey = "{championKey}";

        ///
        /// QUERY PARAMETERS
        ///
        public static readonly string PageQuery = "page";
        public static readonly string LimitQuery = "limit";
        public static readonly string StartTimeQuery = "startTime";
        public static readonly string EndTimeQuery = "endTime";
        public static readonly string QueueQuery = "queue";
        public static readonly string TypeQuery = "type";
        public static readonly string StartQuery = "start";
        public static readonly string CountQuery = "count";
        public static readonly string LocaleQuery = "locale";
        public static readonly string SizeQuery = "size";
        public static readonly string StartIndexQuery = "startIndex";

        ///
        /// HEADER PARAMETERS
        ///
        public static readonly string AuthorizationHeader = "Authorization";
        
        // ACCOUNT-V1
        public static readonly string RiotAccountV1ByPuuid = $"/riot/account/v1/accounts/by-puuid/{Puuid}";
        public static readonly string RiotAccountV1ByGameName = $"/riot/account/v1/accounts/by-riot-id/{GameName}/{TagLine}";
        public static readonly string RiotAccountV1ByAccessToken = $"/riot/account/v1/accounts/me";
        public static readonly string RiotAccountV1ByGame = $"/riot/account/v1/active-shards/by-game/{Game}/by-puuid/{Puuid}";

        // CHAMPION-MASTERY-V4
        public static readonly string LolChampionMasteryV4ByEncryptedPuuid = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{EncryptedPuuid}";
        public static readonly string LolChampionMasteryV4ByEncryptedPuuidChampionId = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{EncryptedPuuid}/by-champion/{ChampionId}";
        public static readonly string LolChampionMasteryV4ByEncryptedPuuidTop = $"/lol/champion-mastery/v4/champion-masteries/by-puuid/{EncryptedPuuid}/top";
        public static readonly string LolChampionMasteryV4ByEncryptedSummonerId = $"/lol/champion-mastery/v4/champion-masteries/by-summoner/{EncryptedSummonerId}";
        public static readonly string LolChampionMasteryV4ByEncryptedSummonerIdChampionId = $"/lol/champion-mastery/v4/champion-masteries/by-summoner/{EncryptedSummonerId}/by-champion/{ChampionId}";
        public static readonly string LolChampionMasteryV4ByEncryptedSummonerIdTop = $"/lol/champion-mastery/v4/champion-masteries/by-summoner/{EncryptedSummonerId}/top";
        public static readonly string LolChampionMasteryV4ScoresByEncryptedPuuid = $"/lol/champion-mastery/v4/scores/by-puuid/{EncryptedPuuid}";
        public static readonly string LolChampionMasteryV4ScoresByEncryptedSummonerId = $"/lol/champion-mastery/v4/scores/by-summoner/{EncryptedSummonerId}";

        // CHAMPION-V3
        public static readonly string LolChampionV3ChampionRotations = $"/lol/platform/v3/champion-rotations";

        // CLASH-V1
        public static readonly string LolClashV1PlayersByPuuid = $"/lol/clash/v1/players/by-puuid/{Puuid}";
        public static readonly string LolClashV1PlayersBySummonerId = $"/lol/clash/v1/players/by-summoner/{SummonerId}";
        public static readonly string LolClashV1TeamsById = $"/lol/clash/v1/teams/{TeamId}";
        public static readonly string LolClashV1Tournaments = $"/lol/clash/v1/tournaments";
        public static readonly string LolClashV1TournamentsByTeamId = $"/lol/clash/v1/tournaments/by-team/{TeamId}";
        public static readonly string LolClashV1TournamentsById = $"/lol/clash/v1/tournaments/{TournamentId}";

        // LEAGUE-V4
        public static readonly string LeagueV4ChallengerLeagues = $"/lol/league/v4/challengerleagues/by-queue/{Queue}";
        public static readonly string LeagueV4EntriesByEncryptedSummonerId = $"/lol/league/v4/entries/by-summoner/{EncryptedSummonerId}";
        public static readonly string LeagueV4EntriesByQueue = $"/lol/league/v4/entries/{Queue}/{Tier}/{Division}";
        public static readonly string LeagueV4GrandmasterLeagues = $"/lol/league/v4/grandmasterleagues/by-queue/{Queue}";
        public static readonly string LeagueV4LeaguesById = $"/lol/league/v4/leagues/{LeagueId}";
        public static readonly string LeagueV4MasterLeagues = $"/lol/league/v4/masterleagues/by-queue/{Queue}";

        // LOL-CHALLENGES-V1
        public static readonly string LolChallengesV1Config = $"/lol/challenges/v1/challenges/config";
        public static readonly string LolChallengesV1Percentiles = $"/lol/challenges/v1/challenges/percentiles";
        public static readonly string LolChallengesV1ConfigById = $"/lol/challenges/v1/challenges/{ChallengeId}/config";
        public static readonly string LolChallengesV1Leaderboards = $"/lol/challenges/v1/challenges/{ChallengeId}/leaderboards/by-level/{Level}";
        public static readonly string LolChallengesV1PercentilesById = $"/lol/challenges/v1/challenges/{ChallengeId}/percentiles";
        public static readonly string LolChallengesV1PlayerDataByPuuid = $"/lol/challenges/v1/player-data/{Puuid}";

        // LOL-STATUS-V4
        public static readonly string LolStatusV4PlatformData = $"/lol/status/v4/platform-data";
        
        // LOR-DECK-V1
        public static readonly string LorDeckV1Decks = $"/lor/deck/v1/decks/me";

        // LOR-INVENTORY-V1
        public static readonly string LorInventoryV1Cards = $"/lor/inventory/v1/cards/me";

        // LOR-MATCH-V1
        public static readonly string LorMatchV1MatchesByPuuid = $"/lor/match/v1/matches/by-puuid/{Puuid}/ids";
        public static readonly string LorMatchV1ById = $"/lor/match/v1/matches/{MatchId}";

        // LOR-RANKED-V1
        public static readonly string LorRankedV1Leaderboards = $"/lor/ranked/v1/leaderboards";

        // LOR-STATUS-V1
        public static readonly string LorStatusV1PlatformData = $"/lor/status/v1/platform-data";

        // MATCH-V5
        public static readonly string LolMatchV5ByPuuid = $"/lol/match/v5/matches/by-puuid/${Puuid}/ids";
        public static readonly string LolMatchV5ByMatchId = $"/lol/match/v5/matches/{MatchId}";
        public static readonly string LolMatchV5Timeline = $"/lol/match/v5/matches/{MatchId}/timeline";

        // SPECTATOR-V4
        public static readonly string LolSpectatorV4ByEncryptedSummonerId = $"/lol/spectator/v4/active-games/by-summoner/{EncryptedSummonerId}";
        public static readonly string LolSpectatorV4FeaturedGames = $"/lol/spectator/v4/featured-games";

        // SUMMONER-V4
        public static readonly string LolSummonerV4ByEncryptedAccountId = $"/lol/summoner/v4/summoners/by-account/{EncryptedAccountId}";
        public static readonly string LolSummonerV4ByName = $"/lol/summoner/v4/summoners/by-name/{SummonerName}";
        public static readonly string LolSummonerV4ByEncryptedPuuid = $"/lol/summoner/v4/summoners/by-puuid/{EncryptedPuuid}";
        public static readonly string LolSummonerV4ByAccessToken = $"/lol/summoner/v4/summoners/me";
        public static readonly string LolSummonerV4ByEncryptedSummonerId = $"/lol/summoner/v4/summoners/{EncryptedSummonerId}";

        // TFT-LEAGUE-V1
        public static readonly string TftLeagueV1Challenger = $"/tft/league/v1/challenger";
        public static readonly string TftLeagueV1EntriesBySummonerId = $"/tft/league/v1/entries/by-summoner/{SummonerId}";
        public static readonly string TftLeagueV1EntriesByTier = $"/tft/league/v1/entries/{Tier}/{Division}";
        public static readonly string TftLeagueV1Grandmaster = $"/tft/league/v1/grandmaster";
        public static readonly string TftLeagueV1ById = $"/tft/league/v1/leagues/{LeagueId}";
        public static readonly string TftLeagueV1Master = $"/tft/league/v1/master";
        public static readonly string TftLeagueV1LadderByQueue = $"/tft/league/v1/rated-ladders/{Queue}/top";

        // TFT-MATCH-V1
        public static readonly string TftMatchV1MatchesByPuuid = $"/tft/match/v1/matches/by-puuid/{Puuid}/ids";
        public static readonly string TftMatchV1ById = $"/tft/match/v1/matches/{MatchId}";

        // TFT-STATUS-V1
        public static readonly string TftStatusV1PlatformData = $"/tft/status/v1/platform-data";

        // TFT-SUMMONER-V1
        public static readonly string TftSummonerV1ByEncryptedAccountId = $"/tft/summoner/v1/summoners/by-account/{EncryptedAccountId}";
        public static readonly string TftSummonerV1ByName = $"/tft/summoner/v1/summoners/by-name/{SummonerName}";
        public static readonly string TftSummonerV1ByEncryptedPuuid = $"/tft/summoner/v1/summoners/by-puuid/{EncryptedPuuid}";
        public static readonly string TftSummonerV1ByAccessToken = $"/tft/summoner/v1/summoners/me";
        public static readonly string TftSummonerV1ByEncryptedSummonerId = $"/tft/summoner/v1/summoners/{EncryptedSummonerId}";

        // VAL-CONTENT-V1
        public static readonly string ValContentV1Contents = $"/val/content/v1/contents";

        // VAL-MATCH-V1
        public static readonly string ValMatchV1ById = $"/val/match/v1/matches/{MatchId}";
        public static readonly string ValMatchV1MatchesByPuuid = $"/val/match/v1/matchlists/by-puuid/{Puuid}";
        public static readonly string ValMatchV1RecentMatches = $"/val/match/v1/recent-matches/by-queue/{Queue}";

        // VAL-RANKED-V1
        public static readonly string ValRankedV1Leaderboards = $"/val/ranked/v1/leaderboards/by-act/{ActId}";
        
        // VAL-STATUS-V1
        public static readonly string ValStatusV1PlatformData = $"/val/status/v1/platform-data";

        // DATADRAGON
        public static readonly string DataDragon = "https://ddragon.leagueoflegends.com";
        public static readonly string DataDragonChampionFull = $"/cdn/{Version}/data/{Locale}/championFull.json";
        public static readonly string DataDragonItem = $"/cdn/{Version}/data/{Locale}/item.json";
        public static readonly string DataDragonVersions = $"/api/versions.json";
        public static readonly string DataDragonRunesReforged = $"/cdn/{Version}/data/{Locale}/runesReforged.json";
        public static readonly string DataDragonProfileIcon = $"/cdn/{Version}/img/profileicon/{ProfileIconId}.png";

        // COMMUNITYDRAGON
        public static readonly string CommunityDragon = "https://raw.communitydragon.org";
        public static readonly string CommunityDragonItems = $"/{Version}/plugins/rcp-be-lol-game-data/global/{Locale}/v1/items.json";
        public static readonly string CommunityDragonChampionById = $"/{Version}/plugins/rcp-be-lol-game-data/global/{Locale}/v1/champions/{ChampionId}.json";
        public static readonly string CommunityDragonPerks = $"/{Version}/plugins/rcp-be-lol-game-data/global/{Locale}/v1/perks.json";
        public static readonly string CommunityDragonProfileIcon = $"/{Version}/plugins/rcp-be-lol-game-data/global/{Locale}/v1/profile-icons/{ProfileIconId}.jpg";

        // MERAKI ANALYTICS
        public static readonly string MerakiAnalytics = "https://cdn.merakianalytics.com";
        public static readonly string MerakiAnalyticsItemById = $"/riot/lol/resources/latest/en-US/items/{ItemId}.json";
        public static readonly string MerakiAnalyticsChampionByKey = $"/riot/lol/resources/latest/en-US/champions/{ChampionKey}.json";
        public static readonly string MerakiAnalyticsItems = $"/riot/lol/resources/latest/en-US/items.json";
        public static readonly string MerakiAnalyticsChampions = $"/riot/lol/resources/latest/en-US/champions.json";

        // STATIC DEVELOPER
        public static readonly string StaticDeveloper = "https://static.developer.riotgames.com";
        public static readonly string StaticDeveloperQueues = "/docs/lol/queues.json";
        public static readonly string StaticDeveloperMaps = "/docs/lol/maps.json";
        public static readonly string StaticDeveloperGameModes = "/docs/lol/gameModes.json";
        public static readonly string StaticDeveloperGameTypes = "/docs/lol/gameTypes.json";
    }
}