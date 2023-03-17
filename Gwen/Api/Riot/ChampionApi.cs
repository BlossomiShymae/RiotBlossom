using Gwen.Dto.Champion;
using Gwen.Http;

namespace Gwen.Api.Riot
{
	public interface IChampionApi
	{
		/// <summary>
		/// Get the current champion rotation pools.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<ChampionInfo>> ListAsync();
	}

	internal class ChampionApi : IChampionApi
	{
		private static readonly string _championRotationsUri = "/lol/platform/v3/champion-rotations";
		private readonly ComposableApi<IEnumerable<ChampionInfo>> _championInfosApi;

		public ChampionApi(RiotHttpClient riotGamesClient)
		{
			_championInfosApi = new(riotGamesClient);
		}

		public async Task<IEnumerable<ChampionInfo>> ListAsync()
			=> await _championInfosApi.GetValueAsync(_championRotationsUri);
	}
}
