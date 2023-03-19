using Gwen.Dto.CDragon.Item;
using Gwen.Dto.DDragon.Champion;
using Gwen.Dto.DDragon.Perk;
using Gwen.Http;
using System.Collections.Immutable;
using System.Text.Json.Nodes;

namespace Gwen.Api
{
	public interface IDDragonApi
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
		/// List all League game versions.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<string>> ListVersionsAsync();
	}

	internal class DDragonApi : IDDragonApi
	{
		private static readonly string s_championFullJsonUri = "/cdn/{0}/data/en_US/championFull.json";
		private static readonly string s_itemJsonUri = "/cdn/{0}/data/en_US/item.json";
		private static readonly string s_versionsJsonUri = "/api/versions.json";
		private static readonly string s_runesReforgedJsonUri = "/cdn/{0}/data/en_US/runesReforged.json";
		private readonly ComposableApi<JsonNode> _jsonNodeApi;
		private readonly ComposableApi<IEnumerable<string>> _versionsApi;
		private readonly ComposableApi<IEnumerable<PerkStyle>> _perkStylesApi;

		public DDragonApi(DDragonHttpClient dDragonHttpClient)
		{
			_jsonNodeApi = new(dDragonHttpClient);
			_versionsApi = new(dDragonHttpClient);
			_perkStylesApi = new(dDragonHttpClient);
		}

		public async Task<string> GetLatestVersionAsync()
			=> (await ListVersionsAsync()).First();

		public async Task<IEnumerable<string>> ListVersionsAsync()
			=> await _versionsApi.GetValueAsync(s_versionsJsonUri);

		public async Task<Champion> GetChampionByIdAsync(string version, int id)
			=> (await GetChampionDictionaryAsync(version))[id];

		public async Task<ImmutableDictionary<int, Champion>> GetChampionDictionaryAsync(string version)
		{
			JsonNode node = await _jsonNodeApi.GetValueAsync(string.Format(s_championFullJsonUri, version));
			IEnumerable<Champion> champions = node["data"]?.GetValue<IEnumerable<Champion>>() ?? ImmutableList<Champion>.Empty;
			return champions
				.ToImmutableDictionary(k => int.Parse(k.Key), v => v);
		}

		public async Task<Item> GetItemByIdAsync(string version, int id)
			=> (await GetItemDictionaryAsync(version))[id];

		public async Task<ImmutableDictionary<int, Item>> GetItemDictionaryAsync(string version)
		{
			JsonNode node = await _jsonNodeApi.GetValueAsync(string.Format(s_itemJsonUri, version));
			ImmutableDictionary<int, Item> items = node["data"]?.GetValue<ImmutableDictionary<int, Item>>() ?? ImmutableDictionary<int, Item>.Empty;
			return items;
		}

		public async Task<PerkStyle> GetPerkStyleByIdAsync(string version, int id)
			=> (await GetPerkStyleDictionaryAsync(version))[id];

		public async Task<ImmutableDictionary<int, PerkStyle>> GetPerkStyleDictionaryAsync(string version)
		{
			IEnumerable<PerkStyle> perkStyles = await _perkStylesApi.GetValueAsync(string.Format(s_runesReforgedJsonUri, version));
			return perkStyles
				.ToImmutableDictionary(k => k.Id, v => v);
		}
	}
}
