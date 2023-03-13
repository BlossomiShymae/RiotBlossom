using Gwen.Api;
using Gwen.Http;
using System.Collections.Immutable;

namespace Gwen.Core
{
	public static class GwenCore
	{
		public static Client UseClient(Settings settings)
		{
			return new Client
			{
				Riot = CreateRiotComponentClient(settings)
			};
		}

		public static WidespreadClient UseWidespreadClient(Settings settings)
		{
			return new WidespreadClient
			{
				Riot = Enum
						.GetValues<Type.PlatformRoute>()
						.Select(platformRoute => CreateRiotComponentClient(new Settings
						{
							HttpClient = settings.HttpClient,
							RiotApiKey = settings.RiotApiKey,
							MiddlewarePipeline = settings.MiddlewarePipeline,
							PlatformRoute = platformRoute
						}))
						.ToImmutableDictionary(x => x.PlatformRoute, x => x),
			};
		}

		private static RiotComponentClient CreateRiotComponentClient(Settings settings) =>
			new()
			{
				Summoner = SummonerApi.Use(settings.HttpClient, settings.RiotApiKey, settings.MiddlewarePipeline)(PlatformRouteMapper.GetId(settings.PlatformRoute)),
				PlatformRoute = settings.PlatformRoute
			};

		public record Settings
		{
			public HttpClient HttpClient { get; init; } = new();
			public string RiotApiKey { get; init; } = string.Empty;
			public Type.PlatformRoute PlatformRoute { get; init; } = Type.PlatformRoute.NorthAmerica;
			public RiotGamesClient.MiddlewarePipeline MiddlewarePipeline { get; init; } = new();
		}

		public record Client
		{
			public RiotComponentClient Riot { get; init; } = new RiotComponentClient();
		}

		public record WidespreadClient
		{
			public ImmutableDictionary<Type.PlatformRoute, RiotComponentClient> Riot { get; init; } = ImmutableDictionary<Type.PlatformRoute, RiotComponentClient>.Empty;
		}

		public record RiotComponentClient
		{
			public SummonerApiContainer Summoner { get; init; } = new SummonerApiContainer();
			public Type.PlatformRoute PlatformRoute { get; init; } = Type.PlatformRoute.NorthAmerica;
		}
	}
}
