namespace Gwen.Dto.Match
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
    }
}
