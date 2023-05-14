namespace BlossomiShymae.RiotBlossom.Dto.Riot.Match
{
    public record ObjectivesDto : DataObject<ObjectivesDto>
    {

        /// <summary>
        /// The Baron Nashor on Summoner's Rift.
        /// </summary>
        public ObjectiveDto Baron { get; init; } = new();
        /// <summary>
        /// The player champions in a match.
        /// </summary>
        public ObjectiveDto Champion { get; init; } = new();
        /// <summary>
        /// The Drakes on Summoner's Rift.
        /// </summary>
        public ObjectiveDto Dragon { get; init; } = new();
        /// <summary>
        /// The base inhibitors for a team.
        /// </summary>
        public ObjectiveDto Inhibitor { get; init; } = new();
        /// <summary>
        /// The Rift Herald on Summoner's Rift.
        /// </summary>
        public ObjectiveDto RiftHerald { get; init; } = new();
        /// <summary>
        /// The lane, base, and nexus towers for a team.
        /// </summary>
        public ObjectiveDto Tower { get; init; } = new();
    }
}
