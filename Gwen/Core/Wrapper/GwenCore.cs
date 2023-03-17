using Gwen.Http;
using System.Collections.Immutable;

namespace Gwen.Core.Wrapper
{
	public class GwenCore
	{
		/// <summary>
		/// Create a simple wrapper client that is locked to a single platform route.
		/// </summary>
		/// <param name="settings"></param>
		/// <returns></returns>
		public static ISimpleWrapper CreateSimpleWrapper(Settings settings)
		{
			var routingValue = PlatformRouteMapper.GetId(settings.PlatformRoute);
			var riotGamesClient = new RiotHttpClient(settings.HttpClient, settings.RiotApiKey, routingValue, settings.XMiddlewares);
			return new SimpleWrapper(new RiotCore(riotGamesClient, settings.PlatformRoute));
		}

		/// <summary>
		/// Create a blanket wrapper client that is populated for all platform routes.
		/// </summary>
		/// <param name="settings"></param>
		/// <returns></returns>
		public static IBlanketWrapper CreateBlanketWrapper(Settings settings)
		{
			var routingValue = PlatformRouteMapper.GetId(settings.PlatformRoute);
			var riotGamesClient = new RiotHttpClient(settings.HttpClient, settings.RiotApiKey, routingValue, settings.XMiddlewares);
			ImmutableDictionary<Type.PlatformRoute, IRiotCore> riot = Enum
				.GetValues<Type.PlatformRoute>()
				.Select(platformRoute => (IRiotCore)new RiotCore(riotGamesClient, platformRoute))
				.ToImmutableDictionary(x => x.PlatformRoute, x => x);
			return new BlanketWrapper(riot);
		}

		/// <summary>
		/// The settings used to pass into <see cref="CreateSimpleWrapper(Settings))"/> or <see cref="CreateBlanketWrapper(Settings)"/>."/>
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
			/// Application-level middlewares used for the request-response cycle. Defaults to defined values set in <see cref="Http.XMiddlewares"/>.
			/// </summary>
			public XMiddlewares XMiddlewares { get; init; } = new();
		}
	}
}
