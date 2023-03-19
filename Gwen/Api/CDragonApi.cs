using Gwen.Dto.CDragon.Champion;
using Gwen.Dto.CDragon.Item;
using Gwen.Http;
using System.Collections.Immutable;

namespace Gwen.Api
{
	public interface ICDragonApi
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
	}

	internal class CDragonApi : ICDragonApi
	{
		private static readonly string _itemsJsonUri = "/latest/plugins/rcp-be-lol-game-data/global/default/v1/items.json";
		private static readonly string _championByIdJsonUri = "/latest/plugins/rcp-be-lol-game-data/global/default/v1/champions/{0}.json";
		private readonly ComposableApi<IEnumerable<Item>> _itemsApi;
		private readonly ComposableApi<Champion> _championApi;

		public CDragonApi(CDragonHttpClient cDragonHttpClient)
		{
			_itemsApi = new(cDragonHttpClient);
			_championApi = new(cDragonHttpClient);
		}

		public async Task<Item?> GetItemByIdAsync(int id)
			=> (await GetItemDictionaryAsync())[id];

		public async Task<Champion> GetChampionByIdAsync(int id)
			=> await _championApi.GetValueAsync(string.Format(_championByIdJsonUri, id));

		public async Task<ImmutableDictionary<int, Item>> GetItemDictionaryAsync()
		{
			IEnumerable<Item> items = await _itemsApi.GetValueAsync(_itemsJsonUri);
			return items
				.ToImmutableDictionary(k => k.Id, v => v);
		}
	}
}
