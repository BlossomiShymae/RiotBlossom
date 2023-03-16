namespace Gwen.Dto.Match
{
	public record DamageStatsDto
	{
		public int MagicDamageDone { get; init; }
		public int MagicDamageDoneToChampions { get; init; }
		public int MagicDamageTaken { get; init; }
		public int PhysicalDamageDone { get; init; }
		public int PhysicalDamageDoneToChampions { get; init; }
		public int PhysicalDamageTaken { get; init; }
		public int TotalDamageDone { get; init; }
		public int TotalDamageDoneToChampions { get; init; }
		public int TotalDamageTaken { get; init; }
		public int TrueDamageDone { get; init; }
		public int TrueDamageDoneToChampions { get; init; }
		public int TrueDamageTaken { get; init; }
	}
}
