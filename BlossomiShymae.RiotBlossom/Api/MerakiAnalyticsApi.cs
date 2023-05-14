using BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Champion;
using BlossomiShymae.RiotBlossom.Dto.MerakiAnalytics.Item;
using BlossomiShymae.RiotBlossom.Http;
using System.Collections.Immutable;

namespace BlossomiShymae.RiotBlossom.Api
{
    public interface IMerakiAnalyticsApi
    {
        /// <summary>
        /// Get a League champion by their string key e.g. "MonkeyKing", "Kogmaw", "AurelionSol".
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<Champion> GetChampionByKeyAsync(string key);
        /// <summary>
        /// Get a dictionary of League champions by string key pairs e.g. "MonkeyKing", "Kogmaw", "AurelionSol".
        /// </summary>
        /// <returns></returns>
        Task<ImmutableDictionary<string, Champion>> GetChampionDictionaryAsync();
        /// <summary>
        /// Get a League shop item by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Item> GetItemByIdAsync(int id);
        /// <summary>
        /// Get a dictionary of League shop items by ID pairs.
        /// </summary>
        /// <returns></returns>
        Task<ImmutableDictionary<int, Item>> GetItemDictionaryAsync();
    }

    internal class MerakiAnalyticsApi : IMerakiAnalyticsApi
    {
        private static readonly string s_itemByIdUri = "/items/{0}.json";
        private static readonly string s_championByKeyUri = "/champions/{0}.json";
        private static readonly string s_itemsDictionaryUri = "/items.json";
        private static readonly string s_championsDictionaryUri = "/champions.json";
        private readonly ComposableApi<Dictionary<int, Item>> _itemDictionaryApi;
        private readonly ComposableApi<Dictionary<string, Champion>> _championDictionaryApi;
        private readonly ComposableApi<Item> _itemApi;
        private readonly ComposableApi<Champion> _championApi;

        public MerakiAnalyticsApi(MerakiAnalyticsHttpClient merakiAnalyticsHttpClient)
        {
            _itemDictionaryApi = new(merakiAnalyticsHttpClient);
            _championDictionaryApi = new(merakiAnalyticsHttpClient);
            _itemApi = new(merakiAnalyticsHttpClient);
            _championApi = new(merakiAnalyticsHttpClient);
        }

        public async Task<Champion> GetChampionByKeyAsync(string key)
            => await _championApi.GetValueAsync(string.Format(s_championByKeyUri, key));

        public async Task<ImmutableDictionary<string, Champion>> GetChampionDictionaryAsync()
        {
            Dictionary<string, Champion> champions = await _championDictionaryApi.GetValueAsync(s_championsDictionaryUri);
            return champions.ToImmutableDictionary();
        }

        public async Task<Item> GetItemByIdAsync(int id)
            => await _itemApi.GetValueAsync(string.Format(s_itemByIdUri, id));

        public async Task<ImmutableDictionary<int, Item>> GetItemDictionaryAsync()
        {
            Dictionary<int, Item> items = await _itemDictionaryApi.GetValueAsync(s_itemsDictionaryUri);
            return items.ToImmutableDictionary();
        }
    }
}
