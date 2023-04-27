using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Dto.Riot.LorMatch;
using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Type;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Api.Riot
{
    public interface ILorMatchApi
    {
        /// <summary>
        /// Get the list of match IDs by PUUID.
        /// </summary>
        /// <param name="lorRegion"></param>
        /// <param name="puuid"></param>
        /// <returns></returns>
        Task<ImmutableList<string>> ListIdsByPuuidAsync(LorRegion lorRegion, string puuid);
        /// <summary>
        /// Get match by ID.
        /// </summary>
        /// <param name="lorRegion"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MatchDto> GetByIdAsync(LorRegion lorRegion, string id);

    }

    internal class LorMatchApi : ILorMatchApi
    {
        private static readonly string s_uri = "/lor/match/v1/matches";
        private static readonly string s_matchByIdUri = s_uri + "/{0}";
        private static readonly string s_listIdsByPuuidUri = s_uri + "/by-puuid/{0}/ids";
        private readonly ComposableApi<List<string>> _stringsApi;
        private readonly ComposableApi<MatchDto> _matchDtoApi;

        public LorMatchApi(RiotHttpClient riotHttpClient)
        {
            _stringsApi = new(riotHttpClient);
            _matchDtoApi = new(riotHttpClient);
        }

        public async Task<MatchDto> GetByIdAsync(LorRegion lorRegion, string id)
            => await _matchDtoApi.GetValueAsync(LorRegionMapper.GetId(lorRegion), string.Format(s_matchByIdUri, id));

        public async Task<ImmutableList<string>> ListIdsByPuuidAsync(LorRegion lorRegion, string puuid)
        {
            List<string> ids = await _stringsApi.GetValueAsync(LorRegionMapper.GetId(lorRegion), string.Format(s_listIdsByPuuidUri, puuid));
            return ids.ToImmutableList();
        }
    }
}
