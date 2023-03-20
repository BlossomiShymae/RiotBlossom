using Gwen.Core.Wrapper;
using Gwen.Dto.Riot.League;
using Gwen.Dto.Riot.Match;
using Gwen.Dto.Riot.Summoner;
using Gwen.Type;
using System.Collections.Immutable;

namespace Gwen.SewingKit
{
	/// <summary>
	/// A helper container that provides <see cref="MatchDto"/> related asynchronous enumerables for continous
	/// iteration. Useful for crawling matches.
	/// </summary>
	public class MatchThread
	{
		private readonly IGwenClient _gwen;

		public MatchThread(IGwenClient gwen)
		{
			_gwen = gwen;
		}

		/// <summary>
		/// Get the next League match from asynchronous enumerable with given parameters. Will loop back to start of 
		/// League entries when end is reached.
		/// </summary>
		/// <returns></returns>
		public async IAsyncEnumerable<MatchDto> GetNextAsync()
		{
			while (true)
			{
				string latestVersion = await _gwen.DDragon.GetLatestVersionAsync();
				int[] latestVersions = latestVersion
					.Split(".", StringSplitOptions.RemoveEmptyEntries)
					.Take(2)
					.Select(x => int.Parse(x))
					.ToArray();
				ImmutableList<LeagueEntryDto> leagueEntryCollection = await _gwen.Riot.League.ListLeagueEntriesAsync(PlatformRoute.NorthAmerica, LeagueQueue.RankedSolo5x5, LeagueTier.Diamond, LeagueDivision.II);
				IEnumerable<string> summonerIdCollection = leagueEntryCollection.Select(x => x.SummonerId);
				foreach (string summonerId in summonerIdCollection)
				{
					SummonerDto summoner = await _gwen.Riot.Summoner.GetByIdAsync(PlatformRoute.NorthAmerica, summonerId);

					int start = 0;
					int count = 100;
					bool isOldGameVersion = false;
					while (true)
					{
						ImmutableList<string> matchIdCollection = await _gwen.Riot.Match.ListIdsByPuuidAsync(RegionalRoute.Americas, summoner.Puuid, new() { Count = count, Start = start });
						if (matchIdCollection.Count == 0)
							break;
						foreach (string matchId in matchIdCollection)
						{
							MatchDto match = await _gwen.Riot.Match.GetByIdAsync(RegionalRoute.Americas, matchId);
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
