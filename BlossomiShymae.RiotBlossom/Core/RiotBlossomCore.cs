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
                .Build();

        /// <summary>
        /// Create a RiotBlossom client builder for advanced configuration.
        /// </summary>
        /// <returns></returns>
        public static IRiotBlossomClientBuilder CreateClientBuilder()
            => new RiotBlossomClientBuilder();
    }
}
