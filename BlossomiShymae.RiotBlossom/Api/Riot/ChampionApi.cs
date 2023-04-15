using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Champion;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface IChampionApi
    {
        /// <summary>
        /// Get the current champion rotation pools.
        /// </summary>
        /// <returns></returns>
        Task<ChampionInfo> ListAsync(Platform platformRoute);
    }

    internal class ChampionApi : IChampionApi
    {
        private static readonly string s_championRotationsUri = "/lol/platform/v3/champion-rotations";
        private readonly ComposableApi<ChampionInfo> _championInfoApi;

        public ChampionApi(RiotHttpClient riotGamesClient)
        {
            _championInfoApi = new(riotGamesClient);
        }

        public async Task<ChampionInfo> ListAsync(Platform platformRoute)
            => await _championInfoApi.GetValueAsync(PlatformMapper.GetId(platformRoute), s_championRotationsUri);
    }
}
