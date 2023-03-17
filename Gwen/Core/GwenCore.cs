using Gwen.Http;
using System.Collections.Immutable;

namespace Gwen.Core
{
	public class GwenCore
	{
		/// <summary>
		/// Create a simple stitch client that is locked to a single platform route.
		/// </summary>
		/// <param name="settings"></param>
		/// <returns></returns>
		public static ISimpleStitch CreateStitch(Settings settings)
		{
			var routingValue = PlatformRouteMapper.GetId(settings.PlatformRoute);
			var riotGamesClient = new RiotHttpClient(settings.HttpClient, settings.RiotApiKey, routingValue, settings.XMiddlewares);
			return new SimpleStitch(new RiotCore(riotGamesClient, settings.PlatformRoute));
		}

		/// <summary>
		/// Create a blanket stitch client that is populated for all platform routes.
		/// </summary>
		/// <param name="settings"></param>
		/// <returns></returns>
		public static IBlanketStitch CreateBlanketStitch(Settings settings)
		{
			var routingValue = PlatformRouteMapper.GetId(settings.PlatformRoute);
			var riotGamesClient = new RiotHttpClient(settings.HttpClient, settings.RiotApiKey, routingValue, settings.XMiddlewares);
			ImmutableDictionary<Type.PlatformRoute, IRiotCore> riot = Enum
				.GetValues<Type.PlatformRoute>()
				.Select(platformRoute => (IRiotCore)new RiotCore(riotGamesClient, platformRoute))
				.ToImmutableDictionary(x => x.PlatformRoute, x => x);
			return new BlanketStitch(riot);
		}

		/// <summary>
		/// The settings used to pass into <see cref="GwenCore.CreateStitch(Settings))"/> or <see cref="GwenCore.CreateBlanketStitch(Settings)"/>."/>
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
