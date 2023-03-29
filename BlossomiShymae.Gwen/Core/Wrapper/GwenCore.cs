using BlossomiShymae.Gwen.Http;
using BlossomiShymae.Gwen.XMiddleware;

namespace BlossomiShymae.Gwen.Core.Wrapper
{
    public class GwenCore
    {
        /// <summary>
        /// Create a Gwen client to access Riot Games, DataDragon, and CommunityDragon APIs.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static IGwenClient CreateClient(Settings settings)
        {
            var routingValue = PlatformRouteMapper.GetId(settings.PlatformRoute);
            var riotGamesClient = new RiotHttpClient(settings.HttpClient, settings.RiotApiKey, routingValue, settings.XMiddlewares);
            var cDragonHttpClient = new CDragonHttpClient(settings.HttpClient);
            var dDragonHttpClient = new DDragonHttpClient(settings.HttpClient);
            return new GwenClient(new RiotCore(riotGamesClient, settings.PlatformRoute), cDragonHttpClient, dDragonHttpClient);
        }

        /// <summary>
        /// The settings used to pass into <see cref="CreateClient(Settings)"/>."/>
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
            /// Application-level middlewares used for the request-response cycle. Defaults to defined values set in <see cref="XMiddleware.XMiddlewares"/>.
            /// </summary>
            public XMiddlewares XMiddlewares { get; init; } = new();
        }
    }
}
