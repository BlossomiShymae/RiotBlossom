using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Constants.Shards;
using BlossomiShymae.RiotBlossom.Data.Dtos.Lol.Clash;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Lol
{
    public interface IClashV1Api
    {
        /// <summary>
        /// Get a clash team by ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="teamId"></param>
        /// <returns></returns>
        Task<TeamDto> GetTeamByIdAsync(LeagueShard shard, string teamId);
        /// <summary>
        /// Get a clash tournament by ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="tournamentId"></param>
        /// <returns></returns>
        Task<TournamentDto> GetTournamentByIdAsync(LeagueShard shard, string tournamentId);
        /// <summary>
        /// Get a clash tournament by team ID.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="teamId"></param>
        /// <returns></returns>
        Task<TournamentDto> GetTournamentByTeamIdAsync(LeagueShard shard, string teamId);
        /// <summary>
        /// List all active or upcoming clash tournaments.
        /// </summary>
        /// <param name="shard"></param>
        /// <returns></returns>
        Task<List<TournamentDto>> GetActiveTournamentsAsync(LeagueShard shard);
        /// <summary>
        /// List active Clash players for encrypted summoner ID. If a summoner registers for multiple tournaments
        /// at once, then both registrations will appear.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="summonerId"></param>
        /// <returns></returns>
        Task<List<PlayerDto>> GetPlayersBySummonerIdAsync(LeagueShard shard, string summonerId);
        /// <summary>
        /// List active Clash players for PUUID. If a summoner registers for muiltiple tournaments
        /// at once, then both registrations will appear.
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<List<PlayerDto>> GetPlayersByPuuidAsync(LeagueShard shard, string puuid);
    }

    internal class ClashV1Api : DataApi, IClashV1Api
    {
        public ClashV1Api(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<TournamentDto>> GetActiveTournamentsAsync(LeagueShard shard)
        {
            var data = await CallAsync<List<TournamentDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(ClashV1Api),
                Method = UrlMethod.LolClashV1Tournaments,
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<PlayerDto>> GetPlayersByPuuidAsync(LeagueShard shard, string puuid)
        {
            var data = await CallAsync<List<PlayerDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(ClashV1Api),
                Method = UrlMethod.LolClashV1PlayersByPuuid,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Puuid, puuid }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<List<PlayerDto>> GetPlayersBySummonerIdAsync(LeagueShard shard, string summonerId)
        {
            var data = await CallAsync<List<PlayerDto>>(new()
            {
                Shard = shard,
                Endpoint = nameof(ClashV1Api),
                Method = UrlMethod.LolClashV1PlayersBySummonerId,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.SummonerId, summonerId }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<TeamDto> GetTeamByIdAsync(LeagueShard shard, string teamId)
        {
            var data = await CallAsync<TeamDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(ClashV1Api),
                Method = UrlMethod.LolClashV1TeamsById,
                Params = new Dictionary<string, string>
                {
                    { UrlMethod.TeamId, teamId }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<TournamentDto> GetTournamentByIdAsync(LeagueShard shard, string tournamentId)
        {
            var data = await CallAsync<TournamentDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(ClashV1Api),
                Method = UrlMethod.LolClashV1TournamentsById,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.TournamentId, tournamentId }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<TournamentDto> GetTournamentByTeamIdAsync(LeagueShard shard, string teamId)
        {
            var data = await CallAsync<TournamentDto>(new()
            {
                Shard = shard,
                Endpoint = nameof(ClashV1Api),
                Method = UrlMethod.LolClashV1TournamentsByTeamId,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.TeamId, teamId }
                }
            }).ConfigureAwait(false);

            return data;
        }
    }
}
