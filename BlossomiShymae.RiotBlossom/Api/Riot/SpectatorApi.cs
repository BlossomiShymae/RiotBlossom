using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.Spectator;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface ISpectatorApi
    {
        /// <summary>
        /// Get the current game information by encrypted summoner ID.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<CurrentGameInfo> GetCurrentGameInfoBySummonerIdAsync(Platform platformRoute, string summonerId);
        /// <summary>
        /// Get the list of featured games.
        /// </summary>
        /// <param name="platformRoute"></param>
        /// <returns></returns>
        Task<FeaturedGames> GetFeaturedGamesAsync(Platform platformRoute);
    }

    internal class SpectatorApi : ISpectatorApi
    {
        private static readonly string s_uri = "/lol/spectator/v4";
        private static readonly string s_currentGameInfoBySummonerIdUri = s_uri + "/active-games/by-summoner/{0}";
        private static readonly string s_featuredGamesUri = s_uri + "/featured-games";
        private readonly ComposableApi<CurrentGameInfo> _currentGameInfoApi;
        private readonly ComposableApi<FeaturedGames> _featuredGamesApi;

        public SpectatorApi(RiotHttpClient riotGamesClient)
        {
            _currentGameInfoApi = new(riotGamesClient);
            _featuredGamesApi = new(riotGamesClient);
        }

        public async Task<CurrentGameInfo> GetCurrentGameInfoBySummonerIdAsync(Platform platformRoute, string summonerId)
            => await _currentGameInfoApi.GetValueAsync(PlatformMapper.GetId(platformRoute), string.Format(s_currentGameInfoBySummonerIdUri, summonerId));

        public async Task<FeaturedGames> GetFeaturedGamesAsync(Platform platformRoute)
            => await _featuredGamesApi.GetValueAsync(PlatformMapper.GetId(platformRoute), s_featuredGamesUri);
    }
}
