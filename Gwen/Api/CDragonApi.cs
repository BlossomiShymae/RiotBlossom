using Gwen.Dto.CDragon.Champion;
using Gwen.Dto.CDragon.Item;
using Gwen.Http;

namespace Gwen.Api
{
	public interface ICDragonApi
	{
		/// <summary>
		/// Get a League champion from the latest game data.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Champion> GetChampionAsync(int id);
		/// <summary>
		/// Get a League shop item by ID from the latest game data.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Item?> GetItemByIdAsync(int id);
		/// <summary>
		/// List all League shop items from the latest game data.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<Item>> ListItemsAsync();
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

		public async Task<IEnumerable<Item>> ListItemsAsync()
			=> await _itemsApi.GetValueAsync(_itemsJsonUri);

		public async Task<Item?> GetItemByIdAsync(int id)
			=> (await ListItemsAsync())
				.Where(x => x.Id == id)
				.FirstOrDefault();

		public async Task<Champion> GetChampionAsync(int id)
			=> await _championApi.GetValueAsync(string.Format(_championByIdJsonUri, id));
	}
}
