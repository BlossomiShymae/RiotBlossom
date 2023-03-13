using System.Collections.Immutable;
using Gwen.Api;
using Gwen.Http;

namespace Gwen.Core
{
    public static class GwenCore
    {
        public static GwenApiCollection Use(GwenCoreSettings settings)
        {
            var routingValue = PlatformRouteMapper.GetId(settings.PlatformRoute);
            return new GwenApiCollection
            {
                Summoner = SummonerApi.Use(settings.HttpClient, settings.RiotApiKey, settings.MiddlewarePipeline)(routingValue),
                PlatformRoute = settings.PlatformRoute
            };
        }

        public static ImmutableDictionary<Type.PlatformRoute, GwenApiCollection> UsePlatformRouteDictionary(GwenCoreSettings settings) =>
            Enum.GetValues<Type.PlatformRoute>()
                .Select(platformRoute => Use(new GwenCoreSettings
                {
                    HttpClient = settings.HttpClient,
                    RiotApiKey = settings.RiotApiKey,
                    MiddlewarePipeline = settings.MiddlewarePipeline,
                    PlatformRoute = platformRoute
                }))
                .ToImmutableDictionary(x => x.PlatformRoute, x => x);
    }

    public record GwenCoreSettings
    {
        public HttpClient HttpClient { get; init; } = new();
        public string RiotApiKey { get; init; } = string.Empty;
        public Type.PlatformRoute PlatformRoute { get; init; } = Type.PlatformRoute.NorthAmerica;
        public RiotGamesClient.MiddlewarePipeline MiddlewarePipeline { get; init; } = new();
    }

    public record GwenApiCollection
    {
        public SummonerApiCollection Summoner { get; init; } = new SummonerApiCollection();
        public Type.PlatformRoute PlatformRoute { get; init; } = Type.PlatformRoute.NorthAmerica;
    }
}
