using BlossomiShymae.Gwen.Core;
using BlossomiShymae.Gwen.Dto.Riot.Champion;
using BlossomiShymae.Gwen.Http;
using BlossomiShymae.Gwen.Type;

namespace BlossomiShymae.Gwen.Api.Riot
{
    public interface IChampionApi
    {
        /// <summary>
        /// Get the current champion rotation pools.
        /// </summary>
        /// <returns></returns>
        Task<ChampionInfo> ListAsync(PlatformRoute platformRoute);
    }

    internal class ChampionApi : IChampionApi
    {
        private static readonly string _championRotationsUri = "/lol/platform/v3/champion-rotations";
        private readonly ComposableApi<ChampionInfo> _championInfoApi;

        public ChampionApi(RiotHttpClient riotGamesClient)
        {
            _championInfoApi = new(riotGamesClient);
        }

        public async Task<ChampionInfo> ListAsync(PlatformRoute platformRoute)
            => await _championInfoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), _championRotationsUri);
    }
}
