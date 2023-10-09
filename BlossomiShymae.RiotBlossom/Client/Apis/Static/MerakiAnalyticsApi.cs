using System.Collections.Immutable;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Champion;
using BlossomiShymae.RiotBlossom.Data.Dtos.Static.MerakiAnalytics.Item;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Static
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
        Task<Dictionary<string, Champion>> GetChampionsAsync();
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
        Task<Dictionary<int, Item>> GetItemsAsync();
    }

    internal class MerakiAnalyticsApi : DataApi, IMerakiAnalyticsApi
    {
        public MerakiAnalyticsApi(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Champion> GetChampionByKeyAsync(string key)
        {
            var data = await CallStaticAsync<Champion>(new()
            {
                Endpoint = nameof(MerakiAnalyticsApi),
                Url = UrlMethod.MerakiAnalytics,
                Method = UrlMethod.MerakiAnalyticsChampionByKey,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.ChampionKey, key }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<Dictionary<string, Champion>> GetChampionsAsync()
        {
            var data = await CallStaticAsync<Dictionary<string, Champion>>(new()
            {
                Endpoint = nameof(MerakiAnalyticsApi),
                Url = UrlMethod.MerakiAnalytics,
                Method = UrlMethod.MerakiAnalyticsChampions
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            var data = await CallStaticAsync<Item>(new()
            {
                Endpoint = nameof(MerakiAnalyticsApi),
                Url = UrlMethod.MerakiAnalytics,
                Method = UrlMethod.MerakiAnalyticsItemById,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.ItemId, id.ToString() }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<Dictionary<int, Item>> GetItemsAsync()
        {
            var data = await CallStaticAsync<Dictionary<int, Item>>(new()
            {
                Endpoint = nameof(MerakiAnalyticsApi),
                Url = UrlMethod.MerakiAnalytics,
                Method = UrlMethod.MerakiAnalyticsItems
            }).ConfigureAwait(false);

            return data;
        }
    }
}
