using BlossomiShymae.RiotBlossom.Core;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.LorRanked
{
    public record PlayerDto
    {
        /// <summary>
        /// The player name.
        /// </summary>
        public string Name { get; init; } = default!;
        /// <summary>
        /// The rank of player.
        /// </summary>
        public int Rank { get; init; }
        /// <summary>
        /// <para>The League points of player.</para>
        /// <para>Note: RiotBlossom deserializes from floating-point to int due to returned data type not matching the schema.</para>
        /// <para>See Developer Relations issue <see href="https://github.com/RiotGames/developer-relations/issues/345"/>.</para>
        /// </summary>
        [JsonConverter(typeof(IntJsonConverter))]
        public int Lp { get; init; }
    }
}
