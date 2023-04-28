using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.Match
{
    public record PerkStatsDto
    {
        /// <summary>
        /// The selected defense perk ID.
        /// </summary>
        public int Defense { get; init; }
        /// <summary>
        /// The selected flex perk ID.
        /// </summary>
        public int Flex { get; init; }
        /// <summary>
        /// The selected Offense perk ID.
        /// </summary>
        public int Offense { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
