namespace Gwen.Dto.Spectator
{
    internal record BannedChampion
    {
        public int PickTurn { get; init; }
        public long ChampionId { get; init; }
        public long TeamId { get; init; }
    }
}
