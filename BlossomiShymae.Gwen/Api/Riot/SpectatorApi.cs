using BlossomiShymae.Gwen.Core;
using BlossomiShymae.Gwen.Dto.Riot.Spectator;
using BlossomiShymae.Gwen.Http;
using BlossomiShymae.Gwen.Type;

namespace BlossomiShymae.Gwen.Api.Riot
{
    public interface ISpectatorApi
    {
        /// <summary>
        /// Get the current game information by encrypted summoner ID.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<CurrentGameInfo> GetCurrentGameInfoBySummonerIdAsync(PlatformRoute platformRoute, string summonerId);
        /// <summary>
        /// Get the list of featured games.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <returns></returns>
        Task<FeaturedGames> GetFeaturedGamesAsync(PlatformRoute platformRoute);
    }

    internal class SpectatorApi : ISpectatorApi
    {
        private static readonly string _uri = "/lol/spectator/v4";
        private static readonly string _currentGameInfoBySummonerIdUri = _uri + "/active-games/by-summoner/{0}";
        private static readonly string _featuredGamesUri = _uri + "/featured-games";
        private readonly ComposableApi<CurrentGameInfo> _currentGameInfoApi;
        private readonly ComposableApi<FeaturedGames> _featuredGamesApi;

        public SpectatorApi(RiotHttpClient riotGamesClient)
        {
            _currentGameInfoApi = new(riotGamesClient);
            _featuredGamesApi = new(riotGamesClient);
        }

        public async Task<CurrentGameInfo> GetCurrentGameInfoBySummonerIdAsync(PlatformRoute platformRoute, string summonerId)
            => await _currentGameInfoApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), string.Format(_currentGameInfoBySummonerIdUri, summonerId));

        public async Task<FeaturedGames> GetFeaturedGamesAsync(PlatformRoute platformRoute)
            => await _featuredGamesApi.GetValueAsync(PlatformRouteMapper.GetId(platformRoute), _featuredGamesUri);
    }
}
