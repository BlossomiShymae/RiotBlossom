using BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Champion;
using BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Item;
using BlossomiShymae.RiotBlossom.Dto.CommunityDragon.Perk;
using BlossomiShymae.RiotBlossom.Http;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Api
{
    public interface ICommunityDragonApi
    {
        /// <summary>
        /// Get a League champion by ID from the latest game data.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Champion> GetChampionByIdAsync(int id);
        /// <summary>
        /// Get a League shop item by ID from the latest game data.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Item?> GetItemByIdAsync(int id);
        /// <summary>
        /// Get a dictionary of League shop item by ID pairs from the latest game data.
        /// </summary>
        /// <returns></returns>
        Task<ImmutableDictionary<int, Item>> GetItemDictionaryAsync();
        /// <summary>
        /// Get a League perk by ID from the latest game data;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PerkRune> GetPerkRuneByIdAsync(int id);
        /// <summary>
        /// Get a dictionary of League perks by ID pairs from the latest game data.
        /// </summary>
        /// <returns></returns>
        Task<ImmutableDictionary<int, PerkRune>> GetPerkRuneDictionaryAsync();
        /// <summary>
        /// Get the byte array of a League profile icon by ID from the latest game data.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<byte[]> GetProfileIconByteArrayByIdAsync(int id);
    }

    internal class CommunityDragonApi : ICommunityDragonApi
    {
        private static readonly string s_itemsJsonUri = "/latest/plugins/rcp-be-lol-game-data/global/default/v1/items.json";
        private static readonly string s_championByIdJsonUri = "/latest/plugins/rcp-be-lol-game-data/global/default/v1/champions/{0}.json";
        private static readonly string s_perksJsonUri = "/latest/plugins/rcp-be-lol-game-data/global/default/v1/perks.json";
        private static readonly string s_profileIconUri = "/latest/plugins/rcp-be-lol-game-data/global/default/v1/profile-icons/{0}.jpg";
        private readonly ComposableApi<List<Item>> _itemsApi;
        private readonly ComposableApi<Champion> _championApi;
        private readonly ComposableApi<List<PerkRune>> _perkRunesApi;
        private readonly ComposableApi<byte[]> _byteArrayApi;

        public CommunityDragonApi(CommunityDragonHttpClient cDragonHttpClient)
        {
            _itemsApi = new(cDragonHttpClient);
            _championApi = new(cDragonHttpClient);
            _perkRunesApi = new(cDragonHttpClient);
            _byteArrayApi = new(cDragonHttpClient);
        }

        public async Task<Item?> GetItemByIdAsync(int id)
            => (await GetItemDictionaryAsync())[id];

        public async Task<Champion> GetChampionByIdAsync(int id)
            => await _championApi.GetValueAsync(string.Format(s_championByIdJsonUri, id));

        public async Task<ImmutableDictionary<int, Item>> GetItemDictionaryAsync()
        {
            List<Item> items = await _itemsApi.GetValueAsync(s_itemsJsonUri);
            return items
                .ToImmutableDictionary(k => k.Id, v => v);
        }

        public async Task<PerkRune> GetPerkRuneByIdAsync(int id)
            => (await GetPerkRuneDictionaryAsync())[id];

        public async Task<ImmutableDictionary<int, PerkRune>> GetPerkRuneDictionaryAsync()
        {
            List<PerkRune> perkRunes = await _perkRunesApi.GetValueAsync(s_perksJsonUri);
            return perkRunes
                .ToImmutableDictionary(k => k.Id, v => v);
        }

        public async Task<byte[]> GetProfileIconByteArrayByIdAsync(int id)
            => await _byteArrayApi.GetByteArrayAsync(string.Format(s_profileIconUri, id));
    }
}
