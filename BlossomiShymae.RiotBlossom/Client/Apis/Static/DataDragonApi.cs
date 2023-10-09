using System.Collections.Immutable;
using System.Security.Policy;
using System.Text.Json.Nodes;
using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Core.Utils;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Champion;
using BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Item;
using BlossomiShymae.RiotBlossom.Data.Dtos.Static.DataDragon.Perk;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Static
{
    public interface IDataDragonApi
    {
        /// <summary>
        /// Get a League champion by champion key from version.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<Champion> GetChampionByKeyAsync(string key, string version);
        /// <summary>
        /// Get a dictionary of League champion by champion key pairs from version.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        Task<Dictionary<string, Champion>> GetChampionsAsync(string version);
        /// <summary>
        /// Get a League shop item by ID from version.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Item> GetItemByIdAsync(int id, string version);
        /// <summary>
        /// Get a dictionary of League shop item by ID pairs from version.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        Task<Dictionary<int, Item>> GetItemsAsync(string version);
        /// <summary>
        /// Get the latest League game version.
        /// </summary>
        /// <returns></returns>
        Task<string> GetLatestVersionAsync();
        /// <summary>
        /// Get a League perk style by ID from version.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PerkStyle> GetPerkStyleByIdAsync(int id, string version);
        /// <summary>
        /// Get a dictionary of League perk style by ID from version.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        Task<Dictionary<int, PerkStyle>> GetPerkStylesAsync(string version);
        /// <summary>
        /// List all League game versions.
        /// </summary>
        /// <returns></returns>
        Task<List<string>> GetVersionsAsync();
        /// <summary>
        /// Get a profile icon URL by profile icon ID.
        /// </summary>
        /// <returns></returns>
        string GetProfileIconById(string version, int id);
    }

    internal class DataDragonApi : DataApi, IDataDragonApi
    {
        public DataDragonApi(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Dictionary<string, Champion>> GetChampionsAsync(string version)
        {
            var data = await CallStaticAsync<ChampionJson>(new()
            {
                Endpoint = nameof(DataDragonApi),
                Url = UrlMethod.DataDragon,
                Method = UrlMethod.DataDragonChampionFull,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Version, version }
                }
            }).ConfigureAwait(false);

            return data.Data;
        }

        public async Task<Champion> GetChampionByKeyAsync(string key, string version)
        {
            var dict = await GetChampionsAsync(version)
                .ConfigureAwait(false);

            return dict[key];
        }

        public async Task<Item> GetItemByIdAsync(int id, string version)
        {
            var dict = await GetItemsAsync(version)
                .ConfigureAwait(false);

            return dict[id];            
        }

        public async Task<Dictionary<int, Item>> GetItemsAsync(string version)
        {
            var data = await CallStaticAsync<Dictionary<int, Item>>(new()
            {
                Endpoint = nameof(DataDragonApi),
                Url = UrlMethod.DataDragon,
                Method = UrlMethod.DataDragonItem,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Version, version }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<string> GetLatestVersionAsync()
        {
            var list = await GetVersionsAsync()
                .ConfigureAwait(false);

            return list.First();
        }

        public async Task<PerkStyle> GetPerkStyleByIdAsync(int id, string version)
        {
            var dict = await GetPerkStylesAsync(version)
                .ConfigureAwait(false);

            return dict[id];
        }

        public async Task<Dictionary<int, PerkStyle>> GetPerkStylesAsync(string version)
        {
            var data = await CallStaticAsync<Dictionary<int, PerkStyle>>(new()
            {
                Endpoint = nameof(DataDragonApi),
                Url = UrlMethod.DataDragon,
                Method = UrlMethod.DataDragonRunesReforged,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Version, version }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public string GetProfileIconById(string version, int id)
        {
            var uri = new NamedFormatter(UrlMethod.DataDragonProfileIcon);

            var data = uri.Format(new Dictionary<string, string>()
            {
                { UrlMethod.Version, version },
                { UrlMethod.ProfileIconId, id.ToString() }
            });

            return data;
        }

        public async Task<List<string>> GetVersionsAsync()
        {
            var data = await CallStaticAsync<List<string>>(new()
            {
                Endpoint = nameof(DataDragonApi),
                Url = UrlMethod.DataDragon,
                Method = UrlMethod.DataDragonVersions,
            }).ConfigureAwait(false);

            return data;
        }
    }
}
