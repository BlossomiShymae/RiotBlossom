namespace BlossomiShymae.RiotBlossom.Dto.Riot.League
{
    public record MiniSeriesDto
    {
        /// <summary>
        /// The game losses for miniseries.
        /// </summary>
        public int Losses { get; init; }
        /// <summary>
        /// The string representation of current miniseries.
        /// <list type="bullet">
        /// <item>
        /// <term>L</term>
        /// <description>Loss</description>
        /// </item>
        /// <item>
        /// <term>W</term>
        /// <description>Win</description>
        /// </item>
        /// <item>
        /// <term>N</term>
        /// <description>Open/not played</description>
        /// </item>
        /// </list>
        /// <example>'WLWLN' is an example progress.</example>
        /// </summary>
        public string Progress { get; init; } = default!;
        /// <summary>
        /// The wins required for miniseries to be accomplished.
        /// </summary>
        public int Target { get; init; }
        /// <summary>
        /// The game wins for miniseries.
        /// </summary>
        public int Wins { get; init; }
    }
}
