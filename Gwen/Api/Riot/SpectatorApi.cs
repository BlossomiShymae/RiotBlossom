using Gwen.Dto.Spectator;
using Gwen.Http;

namespace Gwen.Api.Riot
{
    public interface ISpectatorApi
    {
        /// <summary>
        /// Get the current game information by encrypted summoner ID.
        /// </summary>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<CurrentGameInfo> GetCurrentGameInfoBySummonerIdAsync(string summonerId);
        /// <summary>
        /// Get the list of featured games.
        /// </summary>
        /// <returns></returns>
        Task<FeaturedGames> GetFeaturedGamesAsync();
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

        public async Task<CurrentGameInfo> GetCurrentGameInfoBySummonerIdAsync(string summonerId)
            => await _currentGameInfoApi.GetValueAsync(string.Format(_currentGameInfoBySummonerIdUri, summonerId));

        public async Task<FeaturedGames> GetFeaturedGamesAsync()
            => await _featuredGamesApi.GetValueAsync(_featuredGamesUri);
    }
}
