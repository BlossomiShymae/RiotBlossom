namespace BlossomiShymae.RiotBlossom.Core
{
    public class RiotBlossomCore
    {
        /// <summary>
        /// Create a RiotBlossom client to access Riot Games, DataDragon, and CommunityDragon APIs.
        /// </summary>
        /// <param name="riotApiKey"></param>
        /// <returns></returns>
        public static IRiotBlossomClient CreateClient(string riotApiKey)
            => CreateClientBuilder()
                .AddRiotApiKey(riotApiKey)
                .AddRiotMiddlewareStack(new Middleware.MiddlewareStack(true, "rb-riot-cache"))
                .AddDataMiddlewareStack(new Middleware.MiddlewareStack(false, "rb-data-cache"))
                .Build();

        /// <summary>
        /// Create a RiotBlossom client builder for advanced configuration.
        /// </summary>
        /// <returns></returns>
        public static IRiotBlossomClientBuilder CreateClientBuilder()
            => new RiotBlossomClientBuilder();
    }
}
