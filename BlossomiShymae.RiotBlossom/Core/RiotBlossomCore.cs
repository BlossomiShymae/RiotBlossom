using BlossomiShymae.RiotBlossom.Http;
using BlossomiShymae.RiotBlossom.Middleware;

namespace BlossomiShymae.RiotBlossom.Core
{
    public class RiotBlossomCore
    {
        /// <summary>
        /// Create a RiotBlossom client to access Riot Games, DataDragon, and CommunityDragon APIs.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static IRiotBlossomClient CreateClient(Settings settings)
        {
            ComposableHttpClient riotComposableHttpClient = new(settings.HttpClient, settings.RiotMiddlewareStack);
            ComposableHttpClient dataComposableHttpClient = new(settings.HttpClient, settings.DataMiddlewareStack);

            RiotHttpClient riotHttpClient = new(riotComposableHttpClient, settings.RiotApiKey);
            CommunityDragonHttpClient cDragonHttpClient = new(dataComposableHttpClient);
            DataDragonHttpClient dDragonHttpClient = new(dataComposableHttpClient);

            return new RiotBlossomClient(riotHttpClient, cDragonHttpClient, dDragonHttpClient);
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
            /// The Riot API key used to gain access with. Defaults to empty string which will throw <see cref="Exception.MissingApiKeyException"/> upon making a Riot request.
            /// </summary>
            public string RiotApiKey { get; init; } = string.Empty;
            /// <summary>
            /// Application-level middlewares used for the request-response cycle. Injected into Riot APIs.
            /// </summary>
            public MiddlewareStack RiotMiddlewareStack { get; init; } = new(true, "riotblossom-riot");
            /// <summary>
            /// Application-level middleware stack used for the request-response cycle. Injected into DataDragon and CommunityDragon APIs.
            /// </summary>
            public MiddlewareStack DataMiddlewareStack { get; init; } = new(false, "riotblossom-data");
        }
    }
}
