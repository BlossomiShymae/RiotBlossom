using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto.Riot.Match
{
    public record BanDto
    {
        /// <summary>
        /// The banned champion ID.
        /// </summary>
        public int ChampionId { get; init; }
        /// <summary>
        /// The pick turn that the ban occured in.
        /// </summary>
        public int PickTurn { get; init; }

        public override string ToString()
        {
            return PrettyPrinter.GetString(this);
        }
    }
}
