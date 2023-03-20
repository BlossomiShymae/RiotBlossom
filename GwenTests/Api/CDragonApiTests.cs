using Gwen.Core.Wrapper;
using Gwen.Dto.CDragon.Champion;
using Gwen.Dto.CDragon.Item;
using Gwen.Dto.CDragon.Perk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Immutable;

namespace GwenTests.Api
{
	[TestClass()]
	public class CDragonApiTests
	{
		public static int ChampionId = 887;
		public static int ItemId = 4633;
		public static int PerkRuneId = 8010;
		public static int ProfileIconId = 5367;

		[TestMethod()]
		public async Task Api_WithChampionId_ShouldReturnChampion()
		{
			IGwenClient gwen = StubConfig.Gwen;

			Champion champion = await gwen.CDragon.GetChampionByIdAsync(ChampionId);

			Assert.IsInstanceOfType(champion, typeof(Champion));
		}

		[TestMethod()]
		public async Task Api_WithItemId_ShouldReturnItem()
		{
			IGwenClient gwen = StubConfig.Gwen;

			Item? item = await gwen.CDragon.GetItemByIdAsync(ItemId);

			Assert.IsInstanceOfType(item, typeof(Item));
		}

		[TestMethod()]
		public async Task Api_ByDefault_ShouldReturnItemDictionary()
		{
			IGwenClient gwen = StubConfig.Gwen;

			ImmutableDictionary<int, Item> itemDictionary = await gwen.CDragon.GetItemDictionaryAsync();

			Assert.IsInstanceOfType(itemDictionary, typeof(ImmutableDictionary<int, Item>));
		}

		[TestMethod()]
		public async Task Api_WithPerkRuneId_ShouldReturnPerkRune()
		{
			IGwenClient gwen = StubConfig.Gwen;

			PerkRune perkRune = await gwen.CDragon.GetPerkRuneByIdAsync(PerkRuneId);

			Assert.IsInstanceOfType(perkRune, typeof(PerkRune));
		}

		[TestMethod()]
		public async Task Api_ByDefault_ShouldReturnPerkRuneDictionary()
		{
			IGwenClient gwen = StubConfig.Gwen;

			ImmutableDictionary<int, PerkRune> perkRuneDictionary = await gwen.CDragon.GetPerkRuneDictionaryAsync();

			Assert.IsInstanceOfType(perkRuneDictionary, typeof(ImmutableDictionary<int, PerkRune>));
		}

		[TestMethod()]
		public async Task Api_WithProfileIconId_ShouldReturnProfileIconByteArray()
		{
			IGwenClient gwen = StubConfig.Gwen;

			byte[] profileIcon = await gwen.CDragon.GetProfileIconByteArrayByIdAsync(ProfileIconId);

			Assert.IsTrue(profileIcon.Length > 0);
		}
	}
}
