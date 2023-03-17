using Gwen.Dto.LolChallenges;
using Gwen.Http;
using System.Collections.Immutable;

namespace Gwen.Api.Riot
{
	public interface ILolChallengesApi
	{
		/// <summary>
		/// Get challenge configuration information by ID.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<ChallengeConfigInfoDto> GetConfigInfoByIdAsync(long id);
		/// <summary>
		/// Get a dictionary of challenge percentiles for players who have achieved it.
		/// </summary>
		/// <returns></returns>
		Task<ImmutableDictionary<string, ImmutableDictionary<string, double>>> GetPercentilesAsync();
		/// <summary>
		/// Get challenge percentiles from ID for players who have achieved it.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<ImmutableDictionary<string, double>> GetPercentilesByIdAsync(long id);
		/// <summary>
		/// Get progressed challenge information details for encrypted PUUID.
		/// </summary>
		/// <param name="puuid"></param>
		/// <returns></returns>
		Task<PlayerInfoDto> GetPlayerInfoByPuuidAsync(string puuid);
		/// <summary>
		/// Get the apex players for challenge level e.g. "MASTER", "GRANDMASTER", "CHALLENGER".
		/// </summary>
		/// <param name="level"></param>
		/// <param name="id"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		Task<IEnumerable<ApexPlayerInfoDto>> ListApexPlayerInfosAsync(string level, long id, int limit = 0);
		/// <summary>
		/// List all basic challenge configuration information.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<ChallengeConfigInfoDto>> ListConfigInfosAsync();
	}

	internal class LolChallengesApi : ILolChallengesApi
	{
		private static readonly string _uri = "/lol/challenges/v1/challenges";
		private static readonly string _challengesConfigUri = _uri + "/config";
		private static readonly string _challengesPercentilesUri = _uri + "/percentiles";
		private static readonly string _challengesConfigForChallengeIdUri = _uri + "/{0}/config";
		private static readonly string _challengesTopPlayersByChallengeIdAndLevelUri = _uri + "/{0}/leaderboards/by-level/{1}";
		private static readonly string _challengesPercentilesForChallengeIdUri = _uri + "/{0}/percentiles";
		private static readonly string _challengesProgressedUri = "/lol/challenges/v1/player-data/{0}";
		private readonly ComposableApi<IEnumerable<ChallengeConfigInfoDto>> _challengeConfigInfoDtosApi;
		private readonly ComposableApi<ImmutableDictionary<string, ImmutableDictionary<string, double>>> _challengePercentilesApi;
		private readonly ComposableApi<ChallengeConfigInfoDto> _challengeConfigInfoDtoApi;
		private readonly ComposableApi<IEnumerable<ApexPlayerInfoDto>> _apexPlayerInfoDtosApi;
		private readonly ComposableApi<ImmutableDictionary<string, double>> _challengeThresholdsApi;
		private readonly ComposableApi<PlayerInfoDto> _playerInfoDtoApi;

		public LolChallengesApi(RiotHttpClient riotGamesClient)
		{
			_challengeConfigInfoDtosApi = new(riotGamesClient);
			_challengePercentilesApi = new(riotGamesClient);
			_challengeConfigInfoDtoApi = new(riotGamesClient);
			_apexPlayerInfoDtosApi = new(riotGamesClient);
			_challengeThresholdsApi = new(riotGamesClient);
			_playerInfoDtoApi = new(riotGamesClient);
		}

		public async Task<IEnumerable<ChallengeConfigInfoDto>> ListConfigInfosAsync()
			=> await _challengeConfigInfoDtosApi.GetValueAsync(_challengesConfigUri);

		public async Task<ImmutableDictionary<string, ImmutableDictionary<string, double>>> GetPercentilesAsync()
			=> await _challengePercentilesApi.GetValueAsync(_challengesPercentilesUri);

		public async Task<ChallengeConfigInfoDto> GetConfigInfoByIdAsync(long id)
			=> await _challengeConfigInfoDtoApi.GetValueAsync(string.Format(_challengesConfigForChallengeIdUri, id));

		public async Task<IEnumerable<ApexPlayerInfoDto>> ListApexPlayerInfosAsync(string level, long id, int limit = 0)
			=> await _apexPlayerInfoDtosApi.GetValueAsync(string.Format(_challengesTopPlayersByChallengeIdAndLevelUri, id, level) + (limit == 0 ? string.Empty : $"?limit={limit}"));

		public async Task<ImmutableDictionary<string, double>> GetPercentilesByIdAsync(long id)
			=> await _challengeThresholdsApi.GetValueAsync(string.Format(_challengesPercentilesForChallengeIdUri, id));

		public async Task<PlayerInfoDto> GetPlayerInfoByPuuidAsync(string puuid)
			=> await _playerInfoDtoApi.GetValueAsync(string.Format(_challengesProgressedUri, puuid));
	}
}
