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
            var riotHttpClient = new RiotHttpClient(settings.HttpClient, settings.RiotApiKey, settings.MiddlewareStack);
            var cDragonHttpClient = new CDragonHttpClient(settings.HttpClient);
            var dDragonHttpClient = new DDragonHttpClient(settings.HttpClient);
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
            /// The Riot API key used to gain access with. Defaults to empty string which will throw an exception upon making a Riot request.
            /// </summary>
            public string RiotApiKey { get; init; } = string.Empty;
            /// <summary>
            /// Application-level middlewares used for the request-response cycle. Defaults to defined values set in <see cref="Middleware.MiddlewareStack"/>.
            /// </summary>
            public MiddlewareStack MiddlewareStack { get; init; } = new();
        }
    }
}
