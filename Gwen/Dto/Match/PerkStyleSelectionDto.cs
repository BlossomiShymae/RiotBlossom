namespace Gwen.Dto.Match
{
	/// <summary>
	/// A perk style selection used for Runes Reforged.
	/// For more details on how these are used, see CommunityDragon <see href="https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/perks.json">perks.json</see>.
	/// </summary>
	public record PerkStyleSelectionDto
	{
		/// <summary>
		/// The perk ID.
		/// </summary>
		public int Perk { get; init; }
		/// <summary>
		/// The first variable used for the end of game stat descriptions.
		/// </summary>
		public int Var1 { get; init; }
		/// <summary>
		/// The second variable used for the end of game stat descriptions.
		/// </summary>
		public int Var2 { get; init; }
		/// <summary>
		/// The third variable used for the end of game stat descriptions.
		/// </summary>
		public int Var3 { get; init; }
	}
}
