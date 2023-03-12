using Soraka.Api;
using Soraka.Http;
using System.Collections.Immutable;

namespace Soraka.Core
{
	public static class SorakaCore
	{
		public static SorakaApiCollection Use(SorakaCoreSettings settings)
		{
			var routingValue = PlatformRouteMapper.GetId(settings.PlatformRoute);
			return new SorakaApiCollection
			{
				Summoner = SummonerApi.Use(settings.HttpClient, settings.RiotApiKey, settings.MiddlewarePipeline)(routingValue),
				PlatformRoute = settings.PlatformRoute
			};
		}

		public static ImmutableDictionary<Type.PlatformRoute, SorakaApiCollection> UsePlatformRouteDictionary(SorakaCoreSettings settings) =>
			Enum.GetValues<Type.PlatformRoute>()
				.Select(platformRoute => Use(new SorakaCoreSettings
				{
					HttpClient = settings.HttpClient,
					RiotApiKey = settings.RiotApiKey,
					MiddlewarePipeline = settings.MiddlewarePipeline,
					PlatformRoute = platformRoute
				}))
				.ToImmutableDictionary(x => x.PlatformRoute, x => x);
	}

	public record SorakaCoreSettings
	{
		public HttpClient HttpClient { get; init; } = new();
		public string RiotApiKey { get; init; } = string.Empty;
		public Type.PlatformRoute PlatformRoute { get; init; } = Type.PlatformRoute.NorthAmerica;
		public RiotGamesClient.MiddlewarePipeline MiddlewarePipeline { get; init; } = new();
	}

	public record SorakaApiCollection
	{
		public SummonerApiCollection Summoner { get; init; } = new SummonerApiCollection();
		public Type.PlatformRoute PlatformRoute { get; init; } = Type.PlatformRoute.NorthAmerica;
	}
}
