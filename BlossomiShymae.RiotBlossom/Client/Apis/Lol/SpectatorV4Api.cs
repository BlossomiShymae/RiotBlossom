using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Spectator;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Lol
{
    public interface ISpectatorV4Api
    {
        /// <summary>
        /// Get the current game information by encrypted summoner ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<CurrentGameInfo> GetCurrentGameInfoBySummonerIdAsync(LeagueShard shard, string summonerId);
        /// <summary>
        /// Get the list of featured games.
        /// </summary>
        /// <param name="shard"></param>
        /// <returns></returns>
        Task<FeaturedGames> GetFeaturedGamesAsync(LeagueShard shard);
    }

    internal class SpectatorV4Api : DataApi, ISpectatorV4Api
    {
        public SpectatorV4Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<CurrentGameInfo> GetCurrentGameInfoBySummonerIdAsync(LeagueShard shard, string summonerId)
        {
            var data = await CallAsync<CurrentGameInfo>(new()
            {
                Shard = shard,
                Endpoint = nameof(SpectatorV4Api),
                Method = UrlMethod.LolSpectatorV4ByEncryptedSummonerId,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.EncryptedSummonerId, summonerId }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<FeaturedGames> GetFeaturedGamesAsync(LeagueShard shard)
        {
            var data = await CallAsync<FeaturedGames>(new()
            {
                Shard = shard,
                Endpoint = nameof(SpectatorV4Api),
                Method = UrlMethod.LolSpectatorV4FeaturedGames,
            }).ConfigureAwait(false);

            return data;
        }
    }
}
