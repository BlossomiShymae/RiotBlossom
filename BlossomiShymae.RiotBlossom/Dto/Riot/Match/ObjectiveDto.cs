namespace BlossomiShymae.RiotBlossom.Dto.Riot.Match
{
    public record ObjectiveDto : DataObject
    {
        /// <summary>
        /// Whether team got the first kill for the objective.
        /// </summary>
        public bool First { get; init; }
        /// <summary>
        /// The amount of times this objective was killed.
        /// </summary>
        public int Kills { get; init; }
    }
}
