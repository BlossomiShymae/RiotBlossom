using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlossomiShymae.RiotBlossom.Data;

namespace BlossomiShymae.RiotBlossom.Core.Cache
{
    public class CacheTTLConfiguration
    {
        private readonly Dictionary<string, TimeSpan> _ttl = new();

        public CacheTTLConfiguration()
        {
            // CHAMPION-MASTERY-V4
            _ttl[UrlMethod.LolChampionMasteryV4ByEncryptedPuuid] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolChampionMasteryV4ByEncryptedPuuidChampionId] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolChampionMasteryV4ByEncryptedPuuidTop] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolChampionMasteryV4ByEncryptedSummonerId] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolChampionMasteryV4ByEncryptedSummonerIdChampionId] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolChampionMasteryV4ByEncryptedSummonerIdTop] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolChampionMasteryV4ScoresByEncryptedPuuid] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolChampionMasteryV4ScoresByEncryptedSummonerId] = TimeSpan.FromMinutes(10);

            // CHAMPION-V3
            _ttl[UrlMethod.LolChampionV3ChampionRotations] = TimeSpan.FromDays(1);

            // CLASH-V1
            _ttl[UrlMethod.LolClashV1PlayersByPuuid] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolClashV1PlayersBySummonerId] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolClashV1TeamsById] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolClashV1Tournaments] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolClashV1TournamentsById] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolClashV1TournamentsByTeamId] = TimeSpan.FromMinutes(10);

            // LEAGUE-V4
            _ttl[UrlMethod.LeagueV4ChallengerLeagues] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LeagueV4EntriesByEncryptedSummonerId] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LeagueV4EntriesByQueue] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LeagueV4GrandmasterLeagues] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LeagueV4LeaguesById] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LeagueV4MasterLeagues] = TimeSpan.FromMinutes(10);

            // LOL-CHALLENGES-V1
            _ttl[UrlMethod.LolChallengesV1Config] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.LolChallengesV1ConfigById] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.LolChallengesV1Leaderboards] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolChallengesV1Percentiles] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolChallengesV1PercentilesById] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolChallengesV1PlayerDataByPuuid] = TimeSpan.FromMinutes(10);

            // LOL-STATUS-V4
            _ttl[UrlMethod.LolStatusV4PlatformData] = TimeSpan.FromDays(1);

            // MATCH-V5
            _ttl[UrlMethod.LolMatchV5ByMatchId] = TimeSpan.MaxValue;
            _ttl[UrlMethod.LolMatchV5ByPuuid] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.LolMatchV5Timeline] = TimeSpan.MaxValue;

            // SPECTATOR-V4
            _ttl[UrlMethod.LolSpectatorV4ByEncryptedSummonerId] = TimeSpan.FromMinutes(1);
            _ttl[UrlMethod.LolSpectatorV4FeaturedGames] = TimeSpan.FromMinutes(1);

            // SUMMONER-V4
            _ttl[UrlMethod.LolSummonerV4ByAccessToken] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.LolSummonerV4ByEncryptedAccountId] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.LolSummonerV4ByEncryptedPuuid] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.LolSummonerV4ByEncryptedSummonerId] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.LolSummonerV4ByName] = TimeSpan.FromDays(1);

            // LOR-MATCH-V1
            _ttl[UrlMethod.LorMatchV1ById] = TimeSpan.MaxValue;
            _ttl[UrlMethod.LorMatchV1MatchesByPuuid] = TimeSpan.FromMinutes(10);

            // LOR-RANKED-V1
            _ttl[UrlMethod.LorRankedV1Leaderboards] = TimeSpan.FromDays(1);

            // LOR-STATUS-V1
            _ttl[UrlMethod.LorStatusV1PlatformData] = TimeSpan.FromDays(1);

            // ACCOUNT-V1
            _ttl[UrlMethod.RiotAccountV1ByGame] = TimeSpan.FromDays(7);
            _ttl[UrlMethod.RiotAccountV1ByGameName] = TimeSpan.FromDays(7);
            _ttl[UrlMethod.RiotAccountV1ByAccessToken] = TimeSpan.FromDays(7);
            _ttl[UrlMethod.RiotAccountV1ByPuuid] = TimeSpan.FromDays(7);

            // TFT-LEAGUE-V1
            _ttl[UrlMethod.TftLeagueV1Grandmaster] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.TftLeagueV1ById] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.TftLeagueV1Challenger] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.TftLeagueV1EntriesBySummonerId] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.TftLeagueV1EntriesByTier] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.TftLeagueV1LadderByQueue] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.TftLeagueV1Master] = TimeSpan.FromMinutes(10);

            // TFT-MATCH-V1
            _ttl[UrlMethod.TftMatchV1ById] = TimeSpan.MaxValue;
            _ttl[UrlMethod.TftMatchV1MatchesByPuuid] = TimeSpan.FromMinutes(10);

            // TFT-STATUS-V1
            _ttl[UrlMethod.TftStatusV1PlatformData] = TimeSpan.FromDays(1);

            // TFT-SUMMONER-V1
            _ttl[UrlMethod.TftSummonerV1ByAccessToken] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.TftSummonerV1ByEncryptedAccountId] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.TftSummonerV1ByEncryptedPuuid] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.TftSummonerV1ByEncryptedSummonerId] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.TftSummonerV1ByName] = TimeSpan.FromDays(1);
            
            // VAL-CONTENT-V1
            _ttl[UrlMethod.ValContentV1Contents] = TimeSpan.FromDays(1);

            // VAL-MATCH-V1
            _ttl[UrlMethod.ValMatchV1ById] = TimeSpan.MaxValue;
            _ttl[UrlMethod.ValMatchV1MatchesByPuuid] = TimeSpan.FromMinutes(10);
            _ttl[UrlMethod.ValMatchV1RecentMatches] = TimeSpan.FromMinutes(10);

            // VAL-RANKED-V1
            _ttl[UrlMethod.ValRankedV1Leaderboards] = TimeSpan.FromMinutes(10);

            // VAL-STATUS-V1
            _ttl[UrlMethod.ValStatusV1PlatformData] = TimeSpan.FromMinutes(10);

            // DATADRAGON
            _ttl[UrlMethod.DataDragonChampionFull] = TimeSpan.MaxValue;
            _ttl[UrlMethod.DataDragonItem] = TimeSpan.MaxValue;
            _ttl[UrlMethod.DataDragonProfileIcon] = TimeSpan.MaxValue;
            _ttl[UrlMethod.DataDragonRunesReforged] = TimeSpan.MaxValue;
            _ttl[UrlMethod.DataDragonVersions] = TimeSpan.FromHours(1);

            // COMMUNITYDRAGON
            _ttl[UrlMethod.CommunityDragonChampionById] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.CommunityDragonItems] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.CommunityDragonPerks] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.CommunityDragonProfileIcon] = TimeSpan.MaxValue;

            // MERAKI ANALYTICS
            _ttl[UrlMethod.MerakiAnalyticsChampions] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.MerakiAnalyticsChampionByKey] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.MerakiAnalyticsItems] = TimeSpan.FromDays(1);
            _ttl[UrlMethod.MerakiAnalyticsItemById] = TimeSpan.FromDays(1);
        }

        public void SetTTL(string key, TimeSpan timeSpan)
        {
            _ttl[key] = timeSpan;
        }

        public TimeSpan GetTTL(string key)
        {
            return _ttl[key];
        }
    }
}