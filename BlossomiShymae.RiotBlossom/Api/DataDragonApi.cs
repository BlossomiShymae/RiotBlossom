﻿using BlossomiShymae.RiotBlossom.Dto.DataDragon.Champion;
using BlossomiShymae.RiotBlossom.Dto.DataDragon.Item;
using BlossomiShymae.RiotBlossom.Dto.DataDragon.Perk;
using BlossomiShymae.RiotBlossom.Http;
using System.Collections.Immutable;
using System.Text.Json.Nodes;

namespace BlossomiShymae.RiotBlossom.Api
{
    public interface IDataDragonApi
    {
        /// <summary>
        /// Get a League champion by ID from version.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Champion> GetChampionByIdAsync(string version, int id);
        /// <summary>
        /// Get a dictionary of League champion by ID pairs from version.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        Task<ImmutableDictionary<int, Champion>> GetChampionDictionaryAsync(string version);
        /// <summary>
        /// Get a League shop item by ID from version.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Item> GetItemByIdAsync(string version, int id);
        /// <summary>
        /// Get a dictionary of League shop item by ID pairs from version.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        Task<ImmutableDictionary<int, Item>> GetItemDictionaryAsync(string version);
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
        Task<PerkStyle> GetPerkStyleByIdAsync(string version, int id);
        /// <summary>
        /// Get a dictionary of League perk style by ID from version.
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        Task<ImmutableDictionary<int, PerkStyle>> GetPerkStyleDictionaryAsync(string version);
        /// <summary>
        /// Get the byte array of a League profile icon by ID from version.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<byte[]> GetProfileIconByteArrayByIdAsync(string version, int id);
        /// <summary>
        /// List all League game versions.
        /// </summary>
        /// <returns></returns>
        Task<ImmutableList<string>> ListVersionsAsync();
    }

    internal class DataDragonApi : IDataDragonApi
    {
        private static readonly string s_championFullJsonUri = "/cdn/{0}/data/en_US/championFull.json";
        private static readonly string s_itemJsonUri = "/cdn/{0}/data/en_US/item.json";
        private static readonly string s_versionsJsonUri = "/api/versions.json";
        private static readonly string s_runesReforgedJsonUri = "/cdn/{0}/data/en_US/runesReforged.json";
        private static readonly string s_profileIconUri = "/cdn/{0}/img/profileicon/{1}.png";
        private readonly ComposableApi<JsonNode> _jsonNodeApi;
        private readonly ComposableApi<List<string>> _versionsApi;
        private readonly ComposableApi<List<PerkStyle>> _perkStylesApi;
        private readonly ComposableApi<byte[]> _byteArrayApi;

        public DataDragonApi(DataDragonHttpClient dDragonHttpClient)
        {
            _jsonNodeApi = new(dDragonHttpClient);
            _versionsApi = new(dDragonHttpClient);
            _perkStylesApi = new(dDragonHttpClient);
            _byteArrayApi = new(dDragonHttpClient);
        }

        public async Task<string> GetLatestVersionAsync()
            => (await ListVersionsAsync()).First();

        public async Task<ImmutableList<string>> ListVersionsAsync()
        {
            List<string> versions = await _versionsApi.GetValueAsync(s_versionsJsonUri);
            return versions.ToImmutableList();
        }

        public async Task<Champion> GetChampionByIdAsync(string version, int id)
            => (await GetChampionDictionaryAsync(version))[id];

        public async Task<ImmutableDictionary<int, Champion>> GetChampionDictionaryAsync(string version)
        {
            JsonNode node = await _jsonNodeApi.GetValueAsync(string.Format(s_championFullJsonUri, version));
            Dictionary<string, Champion> champions = _jsonNodeApi.Deserialize<Dictionary<string, Champion>>(node["data"]?.AsObject() ?? new JsonObject());
            return champions
                .ToImmutableDictionary(k => int.Parse(k.Value.Key), v => v.Value);
        }

        public async Task<Item> GetItemByIdAsync(string version, int id)
            => (await GetItemDictionaryAsync(version))[id];

        public async Task<ImmutableDictionary<int, Item>> GetItemDictionaryAsync(string version)
        {
            JsonNode node = await _jsonNodeApi.GetValueAsync(string.Format(s_itemJsonUri, version));
            Dictionary<int, Item> items = _jsonNodeApi.Deserialize<Dictionary<int, Item>>(node["data"]?.AsObject() ?? new JsonObject());
            return items.ToImmutableDictionary();
        }

        public async Task<PerkStyle> GetPerkStyleByIdAsync(string version, int id)
            => (await GetPerkStyleDictionaryAsync(version))[id];

        public async Task<ImmutableDictionary<int, PerkStyle>> GetPerkStyleDictionaryAsync(string version)
        {
            List<PerkStyle> perkStyles = await _perkStylesApi.GetValueAsync(string.Format(s_runesReforgedJsonUri, version));
            return perkStyles
                .ToImmutableDictionary(k => k.Id, v => v);
        }

        public async Task<byte[]> GetProfileIconByteArrayByIdAsync(string version, int id)
            => await _byteArrayApi.GetByteArrayAsync(string.Format(s_profileIconUri, version, id));
    }
}
