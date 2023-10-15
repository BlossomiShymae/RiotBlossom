using BlossomiShymae.RiotBlossom.Core;
using BlossomiShymae.RiotBlossom.Core.Converters;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Data.Dtos.Lor.LorRanked
{
    public record PlayerDto : DataObject
    {
        /// <summary>
        /// The player name.
        /// </summary>
        public required string Name { get; init; }
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
