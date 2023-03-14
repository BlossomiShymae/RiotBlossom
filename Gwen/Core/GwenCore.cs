using Gwen.Api;
using Gwen.Http;
using System.Collections.Immutable;

namespace Gwen.Core
{
	public static class GwenCore
	{
		/// <summary>
		/// Use a client that is locked to a single platform route.
		/// </summary>
		/// <param name="settings"></param>
		/// <returns></returns>
		public static Client UseClient(Settings settings)
		{
			return new Client
			{
				Riot = CreateRiotComponentClient(settings)
			};
		}

		/// <summary>
		/// Use a client that is populated for all platform routes.
		/// </summary>
		/// <param name="settings"></param>
		/// <returns></returns>
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
							Middlewares = settings.Middlewares,
							PlatformRoute = platformRoute
						}))
						.ToImmutableDictionary(x => x.PlatformRoute, x => x),
			};
		}

		private static RiotComponentClient CreateRiotComponentClient(Settings settings) =>
			new()
			{
				Account = AccountApi.Use(settings.HttpClient, settings.RiotApiKey, settings.Middlewares)(PlatformRouteMapper.GetId(settings.PlatformRoute)),
				Summoner = SummonerApi.Use(settings.HttpClient, settings.RiotApiKey, settings.Middlewares)(PlatformRouteMapper.GetId(settings.PlatformRoute)),
				PlatformRoute = settings.PlatformRoute
			};

		/// <summary>
		/// The settings used to pass into <see cref="GwenCore.UseClient(Settings)"/> or <see cref="GwenCore.UseWidespreadClient(Settings)"/>."/>
		/// </summary>
		public record Settings
		{
			/// <summary>
			/// The client used to make Http requests with. Defaults to creating a new instance.
			/// </summary>
			public HttpClient HttpClient { get; init; } = new();
			/// <summary>
			/// The Riot API key used to gain access with. Defaults to empty string which will throw an exception.
			/// </summary>
			public string RiotApiKey { get; init; } = string.Empty;
			/// <summary>
			/// The platform routing value used to access platform-specific data. Defaults to <see cref="Type.PlatformRoute.NorthAmerica"/>.
			/// </summary>
			public Type.PlatformRoute PlatformRoute { get; init; } = Type.PlatformRoute.NorthAmerica;
			/// <summary>
			/// Application-level middlewares used for the request-response cycle. Defaults to defined values set in <see cref="XMiddlewares"/>.
			/// </summary>
			public XMiddlewares Middlewares { get; init; } = new();
		}

		/// <summary>
		/// The core client API that Gwen provides for single platform use.
		/// </summary>
		public record Client
		{
			/// <summary>
			/// The component client used to access Riot Games APIs. Locked to given <see cref="Type.PlatformRoute"/>.
			/// </summary>
			public RiotComponentClient Riot { get; init; } = new RiotComponentClient();
		}

		/// <summary>
		/// The core client API that Gwen provides for widespread platform use.
		/// </summary>
		public record WidespreadClient
		{
			/// <summary>
			/// The immutable dictionary of component clients used to access Riot Games APIs. Accepts a key index of <see cref="Type.PlatformRoute"/>
			/// to get associated component client.
			/// </summary>
			public ImmutableDictionary<Type.PlatformRoute, RiotComponentClient> Riot { get; init; } = ImmutableDictionary<Type.PlatformRoute, RiotComponentClient>.Empty;
		}

		public record RiotComponentClient
		{
			/// <summary>
			/// The API container for Account-v1 endpoint functions.
			/// </summary>
			public AccountApi.Container Account { get; init; } = new AccountApi.Container();
			/// <summary>
			/// The API container for Summoner-v4 endpoint functions.
			/// </summary>
			public SummonerApi.Container Summoner { get; init; } = new SummonerApi.Container();
			/// <summary>
			/// The platform routing value used for accessing platform-specific data.
			/// </summary>
			public Type.PlatformRoute PlatformRoute { get; init; } = Type.PlatformRoute.NorthAmerica;
		}
	}
}
