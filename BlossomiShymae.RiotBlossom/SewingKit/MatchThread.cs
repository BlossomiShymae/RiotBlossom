using BlossomiShymae.RiotBlossom.Core.Wrapper;
using BlossomiShymae.RiotBlossom.Dto.Riot.League;
using BlossomiShymae.RiotBlossom.Dto.Riot.Match;
using BlossomiShymae.RiotBlossom.Dto.Riot.Summoner;
using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.SewingKit
{
    /// <summary>
    /// A helper container that provides <see cref="MatchDto"/> related asynchronous enumerables for continous
    /// iteration. Useful for crawling matches.
    /// </summary>
    public class MatchThread
    {
        private readonly IRiotBlossomClient _client;

        public MatchThread(IRiotBlossomClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Get the next League match from asynchronous enumerable with given parameters. Will loop back to start of 
        /// League entries when end is reached.
        /// </summary>
        /// <param name="latestVersion"></param>
        /// <param name="platformRoute"></param>
        /// <param name="regionalRoute"></param>
        /// <param name="queue"></param>
        /// <param name="tier"></param>
        /// <param name="division"></param>
        /// <returns></returns>
        public async IAsyncEnumerable<MatchDto> GetNextFromLeagueAsync(string latestVersion, PlatformRoute platformRoute, RegionalRoute regionalRoute, LeagueQueue queue, LeagueTier tier, LeagueDivision division)
        {
            while (true)
            {
                int[] latestVersions = latestVersion
                    .Split(".", StringSplitOptions.RemoveEmptyEntries)
                    .Take(2)
                    .Select(x => int.Parse(x))
                    .ToArray();
                ImmutableList<LeagueEntryDto> leagueEntryCollection = await _client.Riot.League.ListLeagueEntriesAsync(platformRoute, queue, tier, division);
                IEnumerable<string> summonerIdCollection = leagueEntryCollection.Select(x => x.SummonerId);
                foreach (string summonerId in summonerIdCollection)
                {
                    SummonerDto summoner = await _client.Riot.Summoner.GetByIdAsync(platformRoute, summonerId);

                    int start = 0;
                    int count = 100;
                    bool isOldGameVersion = false;
                    while (true)
                    {
                        ImmutableList<string> matchIdCollection = await _client.Riot.Match.ListIdsByPuuidAsync(regionalRoute, summoner.Puuid, new() { Count = count, Start = start });
                        if (matchIdCollection.Count == 0)
                            break;
                        foreach (string matchId in matchIdCollection)
                        {
                            MatchDto match = await _client.Riot.Match.GetByIdAsync(regionalRoute, matchId);
                            // Hehe, take 2. >.<
                            int[] gameVersions = match.Info.GameVersion
                                .Split(".", StringSplitOptions.RemoveEmptyEntries)
                                .Take(2)
                                .Select(x => int.Parse(x))
                                .ToArray();
                            if (latestVersions[0] > gameVersions[0] || latestVersions[1] > gameVersions[1])
                            {
                                isOldGameVersion = true;
                                break;
                            }
                            yield return match;
                        }
                        if (isOldGameVersion)
                            break;
                        start += count;
                    }
                }
            }
        }
    }
}
