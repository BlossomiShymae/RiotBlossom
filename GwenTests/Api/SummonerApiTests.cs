﻿using Gwen.Dto.Summoner;
using GwenTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gwen.Api.Tests
{
	[TestClass()]
	public class SummonerApiTests
	{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public static SummonerDto summoner;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		[ClassInitialize()]
		public static async Task Initialize(TestContext testContext)
		{
			var gwen = StubClient.UseWidespread();

			summoner = await gwen.Riot[Type.PlatformRoute.NorthAmerica].Summoner.GetSummonerByNameAsync("uwuie time");
		}

		[TestMethod()]
		public async Task Api_WithAccountId_ShouldReturnSummonerDto()
		{
			var gwen = StubClient.UseWidespread();

			var summonerDto = await gwen.Riot[Type.PlatformRoute.NorthAmerica].Summoner.GetSummonerByAccountIdAsync(summoner.AccountId);

			Assert.IsInstanceOfType(summonerDto, typeof(SummonerDto));
		}

		[TestMethod()]
		public async Task Api_WithSummonerName_ShouldReturnSummonerDto()
		{
			var gwen = StubClient.UseWidespread();

			var summonerDto = await gwen.Riot[Type.PlatformRoute.NorthAmerica].Summoner.GetSummonerByNameAsync("uwuie time");

			Assert.IsInstanceOfType(summonerDto, typeof(SummonerDto));
		}

		[TestMethod()]
		public async Task Api_WithSummonerPuuid_ShouldReturnSummonerDto()
		{
			var gwen = StubClient.UseWidespread();

			var summonerDto = await gwen.Riot[Type.PlatformRoute.NorthAmerica].Summoner.GetSummonerByPuuidAsync(summoner.Puuid);

			Assert.IsInstanceOfType(summonerDto, typeof(SummonerDto));
		}

		[TestMethod()]
		public async Task Api_WithSummonerId_ShouldReturnSummonerDto()
		{
			var gwen = StubClient.UseWidespread();

			var summonerDto = await gwen.Riot[Type.PlatformRoute.NorthAmerica].Summoner.GetSummonerByIdAsync(summoner.Id);

			Assert.IsInstanceOfType(summonerDto, typeof(SummonerDto));
		}
	}
}