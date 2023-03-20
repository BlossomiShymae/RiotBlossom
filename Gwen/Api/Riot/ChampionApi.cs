using Gwen.Core;
using Gwen.Dto.Riot.Champion;
using Gwen.Http;
using Gwen.Type;

namespace Gwen.Api.Riot
{
	public interface IChampionApi
	{
		/// <summary>
		/// Get the current champion rotation pools.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<ChampionInfo>> ListAsync(PlatformRoute platformRoute);
	}

	internal class ChampionApi : IChampionApi
	{
		private static readonly string _championRotationsUri = "/lol/platform/v3/champion-rotations";
		private readonly ComposableApi<IEnumerable<ChampionInfo>> _championInfosApi;

		public ChampionApi(RiotHttpClient riotGamesClient)
		{
			_championInfosApi = new(riotGamesClient);
		}

		public async Task<IEnumerable<ChampionInfo>> ListAsync(PlatformRoute platformRoute)
			=> await _championInfosApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), _championRotationsUri);
	}
}
