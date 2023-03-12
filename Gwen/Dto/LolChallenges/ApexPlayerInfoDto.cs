namespace Gwen.Dto.LolChallenges
{
    internal record ApexPlayerInfoDto
    {
        public string Puuid { get; init; } = default!;
        public double Value { get; init; }
        public int Position { get; init; }
    }
}
