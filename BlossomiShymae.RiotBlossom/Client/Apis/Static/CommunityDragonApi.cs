using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Core.Utils;
using BlossomiShymae.RiotBlossom.Data;
using BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Champion;
using BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Item;
using BlossomiShymae.RiotBlossom.Data.Dtos.Static.CommunityDragon.Perk;

namespace BlossomiShymae.RiotBlossom.Client.Apis.Static
{
    public interface ICommunityDragonApi
    {
        /// <summary>
        /// Get a League champion by ID from the latest game data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="locale"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        Task<Champion> GetChampionByIdAsync(int id, string version = "latest", string locale = "default");
        /// <summary>
        /// Get a League shop item by ID from the latest game data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        Task<Item> GetItemByIdAsync(int id, string version = "latest", string locale = "default");
        /// <summary>
        /// Get a dictionary of League shop item by ID pairs from the latest game data.
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<int, Item>> GetItemsAsync(string version = "latest", string locale = "default");
        /// <summary>
        /// Get a League perk by ID from the latest game data;
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        Task<PerkRune> GetPerkRuneByIdAsync(int id, string version = "latest", string locale = "default");
        /// <summary>
        /// Get a dictionary of League perks by ID pairs from the latest game data.
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<int, PerkRune>> GetPerkRunesAsync(string version = "latest", string locale = "default");
        /// <summary>
        /// Get a profile icon URL by profile icon ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        string GetProfileIconById(int id, string version = "latest", string locale = "default");
    }

    internal class CommunityDragonApi : DataApi, ICommunityDragonApi
    {
        public CommunityDragonApi(ApiConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Champion> GetChampionByIdAsync(int id, string version = "latest", string locale = "default")
        {
            var data = await CallStaticAsync<Champion>(new()
            {
                Endpoint = nameof(CommunityDragonApi),
                Url = UrlMethod.CommunityDragon,
                Method = UrlMethod.CommunityDragonChampionById,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.ChampionId, id.ToString() },
                    { UrlMethod.Version, version },
                    { UrlMethod.Locale, locale }
                }
            }).ConfigureAwait(false);

            return data;
        }

        public async Task<Item> GetItemByIdAsync(int id, string version = "latest", string locale = "default")
        {
            var dict = await GetItemsAsync()
                .ConfigureAwait(false);

            return dict[id];
        }

        public async Task<Dictionary<int, Item>> GetItemsAsync(string version = "latest", string locale = "default")
        {
            var data = await CallStaticAsync<List<Item>>(new()
            {
                Endpoint = nameof(CommunityDragonApi),
                Url = UrlMethod.CommunityDragon,
                Method = UrlMethod.CommunityDragonItems,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Version, version },
                    { UrlMethod.Locale, locale }
                }
            }).ConfigureAwait(false);

            return data.ToDictionary(k => k.Id, v => v);
        }

        public async Task<PerkRune> GetPerkRuneByIdAsync(int id, string version = "latest", string locale = "default")
        {
            var dict = await GetPerkRunesAsync()
                .ConfigureAwait(false);

            return dict[id];
        }

        public async Task<Dictionary<int, PerkRune>> GetPerkRunesAsync(string version = "latest", string locale = "default")
        {
            var data = await CallStaticAsync<List<PerkRune>>(new()
            {
                Endpoint = nameof(CommunityDragonApi),
                Url = UrlMethod.CommunityDragon,
                Method = UrlMethod.CommunityDragonPerks,
                Params = new Dictionary<string, string>()
                {
                    { UrlMethod.Version, version },
                    { UrlMethod.Locale, locale }
                }
            }).ConfigureAwait(false);

            return data.ToDictionary(k => k.Id, v => v);
        }

        public string GetProfileIconById(int id, string version = "latest", string locale = "default")
        {
            var uri = new NamedFormatter(UrlMethod.CommunityDragonProfileIcon);

            var data = uri.Format(new Dictionary<string, string>()
            {
                { UrlMethod.ProfileIconId, id.ToString() },
                { UrlMethod.Version, version },
                { UrlMethod.Locale, locale }
            });

            return data;
        }
    }
}
